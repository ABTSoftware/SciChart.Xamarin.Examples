using System;
using System.Linq;
using UIKit;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Multi-Pane Stock Charts", description: "Creates an example with static multi-pane stock chart with Indicator and Volume panes", icon: ExampleIcon.CandlestickChart)]
    public class CreateMultiPaneStockChartsViewController : CustomLayoutViewController<MultiplePaneStockChartsLayout>
    {
        private static readonly string VOLUME = "Volume";
        private static readonly string PRICES = "Prices";
        private static readonly string RSI = "RSI";
        private static readonly string MACD = "MACD";

        public SCIChartSurface PriceChart => Layout.PriceSurfaceView;
        public SCIChartSurface MacdChart => Layout.MacdSurfaceView;
        public SCIChartSurface RsiChart => Layout.RsiSurfaceView;
        public SCIChartSurface VolumeChart => Layout.VolumeChartView;

        private readonly SCIChartVerticalGroup vertiсalGroup = new SCIChartVerticalGroup();
        private readonly SCIDoubleRange sharedXRange = new SCIDoubleRange();

        protected override void InitExample()
        {
            var priceData = DataManager.Instance.GetPriceDataEurUsd();

            var pricePaneModel = new PricePaneModel(priceData);
            var macdPaneModel = new MacdPaneModel(priceData);
            var rsiPaneModel = new RsiPaneModel(priceData);
            var volumePaneModel = new VolumePaneModel(priceData);

            InitChart(PriceChart, pricePaneModel, true);
            InitChart(MacdChart, macdPaneModel, false);
            InitChart(RsiChart, rsiPaneModel, false);
            InitChart(VolumeChart, volumePaneModel, false);
        }

        private void InitChart(SCIChartSurface surface, BasePaneModel model, bool isMainPain)
        {
            var xAxis = new SCICategoryDateAxis { IsVisible = isMainPain, VisibleRange = sharedXRange, GrowBy = new SCIDoubleRange(0, 0.05) };   
            using (surface.SuspendUpdates())
            {
                surface.XAxes.Add(xAxis);
                surface.YAxes.Add(model.YAxis);
                surface.RenderableSeries = model.RenderableSeries;
                surface.Annotations = model.Annotations;
                surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIXAxisDragModifier { DragMode = SCIAxisDragMode.Pan, ClipModeX = SCIClipMode.StretchAtExtents },
                    new SCIPinchZoomModifier { Direction = SCIDirection2D.XDirection },
                    new SCIZoomPanModifier(),
                    new SCIZoomExtentsModifier(),
                    new SCILegendModifier { ShowCheckBoxes = false }
                };

                vertiсalGroup.AddSurfaceToGroup(surface);
            }
        }

        private abstract class BasePaneModel
        {
            public SCIRenderableSeriesCollection RenderableSeries = new SCIRenderableSeriesCollection();
            public readonly SCIAnnotationCollection Annotations = new SCIAnnotationCollection();
            public readonly SCINumericAxis YAxis;
            public readonly string Title;

            protected BasePaneModel(string title, string yAxisTextFormatting, bool isFirstPane)
            {
                Title = title;
                YAxis = new SCINumericAxis
                {
                    AxisId = title,
                    AutoRange = SCIAutoRange.Always,
                    MinorsPerMajor = (uint)(isFirstPane ? 4 : 2),
                    MaxAutoTicks = (uint)(isFirstPane ? 8 : 4),
                    GrowBy = isFirstPane ? new SCIDoubleRange(0.05d, 0.05d) : new SCIDoubleRange(0d, 0d)
                };
                if (!string.IsNullOrWhiteSpace(yAxisTextFormatting))
                {
                    YAxis.TextFormatting = yAxisTextFormatting;
                }
            }
        }

        private class PricePaneModel : BasePaneModel
        {
			public PricePaneModel(PriceSeries prices) : base(PRICES, "$0.0000", true)
            {
                var stockPrices = new OhlcDataSeries<DateTime, double> { SeriesName = "EUR/USD" };
                stockPrices.Append(prices.TimeData, prices.OpenData, prices.HighData, prices.LowData, prices.CloseData);
                RenderableSeries.Add(new SCIFastCandlestickRenderableSeries
                {
                    DataSeries = stockPrices,
                    YAxisId = PRICES,
                    StrokeUpStyle = new SCISolidPenStyle(0xff52cc54, 1f),
                    FillUpBrushStyle = new SCISolidBrushStyle(0xa052cc54),
                    StrokeDownStyle = new SCISolidPenStyle(0xffe26565, 1f),
                    FillDownBrushStyle = new SCISolidBrushStyle(0xd0e26565)
                });

                var maLow = new XyDataSeries<DateTime, double> { SeriesName = "Low Line" };
                maLow.Append(prices.TimeData, prices.CloseData.MovingAverage(50));
                RenderableSeries.Add(new SCIFastLineRenderableSeries { DataSeries = maLow, StrokeStyle = new SCISolidPenStyle(0xFFFF3333, 1f), YAxisId = PRICES });

                var maHigh = new XyDataSeries<DateTime, double> { SeriesName = "High Line" };
                maHigh.Append(prices.TimeData, prices.CloseData.MovingAverage(200));
                RenderableSeries.Add(new SCIFastLineRenderableSeries { DataSeries = maHigh, StrokeStyle = new SCISolidPenStyle(0xFF33DD33, 1f), YAxisId = PRICES });

                Annotations.Add(new SCIAxisMarkerAnnotation { YAxisId = PRICES, Y1Value = stockPrices.YValues.ValueAt(stockPrices.Count - 1).ToComparable(), BackgroundBrush = new SCISolidBrushStyle(0xFFFF3333) });
                Annotations.Add(new SCIAxisMarkerAnnotation { YAxisId = PRICES, Y1Value = maLow.YValues.ValueAt(maLow.Count - 1).ToComparable(), BackgroundBrush = new SCISolidBrushStyle(0xFFFF3333) });
                Annotations.Add(new SCIAxisMarkerAnnotation { YAxisId = PRICES, Y1Value = maHigh.YValues.ValueAt(maHigh.Count - 1).ToComparable(), BackgroundBrush = new SCISolidBrushStyle(0xFF33DD33) });
            }
        }

        private class VolumePaneModel : BasePaneModel
        {
			public VolumePaneModel(PriceSeries prices) : base(VOLUME, "###E+0", false)
            {
                var volumePrices = new XyDataSeries<DateTime, double> { SeriesName = "Volume" };
                volumePrices.Append(prices.TimeData, prices.VolumeData.Select(x => (double)x));
                RenderableSeries.Add(new SCIFastColumnRenderableSeries
                {
                    DataSeries = volumePrices,
                    YAxisId = VOLUME,
                    FillBrushStyle = new SCISolidBrushStyle(UIColor.White),
                    StrokeStyle = new SCISolidPenStyle(UIColor.White, 1f)
                });

                Annotations.Add(new SCIAxisMarkerAnnotation { YAxisId = VOLUME, Y1Value = volumePrices.YValues.ValueAt(volumePrices.Count - 1).ToComparable() });
            }
        }

        private class RsiPaneModel : BasePaneModel
        {
			public RsiPaneModel(PriceSeries prices) : base(RSI, "0.0", false)
            {
                var rsiSeries = new XyDataSeries<DateTime, double> { SeriesName = "RSI" };
                var xData = prices.TimeData;
                var yData = prices.Rsi(14);

                rsiSeries.Append(xData, yData);
                RenderableSeries.Add(new SCIFastLineRenderableSeries { DataSeries = rsiSeries, YAxisId = RSI, StrokeStyle = new SCISolidPenStyle(0xFFC6E6FF, 1f) });
                Annotations.Add(new SCIAxisMarkerAnnotation { YAxisId = RSI, Y1Value = rsiSeries.YValues.ValueAt(rsiSeries.Count - 1).ToComparable() });
            }
        }

        private class MacdPaneModel : BasePaneModel
        {
			public MacdPaneModel(PriceSeries prices) : base(MACD, "0.00", false)
            {
                var macdPoints = prices.CloseData.Macd(12, 25, 9);

                var histogramSeries = new XyDataSeries<DateTime, double> { SeriesName = "Histogram" };
                histogramSeries.Append(prices.TimeData, macdPoints.Select(x => x.Divergence));
                RenderableSeries.Add(new SCIFastColumnRenderableSeries { DataSeries = histogramSeries, YAxisId = MACD, StrokeStyle = new SCISolidPenStyle(UIColor.White, 1f) });

                var macdSeries = new XyyDataSeries<DateTime, double> { SeriesName = "MACD" };
                macdSeries.Append(prices.TimeData, macdPoints.Select(x => x.Macd), macdPoints.Select(x => x.Signal));
                RenderableSeries.Add(new SCIFastBandRenderableSeries
                {
                    DataSeries = macdSeries,
                    YAxisId = MACD,
                    FillBrushStyle = new SCISolidBrushStyle(UIColor.Clear),
                    StrokeStyle = new SCISolidPenStyle(0xffe26565, 1f),
                    FillY1BrushStyle = new SCISolidBrushStyle(UIColor.Clear),
                    StrokeY1Style = new SCISolidPenStyle(0xff52cc54, 1f)
                });

                Annotations.Add(new SCIAxisMarkerAnnotation { YAxisId = MACD, Y1Value = histogramSeries.YValues.ValueAt(histogramSeries.Count - 1).ToComparable() });
                Annotations.Add(new SCIAxisMarkerAnnotation { YAxisId = MACD, Y1Value = macdSeries.YValues.ValueAt(macdSeries.Count - 1).ToComparable() });
            }
        }
    }
}