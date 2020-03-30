using SciChart.iOS.Charting;
using CoreGraphics;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Spline Mountain Chart", "Create a spline Mountain / Area Chart", icon: ExampleIcon.MountainChart)]
    public class SplineMountainChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.2, 0.2) };

            var dataSeries = new XyDataSeries<int, int>();
            var yValues = new[] { 50, 35, 61, 58, 50, 50, 40, 53, 55, 23, 45, 12, 59, 60 };
            for (int i = 0; i < yValues.Length; i++)
            {
                dataSeries.Append(i, yValues[i]);
            }

            var rSeries = new SCISplineMountainRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xAAFFC9A8, 2f),
                AreaStyle = new SCILinearGradientBrushStyle(0xAAFF8D42, 0x88090E11),
                PointMarker = new SCIEllipsePointMarker
                {
                    Size = new CGSize(7, 7),
                    StrokeStyle = new SCISolidPenStyle(0xFF006400, 1f),
                    FillStyle = new SCISolidBrushStyle(0xFFFFFFFF)
                }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomPanModifier(),
                    new SCIPinchZoomModifier(),
                    new SCIZoomExtentsModifier(),
                };

                SCIAnimations.WaveSeries(rSeries, 3, 0.35, new SCICubicEase());
            }
        }
    }
}
