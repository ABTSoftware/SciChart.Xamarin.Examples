using System;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Candlestick Chart", description: "A simple candlestick chart with Up/Down bars", icon: ExampleIcon.CandlestickChart)]
    public class CandlestickChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var priceSeries = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>();
            dataSeries.Append(priceSeries.TimeData, priceSeries.OpenData, priceSeries.HighData, priceSeries.LowData, priceSeries.CloseData);

            var size = priceSeries.Count;
            var xAxis = new SCICategoryDateAxis { VisibleRange = new SCIDoubleRange(size - 30, size), GrowBy = new SCIDoubleRange(0, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0, 0.1), AutoRange = SCIAutoRange.Always };

            var rSeries = new SCIFastCandlestickRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeUpStyle = new SCISolidPenStyle(0xFF00AA00, 1f),
                StrokeDownStyle = new SCISolidPenStyle(0xFFFF0000, 1f),
                FillUpBrushStyle = new SCISolidBrushStyle(0x8800AA00),
                FillDownBrushStyle = new SCISolidBrushStyle(0x88FF0000)
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