using Android.Views.Animations;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Spline Mountain Chart", description: "Create a spline Mountain / Area Chart", icon: ExampleIcon.MountainChart)]
    public class SplineMountainChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.2, 0.2)};

            var dataSeries = new XyDataSeries<int, int>();
            var yValues = new[] {50, 35, 61, 58, 50, 50, 40, 53, 55, 23, 45, 12, 59, 60};
            for (int i = 0; i < yValues.Length; i++)
            {
                dataSeries.Append(i, yValues[i]);
            }

            var rSeries = new SplineMountainRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(0xAAFFC9A8, 2f.ToDip(Activity)),
                AreaStyle = new LinearGradientBrushStyle(0, 0, 1, 1, 0xAAFF8D42, 0x88090E11),
                PointMarker = new EllipsePointMarker
                {
                    Width = 7.ToDip(Activity),
                    Height = 7.ToDip(Activity),
                    StrokeStyle = new SolidPenStyle(0xFF006400, 1f.ToDip(Activity)),
                    FillStyle = new SolidBrushStyle(0xFFFFFFFF)
                }
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

                new WaveAnimatorBuilder(rSeries) {Interpolator = new DecelerateInterpolator(), Duration = 3000, StartDelay = 350}.Start();
            }
        }
    }
}