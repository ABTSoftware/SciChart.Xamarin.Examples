using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Custom Rounded Columns Chart", description: "Generates a rounded columns chart in code.", icon: ExampleIcon.ColumnChart)]
    public class RoundedColumnsChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.2, 0.2) };

            var dataSeries = new XyDataSeries<double, double>();
            var yValues = new[] { 50, 35, 61, 58, 50, 50, 40, 53, 55, 23, 45, 12, 59, 60 };
            for (var i = 0; i < yValues.Length; i++)
            {
                dataSeries.Append(i, yValues[i]);
            }

            var rSeries = new RoundedColumnRenderableSeries {
                DataSeries = dataSeries,
                FillBrushStyle = new SCISolidBrushStyle(0xff3cf3a6)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers.Add(CreateDefaultModifiers());

                SCIAnimations.WaveSeries(rSeries, 3, new SCICubicEase());
            }
        }
    }
}
