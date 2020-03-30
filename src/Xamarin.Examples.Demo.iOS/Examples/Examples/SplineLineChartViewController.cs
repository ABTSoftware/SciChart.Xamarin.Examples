using SciChart.iOS.Charting;
using CoreGraphics;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Spline Line Chart", "Create a spline Line Chart", icon: ExampleIcon.LineChart)]
    public class SplineLineChartViewController : SingleChartViewController<SCIChartSurface>
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

            var lineSeries = new SCIFastLineRenderableSeries()
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFF4282B4, 2f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Size = new CGSize(7, 7),
                    StrokeStyle = new SCISolidPenStyle(0xFF006400, 1f),
                    FillStyle = new SCISolidBrushStyle(0xFFFFFFFF)
                }
            };
            var rSeries = new SCISplineLineRenderableSeries { DataSeries = dataSeries, StrokeStyle = new SCISolidPenStyle(0xFF006400, 2f) };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomPanModifier(),
                    new SCIPinchZoomModifier(),
                    new SCIZoomExtentsModifier(),
                };

                SCIAnimations.SweepSeries(rSeries, 3, 0.35, new SCICubicEase());
                SCIAnimations.SweepSeries(lineSeries, 3, 0.35, new SCICubicEase());
            }
        }
    }
}
