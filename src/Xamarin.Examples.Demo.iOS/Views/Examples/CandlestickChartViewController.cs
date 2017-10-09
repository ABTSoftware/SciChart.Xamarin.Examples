using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Candlestick Chart", description: "A simple candlestick chart with Up/Down bars", icon: ExampleIcon.CandlestickChart)]
    public class CandlestickChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            var priceSeries = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>();
            dataSeries.Append(priceSeries.TimeData, priceSeries.OpenData, priceSeries.HighData, priceSeries.LowData, priceSeries.CloseData);

            var size = priceSeries.Count;
            var xAxis = new SCICategoryDateTimeAxis { VisibleRange = new SCIDoubleRange(size - 30, size), GrowBy = new SCIDoubleRange(0, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0, 0.1), AutoRange = SCIAutoRange.Always };

            var renderSeries = new SCIFastCandlestickRenderableSeries
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
                Surface.RenderableSeries.Add(renderSeries);

                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomPanModifier(),
                    new SCIPinchZoomModifier(),
                    new SCIZoomExtentsModifier()
                };
            }
        }
    }
}