using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Band Chart", "Generates a simple Band series chart in code", icon: ExampleIcon.BandChart)]
    public class BandChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var data0 = DataManager.Instance.GetDampedSinewave(1.0, 0.01, 1000);
            var data1 = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 12);

            var dataSeries = new XyyDataSeries<double, double>();
            dataSeries.Append(data0.XData, data0.YData, data1.YData);

            var xAxis = new SCINumericAxis { VisibleRange = new SCIDoubleRange(1.1, 2.7) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var rSeries = new SCIFastBandRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFFFF1919, 0.7f),
                StrokeY1Style = new SCISolidPenStyle(0xFF279B27, 0.7f),
                FillBrushStyle = new SCISolidBrushStyle(0x33279B27),
                FillY1BrushStyle = new SCISolidBrushStyle(0x33FF1919)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers.Add(CreateDefaultModifiers());

                SCIAnimations.ScaleSeries(rSeries, 3, new SCIElasticEase());
            }
        }
    }
}