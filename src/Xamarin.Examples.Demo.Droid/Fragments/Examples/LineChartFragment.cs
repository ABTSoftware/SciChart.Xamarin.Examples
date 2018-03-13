using Android.Views.Animations;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Line Chart", description:"Create a simple Line Chart", icon: ExampleIcon.LineChart)]
    public class LineChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1), VisibleRange = new DoubleRange(1.1, 2.7)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};

            var fourierSeries = DataManager.Instance.GetFourierSeries(1.0, 0.1);
            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(fourierSeries.XData, fourierSeries.YData);

            var rSeries = new FastLineRenderableSeries {DataSeries = dataSeries, StrokeStyle = new SolidPenStyle(0xFF279B27, 2f.ToDip(Activity))};

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };

                new SweepAnimatorBuilder(rSeries) { Interpolator = new DecelerateInterpolator(), Duration = 3000, StartDelay = 350 }.Start();
            }
        }
    }
}