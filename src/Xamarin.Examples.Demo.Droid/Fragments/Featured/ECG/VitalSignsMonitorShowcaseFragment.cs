using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;
using SciChart.Charting.LayoutManagers;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Xamarin.Examples.Demo.Showcase.VitalSignsMonitor;


namespace Xamarin.Examples.Demo.Droid.Fragments.Featured.ECG
{
    [FeaturedExampleDefinition("Vital Signs Monitor", "Showcases a real-time vital signs monitor", ExampleIcon.FeatureChart)]
    public class VitalSignsMonitorShowcaseFragment : ExampleBaseFragment
    {
        private const int FifoCapacity = 7850;

        public override int ExampleLayoutId => Resource.Layout.Example_Vital_Signs_Monitor_Fragment;

        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public ImageView HeartIcon => View.FindViewById<ImageView>(Resource.Id.heartIcon);
        public TextView BpmValueLabel => View.FindViewById<TextView>(Resource.Id.bpmValueLabel);
        public TextView BloodPressureValue => View.FindViewById<TextView>(Resource.Id.bloodPressureValue);
        public StepProgressBar BloodPressureBar => View.FindViewById<StepProgressBar>(Resource.Id.bloodPressureBar);
        public TextView SpoValueLabel => View.FindViewById<TextView>(Resource.Id.spoValueLabel);
        public TextView SpoClockLabel => View.FindViewById<TextView>(Resource.Id.spoClockLabel);
        public TextView BloodVolumeValueLabel => View.FindViewById<TextView>(Resource.Id.bloodVolumeValueLabel);

        public StepProgressBar SvBar1 => View.FindViewById<StepProgressBar>(Resource.Id.svBar1);
        public StepProgressBar SvBar2 => View.FindViewById<StepProgressBar>(Resource.Id.svBar2);

        private readonly XyDataSeries<double, double> _ecgDataSeries = new XyDataSeries<double, double>() {FifoCapacity = new Integer(FifoCapacity) };
        private readonly XyDataSeries<double, double> _ecgSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(FifoCapacity) };
        private readonly XyDataSeries<double, double> _bloodPressureDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(FifoCapacity) };
        private readonly XyDataSeries<double, double> _bloodPressureSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(FifoCapacity) };
        private readonly XyDataSeries<double, double> _bloodVolumeDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(FifoCapacity) };
        private readonly XyDataSeries<double, double> _bloodVolumeSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(FifoCapacity) };
        private readonly XyDataSeries<double, double> _bloodOxygenationDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(FifoCapacity) };
        private readonly XyDataSeries<double, double> _bloodOxygenationSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(FifoCapacity) };

        private readonly XyDataSeries<double, double> _lastEcgSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(1) };
        private readonly XyDataSeries<double, double> _lastBloodPressureDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(1) };
        private readonly XyDataSeries<double, double> _lastBloodVolumeDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(1) };
        private readonly XyDataSeries<double, double> _lastBloodOxygenationSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = new Integer(1) };

        private IDisposable _dataSubscription;
        private readonly DefaultVitalSignsDataProvider _dataProvider = new DefaultVitalSignsDataProvider();

        private readonly VitalSignsIndicatorsProvider _indicatorsProvider = new VitalSignsIndicatorsProvider();

        private readonly VitalSignsDataBatch _dataBatch = new VitalSignsDataBatch();

        protected override void InitExample()
        {
            SetUpChart();

            var dataSubscription = _dataProvider.Data.Buffer(TimeSpan.FromMilliseconds(16)).Do(data =>
            {
                if(data.Count == 0) return;

                _dataBatch.UpdateData(data);

                using (Surface.SuspendUpdates())
                {
                    var xValues = _dataBatch.XValues;

                    _ecgDataSeries.Append(xValues, _dataBatch.ECGHeartRateValuesA);
                    _ecgSweepDataSeries.Append(xValues, _dataBatch.ECGHeartRateValuesB);

                    _bloodPressureDataSeries.Append(xValues, _dataBatch.BloodPressureValuesA);
                    _bloodPressureSweepDataSeries.Append(xValues, _dataBatch.BloodPressureValuesB);

                    _bloodOxygenationDataSeries.Append(xValues, _dataBatch.BloodOxygenationValuesA);
                    _bloodOxygenationSweepDataSeries.Append(xValues, _dataBatch.BloodOxygenationValuesB);

                    _bloodVolumeDataSeries.Append(xValues, _dataBatch.BloodVolumeValuesA);
                    _bloodVolumeSweepDataSeries.Append(xValues, _dataBatch.BloodVolumeValuesB);

                    var lastEcgData = _dataBatch.LastVitalSignsData;
                    var xValue = lastEcgData.XValue;

                    _lastEcgSweepDataSeries.Append(xValue, lastEcgData.ECGHeartRate);
                    _lastBloodPressureDataSeries.Append(xValue, lastEcgData.BloodPressure);
                    _lastBloodOxygenationSweepDataSeries.Append(xValue, lastEcgData.BloodOxygenation);
                    _lastBloodVolumeDataSeries.Append(xValue, lastEcgData.BloodVolume);
                }
            }).Subscribe();

            UpdateIndicators(0);
            var indicatorSubscription = Observable.Interval(TimeSpan.FromSeconds(1)).ObserveOn(SynchronizationContext.Current).Do(UpdateIndicators).Subscribe();

            _dataSubscription = new CompositeDisposable(dataSubscription, indicatorSubscription);
        }

        public override void OnDestroyView()
        {
            _dataSubscription.Dispose();
            _dataSubscription = null;

            base.OnDestroyView();
        }

        private void SetUpChart()
        {
            var xAxis = new NumericAxis(Activity)
            {
                VisibleRange = new DoubleRange(0, 10),
                AutoRange = AutoRange.Never,
                DrawMinorGridLines = false,
                DrawMajorBands = false,
                Visibility = (int) ViewStates.Gone
            };

            const string ecgId = "ecgId";
            const string bloodPressureId = "bloodPressureId";
            const string bloodVolumeId = "bloodVolumeId";
            const string bloodOxygenationId = "bloodOxygenationId";

            var heartRateColor = ContextCompat.GetColor(Activity, Resource.Color.heart_rate_color).ToColor();
            var bloodPressureColor = ContextCompat.GetColor(Activity, Resource.Color.blood_pressure_color).ToColor();
            var bloodVolumeColor = ContextCompat.GetColor(Activity, Resource.Color.blood_volume_color).ToColor();
            var bloodOxygenation = ContextCompat.GetColor(Activity, Resource.Color.blood_oxygenation_color).ToColor();

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(GenerateYAxis(ecgId, _dataProvider.EcgHeartRateRange));
                Surface.YAxes.Add(GenerateYAxis(bloodPressureId, _dataProvider.BloodPressureRange));
                Surface.YAxes.Add(GenerateYAxis(bloodVolumeId, _dataProvider.BloodVolumeRange));
                Surface.YAxes.Add(GenerateYAxis(bloodOxygenationId, _dataProvider.BloodOxygenationRange));

                var ecgSeries = GenerateSeries(ecgId, Tuple.Create(_ecgDataSeries, _ecgSweepDataSeries, _lastEcgSweepDataSeries), heartRateColor);
                var bloodPressureSeries = GenerateSeries(bloodPressureId, Tuple.Create(_bloodPressureDataSeries, _bloodPressureSweepDataSeries, _lastBloodPressureDataSeries), bloodPressureColor);
                var bloodVolumeSeries = GenerateSeries(bloodVolumeId, Tuple.Create(_bloodVolumeDataSeries, _bloodVolumeSweepDataSeries, _lastBloodVolumeDataSeries), bloodVolumeColor);
                var bloodOxygenationSeries = GenerateSeries(bloodOxygenationId, Tuple.Create(_bloodOxygenationDataSeries, _bloodOxygenationSweepDataSeries, _lastBloodOxygenationSweepDataSeries), bloodOxygenation);

                foreach (var rs in ecgSeries.Concat(bloodPressureSeries).Concat(bloodVolumeSeries).Concat(bloodOxygenationSeries))
                {
                    Surface.RenderableSeries.Add(rs);
                }

                Surface.LayoutManager = new DefaultLayoutManager.Builder().SetRightOuterAxesLayoutStrategy(new RightAlignedOuterVerticallyStackedYAxisLayoutStrategy()).Build();
            }
        }

        private NumericAxis GenerateYAxis(string axisId, (double, double) visibleRange)
        {
            return new NumericAxis(Activity)
            {
                AxisId = axisId,
                Visibility = (int)ViewStates.Gone,
                VisibleRange = new DoubleRange(visibleRange.Item1, visibleRange.Item2),
                AutoRange = AutoRange.Never,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false,
            };
        }

        private IEnumerable<IRenderableSeries> GenerateSeries(
            string yAxisId, Tuple<XyDataSeries<double, double>, XyDataSeries<double, double>, XyDataSeries<double, double>> dataSeries, Color color)
        {
            var thickness = 1f.ToDip(Activity);
            var penStyle = new SolidPenStyle(color, thickness);
            var pointMarkerSize = (int)(4 * thickness);

            var rs1 = new FastLineRenderableSeries()
            {
                YAxisId = yAxisId,
                DataSeries = dataSeries.Item1,
                StrokeStyle = penStyle,
                PaletteProvider = new DimTracePaletteProvider()
            };

            var rs2 = new FastLineRenderableSeries()
            {
                YAxisId = yAxisId,
                DataSeries = dataSeries.Item2,
                StrokeStyle = penStyle,
                PaletteProvider = new DimTracePaletteProvider()
            };

            var rs3 = new XyScatterRenderableSeries()
            {
                YAxisId = yAxisId,
                DataSeries = dataSeries.Item3,
                PointMarker = new EllipsePointMarker()
                {
                    FillStyle = new SolidBrushStyle(color),
                    StrokeStyle = new SolidPenStyle(Color.White, thickness),
                    Width = pointMarkerSize,
                    Height = pointMarkerSize
                }
            };

            return new IRenderableSeries[] {rs1, rs2, rs3};
        }

        private void UpdateIndicators(long time)
        {
            HeartIcon.Visibility = time % 2 == 0 ? ViewStates.Visible : ViewStates.Invisible;

            if (time % 5 == 0)
            {
                _indicatorsProvider.Update();

                BpmValueLabel.Text = _indicatorsProvider.BpmValue;

                BloodPressureValue.Text = _indicatorsProvider.BpValue;
                BloodPressureBar.Progress = _indicatorsProvider.BpbValue;

                BloodVolumeValueLabel.Text = _indicatorsProvider.BvValue;
                SvBar1.Progress = _indicatorsProvider.BvBar1Value;
                SvBar2.Progress = _indicatorsProvider.BvBar2Value;

                SpoValueLabel.Text = _indicatorsProvider.SpoValue;
                SpoClockLabel.Text = _indicatorsProvider.SpoClockValue;
            }
        }
    }
}