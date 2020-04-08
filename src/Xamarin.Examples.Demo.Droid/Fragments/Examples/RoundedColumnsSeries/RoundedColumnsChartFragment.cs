using Android.Views.Animations;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Custom Rounded Columns Chart", description: "Generates a rounded columns chart in code.", icon: ExampleIcon.ColumnChart)]
    public class RoundedColumnsChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1) };
            var yAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.2, 0.2) };

            var dataSeries = new XyDataSeries<double, double>();

            var yValues = new[] { 50, 35, 61, 58, 50, 50, 40, 53, 55, 23, 45, 12, 59, 60 };
            for (var i = 0; i < yValues.Length; i++)
            {
                dataSeries.Append(i, yValues[i]);
            }

            var rSeries = new RoundedColumnsRenderableSeries
            {
                DataSeries = dataSeries,
                FillBrushStyle = new SolidBrushStyle(0xFF3CF3A6),
            };

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

                new ScaleAnimatorBuilder(rSeries) { Interpolator = new OvershootInterpolator(), Duration = 1500, StartDelay = 350 }.Start();
            }
        }
    }
}
