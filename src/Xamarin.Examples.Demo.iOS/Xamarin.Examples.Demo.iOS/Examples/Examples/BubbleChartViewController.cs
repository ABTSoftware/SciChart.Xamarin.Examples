using System;
using System.Linq;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Bubble Chart", description: "Generates a Line and Bubble series chart in code", icon: ExampleIcon.BubbleChart)]
    public class BubbleChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCIDateAxis { GrowBy = new SCIDoubleRange(0.0, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0, 0.1) };

            var dataSeries = new XyzDataSeries<DateTime, double, double>();
            var tradeDataSource = DataManager.Instance.GetTradeticks().ToArray();

            dataSeries.Append(
                tradeDataSource.Select(x => x.TradeDate).ToArray(),
                tradeDataSource.Select(x => x.TradePrice).ToArray(),
                tradeDataSource.Select(x => x.TradeSize).ToArray());

            var lineSeries = new SCIFastLineRenderableSeries { DataSeries = dataSeries, StrokeStyle = new SCISolidPenStyle(0xFFFF3333, 1f) };

            var rSeries = new SCIFastBubbleRenderableSeries
            {
                DataSeries = dataSeries,
                ZScaleFactor = 1,
                AutoZRange = false,
                BubbleBrushStyle = new SCISolidBrushStyle(0x50CCCCCC),
                StrokeStyle = new SCISolidPenStyle(0xFFCCCCCC, 2f)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers.Add(new SCIZoomExtentsModifier());

                SCIAnimations.ScaleSeriesWithZeroLine(rSeries, 10600, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(lineSeries, 10600, 3, new SCIElasticEase());
            }
        }
    }
}