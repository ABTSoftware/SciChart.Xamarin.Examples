using System;
using System.Threading;
using System.Collections.Generic;
using SciChart.iOS.Charting;
using CoreGraphics;
using UIKit;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using Xamarin.Examples.Demo.Showcase.VitalSignsMonitor;

namespace Xamarin.Examples.Demo.iOS
{
    [FeaturedExampleDefinition("Vital Signs Monitor", description: "Vital Signs Monitor", icon: ExampleIcon.FeatureChart)]
    public partial class VitalSignsMonitorViewController : UIViewController
    {
        public VitalSignsMonitorViewController() : base("VitalSignsMonitorViewController", null)
        {
        }

        private const int FifoCapacity = 7850;

        private readonly XyDataSeries<double, double> _ecgDataSeries = new XyDataSeries<double, double>() { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _ecgSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _bloodPressureDataSeries = new XyDataSeries<double, double>() { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _bloodPressureSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _bloodVolumeDataSeries = new XyDataSeries<double, double>() { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _bloodVolumeSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _bloodOxygenationDataSeries = new XyDataSeries<double, double>() { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _bloodOxygenationSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = FifoCapacity };

        private readonly XyDataSeries<double, double> _lastEcgSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = 1 };
        private readonly XyDataSeries<double, double> _lastBloodPressureDataSeries = new XyDataSeries<double, double>() { FifoCapacity = 1 };
        private readonly XyDataSeries<double, double> _lastBloodVolumeDataSeries = new XyDataSeries<double, double>() { FifoCapacity = 1 };
        private readonly XyDataSeries<double, double> _lastBloodOxygenationSweepDataSeries = new XyDataSeries<double, double>() { FifoCapacity = 1 };

        private IDisposable _dataSubscription;

        private readonly DefaultVitalSignsDataProvider _dataProvider = new DefaultVitalSignsDataProvider();

        private readonly VitalSignsIndicatorsProvider _indicatorsProvider = new VitalSignsIndicatorsProvider();

        private readonly VitalSignsDataBatch _dataBatch = new VitalSignsDataBatch();

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupChart();
            SetupIndicators();

            var dataSubscription = _dataProvider.Data.Buffer(TimeSpan.FromMilliseconds(16)).ObserveOn(SynchronizationContext.Current).Do(data =>
            {
                if (data.Count == 0) return;

                _dataBatch.UpdateData(data);

                using (Surface.SuspendUpdates())
                {
                    var xValues = _dataBatch.XValues;

                    _ecgDataSeries.AppendValues(xValues, _dataBatch.ECGHeartRateValuesA);
                    _ecgSweepDataSeries.AppendValues(xValues, _dataBatch.ECGHeartRateValuesB);

                    _bloodPressureDataSeries.AppendValues(xValues, _dataBatch.BloodPressureValuesA);
                    _bloodPressureSweepDataSeries.AppendValues(xValues, _dataBatch.BloodPressureValuesB);

                    _bloodOxygenationDataSeries.AppendValues(xValues, _dataBatch.BloodOxygenationValuesA);
                    _bloodOxygenationSweepDataSeries.AppendValues(xValues, _dataBatch.BloodOxygenationValuesB);

                    _bloodVolumeDataSeries.AppendValues(xValues, _dataBatch.BloodVolumeValuesA);
                    _bloodVolumeSweepDataSeries.AppendValues(xValues, _dataBatch.BloodVolumeValuesB);

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

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            _dataSubscription.Dispose();
        }

        void SetupChart()
        {
            var xAxis = new SCINumericAxis()
            {
                VisibleRange = new SCIDoubleRange(0, 10),
                AutoRange = SCIAutoRange.Never,
                DrawMinorGridLines = false,
                DrawMajorBands = false,
                IsVisible = false
            };

            const string ecgId = "ecgId";
            const string bloodPressureId = "bloodPressureId";
            const string bloodVolumeId = "bloodVolumeId";
            const string bloodOxygenationId = "bloodOxygenationId";

            const uint heartRateColor = 0xFF42B649;
            const uint bloodPressureColor = 0xFFFFFF00;
            const uint bloodVolumeColor = 0xFFB0C4DE;
            const uint bloodOxygenation = 0xFF6495ED;

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

                foreach (var rs in ecgSeries)
                {
                    Surface.RenderableSeries.Add(rs);
                }

                foreach (var rs in bloodPressureSeries)
                {
                    Surface.RenderableSeries.Add(rs);
                }

                foreach (var rs in bloodVolumeSeries)
                {
                    Surface.RenderableSeries.Add(rs);
                }

                foreach (var rs in bloodOxygenationSeries)
                {
                    Surface.RenderableSeries.Add(rs);
                }

                Surface.LayoutManager = new SCIDefaultLayoutManager()
                {
                    RightOuterAxisLayoutStrategy = new RightAlignedOuterVerticallyStackedYAxisLayoutStrategy()
                };
            }
        }

        private SCINumericAxis GenerateYAxis(string axisId, (double, double) visibleRange)
        {
            return new SCINumericAxis()
            {
                AxisId = axisId,
                IsVisible = false,
                VisibleRange = new SCIDoubleRange(visibleRange.Item1, visibleRange.Item2),
                AutoRange = SCIAutoRange.Never,
                DrawMajorBands = false,
                DrawMinorGridLines = false,
                DrawMajorGridLines = false,
            };
        }

        private IEnumerable<IISCIRenderableSeries> GenerateSeries(
            string yAxisId, Tuple<XyDataSeries<double, double>, XyDataSeries<double, double>, XyDataSeries<double, double>> dataSeries, uint color)
        {
            var thickness = 1f;
            var penStyle = new SCISolidPenStyle(color, thickness);
            var pointMarkerSize = (int)(4 * thickness);

            var rs1 = new SCIFastLineRenderableSeries()
            {
                YAxisId = yAxisId,
                DataSeries = dataSeries.Item1,
                StrokeStyle = penStyle,
                PaletteProvider = new DimTracePaletteProvider()
            };

            var rs2 = new SCIFastLineRenderableSeries()
            {
                YAxisId = yAxisId,
                DataSeries = dataSeries.Item2,
                StrokeStyle = penStyle,
                PaletteProvider = new DimTracePaletteProvider()
            };

            var rs3 = new SCIXyScatterRenderableSeries()
            {
                YAxisId = yAxisId,
                DataSeries = dataSeries.Item3,
                PointMarker = new SCIEllipsePointMarker()
                {
                    Size = new CGSize(pointMarkerSize, pointMarkerSize),
                    FillStyle = new SCISolidBrushStyle(color),
                    StrokeStyle = new SCISolidPenStyle(UIColor.White, thickness)               
                }
            };

            return new IISCIRenderableSeries[] { rs1, rs2, rs3 };
        }

        private void SetupIndicators()
        {
            ProgressBarStyle bpBarStyle = new ProgressBarStyle(false, 10, 2, 3, UIColor.FromRGB(100, 100, 100), UIColor.FromRGB(66, 182, 73));
            BloodPressureBar.SetStyle(bpBarStyle);

            ProgressBarStyle svBarStyle = new ProgressBarStyle(true, 12, 2, 3, UIColor.Clear, UIColor.FromRGB(176, 196, 222));
            SvBar1.SetStyle(svBarStyle);
            SvBar2.SetStyle(svBarStyle);

            BloodPressureBar.SetProgress(2);
            SvBar1.SetProgress(3);
            SvBar2.SetProgress(4);
        }

        private void UpdateIndicators(long time)
        {
            HeartImageView.Hidden = time % 2 == 0 ? false : true;

            if (time % 5 == 0)
            {
                _indicatorsProvider.Update();

                BpmValueLabel.Text = _indicatorsProvider.BpmValue;

                BloodPressureValueLabel.Text = _indicatorsProvider.BpValue;
                BloodPressureBar.SetProgress(_indicatorsProvider.BpbValue);

                BloodVolumeValueLabel.Text = _indicatorsProvider.BvValue;
                SvBar1.SetProgress(_indicatorsProvider.BvBar1Value);
                SvBar2.SetProgress(_indicatorsProvider.BvBar2Value);

                SpoValueLabel.Text = _indicatorsProvider.SpoValue;
                SpoClockLabel.Text = _indicatorsProvider.SpoClockValue;
            }
        }
    }
}