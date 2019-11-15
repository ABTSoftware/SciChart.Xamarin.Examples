using System;
using System.Linq;
using UIKit;
using CoreGraphics;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Realtime Ticking Stock Charts", description: "Creates a realtime stock chart which ticks and updates, simulating live a market", icon: ExampleIcon.RealTime)]
    public class CreateRealtimeTickingStockChartsViewController : CustomLayoutViewController<RealtimeTickingStockChartsLayout>
    {
        private const int DefaultPointCount = 150;
        private const uint SmaSeriesColor = 0xFFFFA500;
        private const uint StrokeUpColor = 0xFF00AA00;
        private const uint StrokeDownColor = 0xFFFF0000;
        private const float StrokeThickness = 1.5f;

        private readonly OhlcDataSeries<DateTime, double> _ohlcDataSeries = new OhlcDataSeries<DateTime, double> { SeriesName = "Price Series" };
        private readonly XyDataSeries<DateTime, double> _xyDataSeries = new XyDataSeries<DateTime, double> { SeriesName = "50-Period SMA" };

        private SCIAxisMarkerAnnotation _smaAxisMarker;
        private SCIAxisMarkerAnnotation _ohlcAxisMarker;

        // Create data service to populate the data
        private readonly IMarketDataService _marketDataService = new MarketDataService(new DateTime(2000, 08, 01, 12, 00, 00), 5, 20);
        private readonly MovingAverage _sma50 = new MovingAverage(50);
        private PriceBar _lastPrice;

        public SCIChartSurface MainSurface => Layout.MainSurfaceView;
        public SCIChartSurface OverviewSurface => Layout.OverviewSurfaceView;

        protected override void InitExample()
        {
            InitData(_marketDataService);
            CreateMainPriceChart();

            SCIBoxAnnotation overviewAnnotation0, overviewAnnotation1;
            CreateOverviewChart(out overviewAnnotation0, out overviewAnnotation1);

            // On zoom and pan of the main price chart, we want to update the position of annotations on the second chart
            // so that you can see the area of the data zoomed in (called an 'overview')
            var xAxis = MainSurface.XAxes[0];
            xAxis.VisibleRangeChanged += (IISCIAxisCore axis, IISCIRange oldrange, IISCIRange newRange, bool isAnimating) =>
            {
                // Left annotation starts on the left edge of the chart and ends on the right edge of the visible area 
                overviewAnnotation0.X1Value = OverviewSurface.XAxes[0].VisibleRange.MinAsDouble;
                overviewAnnotation0.X2Value = xAxis.VisibleRange.MinAsDouble;

                // Right annotation starts on the right edge of visible area and ends on the right edge of all the data 
                overviewAnnotation1.X1Value = xAxis.VisibleRange.MaxAsDouble;
                overviewAnnotation1.X2Value = OverviewSurface.XAxes[0].VisibleRange.MaxAsDouble;
            };
        }

        private void InitData(IMarketDataService marketDataService)
        {
            var prices = marketDataService.GetHistoricalData(DefaultPointCount);
            _lastPrice = prices.Last();

            // Populate data series with some data
            _ohlcDataSeries.Append(prices.Select(x => x.DateTime), prices.Select(x => x.Open), prices.Select(x => x.High), prices.Select(x => x.Low), prices.Select(x => x.Close));
            _xyDataSeries.Append(prices.Select(x => x.DateTime), prices.Select(y => _sma50.Push(y.Close).Current));

            _marketDataService.SubscribePriceUpdate(price => { InvokeOnMainThread(() => OnNewPrice(price)); });
        }

        private void CreateMainPriceChart()
        {
            // Create an XAxis and YAxis for our chart
            var xAxis = new SCICategoryDateAxis { GrowBy = new SCIDoubleRange(0, 0.1), DrawMajorGridLines = false };
            var yAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };

            // Create RenderableSeries to render the data 
            var ohlcSeries = new SCIFastOhlcRenderableSeries { DataSeries = _ohlcDataSeries };
            var movingAverage50Series = new SCIFastLineRenderableSeries { DataSeries = _xyDataSeries, StrokeStyle = new SCISolidPenStyle(0xFFFF6600, 1.0f) };

            // Create axis markers annotations to show the last values on real-time chart
            _smaAxisMarker = new SCIAxisMarkerAnnotation { Y1Value = 0d, YAxisId = yAxis.AxisId, BackgroundBrush = new SCISolidBrushStyle(SmaSeriesColor) };
            _ohlcAxisMarker = new SCIAxisMarkerAnnotation { Y1Value = 0d, YAxisId = yAxis.AxisId, BackgroundBrush = new SCISolidBrushStyle(StrokeUpColor) };

            using (MainSurface.SuspendUpdates())
            {
                MainSurface.XAxes.Add(xAxis);
                MainSurface.YAxes.Add(yAxis);
                MainSurface.RenderableSeries.Add(ohlcSeries);
                MainSurface.RenderableSeries.Add(movingAverage50Series);
                MainSurface.Annotations.Add(_ohlcAxisMarker);
                MainSurface.Annotations.Add(_smaAxisMarker);

                // Populate some pinch and touch interactions. Pinch to zoom, drag to pan and double-tap to zoom extents 
                MainSurface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIXAxisDragModifier(),
                    new SCIZoomPanModifier { Direction = SCIDirection2D.XDirection },
                    new SCIZoomExtentsModifier(),
                    new SCILegendModifier
                    {
                        Orientation = SCIOrientation.Horizontal,
                        Position = SCIAlignment.Bottom,
                        Margins = new UIEdgeInsets(10, 10, 10, 10)
                    }
                };
            }
        }

        private void CreateOverviewChart(out SCIBoxAnnotation leftAreaAnnotation, out SCIBoxAnnotation rightAreaAnnotation)
        {
            // Create an XAxis and YAxis for our chart
            var xAxis1 = new SCICategoryDateAxis { AutoRange = SCIAutoRange.Always };
            var yAxis1 = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), AutoRange = SCIAutoRange.Always };

            // Create the mountain chart for the overview , using the same price data but zoomed out 
            var mountainSeries = new SCIFastMountainRenderableSeries
            {
                DataSeries = _ohlcDataSeries,
                AreaStyle = new SCILinearGradientBrushStyle(new CGPoint(0.5, 0), new CGPoint(0.5, 1), 0x883a668f, 0xff20384f)
            };

            // Create some annotations to visualize the selected area on the main price chart 
            leftAreaAnnotation = new SCIBoxAnnotation { Y1Value = 0, Y2Value = 1, CoordinateMode = SCIAnnotationCoordinateMode.RelativeY, FillBrush = new SCISolidBrushStyle(0x33FFFFFF) };
            rightAreaAnnotation = new SCIBoxAnnotation { Y1Value = 0, Y2Value = 1, CoordinateMode = SCIAnnotationCoordinateMode.RelativeY, FillBrush = new SCISolidBrushStyle(0x33FFFFFF), };

            // Populate the chart with Axis, RenderableSeries. The chart automatically updates when any property changes 
            using (OverviewSurface.SuspendUpdates())
            {
                OverviewSurface.XAxes.Add(xAxis1);
                OverviewSurface.YAxes.Add(yAxis1);
                OverviewSurface.RenderableSeries.Add(mountainSeries);

                OverviewSurface.Annotations.Add(leftAreaAnnotation);
                OverviewSurface.Annotations.Add(rightAreaAnnotation);
            }
        }

        private void OnNewPrice(PriceBar price)
        {
            // Update the last price, or append? 
            double smaLastValue;
            if (_lastPrice.DateTime == price.DateTime)
            {
                _ohlcDataSeries.Update(_ohlcDataSeries.Count - 1, price.Open, price.High, price.Low, price.Close);

                smaLastValue = _sma50.Update(price.Close).Current;
                _xyDataSeries.UpdateYAt(_xyDataSeries.Count - 1, smaLastValue);
            }
            else
            {
                _ohlcDataSeries.Append(price.DateTime, price.Open, price.High, price.Low, price.Close);

                smaLastValue = _sma50.Push(price.Close).Current;
                _xyDataSeries.Append(price.DateTime, smaLastValue);

                // If the latest appending point is inside the viewport (i.e. not off the edge of the screen)
                // then scroll the viewport 1 bar, to keep the latest bar at the same place
                var visibleRange = MainSurface.XAxes[0].VisibleRange;
                if (visibleRange.Max.ToDouble() > _ohlcDataSeries.Count)
                {
                    visibleRange.SetMinMaxDouble(visibleRange.MinAsDouble + 1, visibleRange.MaxAsDouble + 1);
                }
            }

            var color = price.Close >= price.Open ? StrokeUpColor : StrokeDownColor;
            _ohlcAxisMarker.BackgroundBrush = new SCISolidBrushStyle(color);
            _ohlcAxisMarker.Y1Value = price.Close;
            _smaAxisMarker.Y1Value = smaLastValue;

            _lastPrice = price;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            _marketDataService.ClearSubscriptions();
        }
    }
}