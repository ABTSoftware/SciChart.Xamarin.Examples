using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using CoreGraphics;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Spline Band Chart", "Creates a spline Band Series Chart", icon: ExampleIcon.BandChart)]
    public class SplineBandChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.2, 0.2) };

            var data = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 13);
            var moreData = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 12);

            var dataSeries = new XyyDataSeries<double, double>();
            for (int i = 0; i < 10; i++)
            {
                var index = i * 100;
                dataSeries.Append(data.XData[index], data.YData[index], moreData.YData[index]);
            }

            var rSeries = new SCISplineBandRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFFFF1919, 1f),
                StrokeY1Style = new SCISolidPenStyle(0xFF279B27, 1f),
                FillBrushStyle = new SCISolidBrushStyle(0x33279B27),
                FillY1BrushStyle = new SCISolidBrushStyle(0x33FF1919),
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

                SCIAnimations.SweepSeries(rSeries, 3, 0.35, new SCICubicEase());
            }
        }
    }
}
