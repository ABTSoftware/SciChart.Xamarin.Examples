using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Using CursorModifier Tooltips", description: "Demonstrates Cursors on the Chart", icon: ExampleIcon.Annotations)]
    public class UsingCursorModifierTooltipsViewController : SingleChartViewController<SCIChartSurface>
    {
        private const int PointsCount = 500;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { VisibleRange = new SCIDoubleRange(3, 6) };
            var yAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always, GrowBy = new SCIDoubleRange(0.05d, 0.05d) };

            var ds1 = new XyDataSeries<double, double> { SeriesName = "Green Series" };
            var ds2 = new XyDataSeries<double, double> { SeriesName = "Red Series" };
            var ds3 = new XyDataSeries<double, double> { SeriesName = "Gray Series" };
            var ds4 = new XyDataSeries<double, double> { SeriesName = "Gold Series" };

            var data1 = DataManager.Instance.GetNoisySinewave(300, 1, PointsCount, 0.25);
            var data2 = DataManager.Instance.GetSinewave(100, 2, PointsCount);
            var data3 = DataManager.Instance.GetSinewave(200, 1.5, PointsCount);
            var data4 = DataManager.Instance.GetSinewave(50, 0.1, PointsCount);

            ds1.Append(data1.XData, data1.YData);
            ds2.Append(data2.XData, data2.YData);
            ds3.Append(data3.XData, data3.YData);
            ds4.Append(data4.XData, data4.YData);

            var rs1 = new SCIFastLineRenderableSeries { DataSeries = ds1, StrokeStyle = new SCISolidPenStyle(0xFF177B17, 2f) };
            var rs2 = new SCIFastLineRenderableSeries { DataSeries = ds2, StrokeStyle = new SCISolidPenStyle(0xFFDD0909, 2f) };
            var rs3 = new SCIFastLineRenderableSeries { DataSeries = ds3, StrokeStyle = new SCISolidPenStyle(0xFF808080, 2f) };
            var rs4 = new SCIFastLineRenderableSeries { DataSeries = ds4, StrokeStyle = new SCISolidPenStyle(0xFFFFD700, 2f), IsVisible = false };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries = new SCIRenderableSeriesCollection { rs1, rs2, rs3, rs4 };
                Surface.ChartModifiers.Add(new SCICursorModifier());

                SCIAnimations.SweepSeries(rs1, 3, new SCICubicEase());
                SCIAnimations.SweepSeries(rs2, 3, new SCICubicEase());
                SCIAnimations.SweepSeries(rs3, 3, new SCICubicEase());
                SCIAnimations.SweepSeries(rs4, 3, new SCICubicEase());
            }
        }
    }
}