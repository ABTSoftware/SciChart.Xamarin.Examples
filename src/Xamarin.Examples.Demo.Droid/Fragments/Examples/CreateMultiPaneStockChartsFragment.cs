using System;
using System.Linq;
using Android.Content;
using Android.Views;
using SciChart.Charting;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.Rendering;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Multi-Pane Stock Charts", description: "Creates an example with static multi-pane stock chart with Indicator and Volume panes", icon: ExampleIcon.CandlestickChart)]
    public class CreateMultiPaneStockChartsFragment : ExampleBaseFragment
    {
        private static readonly string VOLUME = "Volume";
        private static readonly string PRICES = "Prices";
        private static readonly string RSI = "RSI";
        private static readonly string MACD = "MACD";

        public SciChartSurface PriceChart => View.FindViewById<SciChartSurface>(Resource.Id.priceChart);
        public SciChartSurface MacdChart => View.FindViewById<SciChartSurface>(Resource.Id.macdChart);
        public SciChartSurface RsiChart => View.FindViewById<SciChartSurface>(Resource.Id.rsiChart);
        public SciChartSurface VolumeChart => View.FindViewById<SciChartSurface>(Resource.Id.volumeChart);

        private readonly SciChartVerticalGroup _verticalGroup = new SciChartVerticalGroup();

        public override int ExampleLayoutId => Resource.Layout.Example_Multipane_Stock_Charts_Fragment;

        protected override void InitExample()
        {
            var priceData = DataManager.Instance.GetPriceDataEurUsd();

            var pricePaneModel = new PricePaneModel(Activity, priceData);
            var macdPaneModel = new MacdPaneModel(Activity, priceData);
            var rsiPaneModel = new RsiPaneModel(Activity, priceData);
            var volumePaneModel = new VolumePaneModel(Activity, priceData);

            InitChart(PriceChart, pricePaneModel, true);
            InitChart(MacdChart, macdPaneModel, false);
            InitChart(RsiChart, rsiPaneModel, false);
            InitChart(VolumeChart, volumePaneModel, false);
        }

        private void InitChart(SciChartSurface surface, BasePaneModel model, bool isMainPain)
        {
            var xAxis = new CategoryDateAxis(Activity) {Visibility = (int)(isMainPain ? ViewStates.Visible : ViewStates.Gone), GrowBy = new DoubleRange(0, 0.05)};

            using (surface.SuspendUpdates())
            {
                surface.XAxes.Add(xAxis);
                surface.YAxes.Add(model.YAxis);
                surface.RenderableSeries = model.RenderableSeries;
                surface.Annotations = model.Annotations;

                surface.ChartModifiers = new ChartModifierCollection
                {
                    new ModifierGroup
                    {
                        MotionEventGroup = "ModifiersSharedEventsGroup",
                        ChildModifiers = new ChartModifierCollection
                        {
                            new XAxisDragModifier {DragMode = AxisDragModifierBase.AxisDragMode.Pan, ClipModeX = ClipMode.StretchAtExtents}.WithReceiveHandledEvents(true),
                            new PinchZoomModifier {Direction = Direction2D.XDirection}.WithReceiveHandledEvents(true),
                            new ZoomPanModifier().WithReceiveHandledEvents(true),
                            new ZoomExtentsModifier().WithReceiveHandledEvents(true),
                            new LegendModifier(Activity).WithShowCheckBoxes(false),
                        }
                    }.WithReceiveHandledEvents(true)
                };
            }

            _verticalGroup.AddSurfaceToGroup(surface);
        }

        private abstract class BasePaneModel
        {
            public readonly RenderableSeriesCollection RenderableSeries = new RenderableSeriesCollection();
            public readonly AnnotationCollection Annotations = new AnnotationCollection();
            public readonly NumericAxis YAxis;
            public readonly string Title;

            protected BasePaneModel(Context context, string title, string yAxisTextFormatting, bool isFirstPane)
            {
                Title = title;
                YAxis = new NumericAxis(context)
                {
                    AxisId = title,
                    TextFormatting = yAxisTextFormatting,
                    AutoRange = AutoRange.Always,
                    MinorsPerMajor = isFirstPane ? 4 : 2,
                    MaxAutoTicks = isFirstPane ? 8 : 4,
                    GrowBy = isFirstPane ? new DoubleRange(0.05d, 0.05d) : new DoubleRange(0d, 0d)
                };
            }

            protected void AddRenderableSeries(BaseRenderableSeries renderableSeries)
            {
                renderableSeries.ClipToBounds = true;
                RenderableSeries.Add(renderableSeries);
            }
        }

        private class PricePaneModel : BasePaneModel
        {
            public PricePaneModel(Context context, PriceSeries prices) : base(context, PRICES, "$0.0000", true)
            {
                var stockPrices = new OhlcDataSeries<DateTime, double> {SeriesName = "EUR/USD"};
                stockPrices.Append(prices.TimeData, prices.OpenData, prices.HighData, prices.LowData, prices.CloseData);
                AddRenderableSeries(new FastCandlestickRenderableSeries {DataSeries = stockPrices, YAxisId = PRICES});

                var maLow = new XyDataSeries<DateTime, double> {SeriesName = "Low Line" };
                maLow.Append(prices.TimeData, prices.CloseData.MovingAverage(50));
                AddRenderableSeries(new FastLineRenderableSeries {DataSeries = maLow, StrokeStyle = new SolidPenStyle(0xFFFF3333, 1f.ToDip(context)), YAxisId = PRICES});

                var maHigh = new XyDataSeries<DateTime, double> {SeriesName = "High Line" };
                maHigh.Append(prices.TimeData, prices.CloseData.MovingAverage(200));
                AddRenderableSeries(new FastLineRenderableSeries {DataSeries = maHigh, StrokeStyle = new SolidPenStyle(0xFF33DD33, 1f.ToDip(context)), YAxisId = PRICES});

                var priceMarker = new AxisMarkerAnnotation(context) {Y1 = (Java.Lang.IComparable)stockPrices.YValues.Get(stockPrices.Count - 1), YAxisId = PRICES};
                priceMarker.SetBackgroundColor(0xFFFF3333.ToColor());

                var maLowMarker = new AxisMarkerAnnotation(context) {Y1 = (Java.Lang.IComparable)maLow.YValues.Get(maLow.Count - 1), YAxisId = PRICES};
                maLowMarker.SetBackgroundColor(0xFFFF3333.ToColor());

                var maHighMarker = new AxisMarkerAnnotation(context) {Y1 = (Java.Lang.IComparable)maHigh.YValues.Get(maHigh.Count - 1), YAxisId = PRICES};
                maHighMarker.SetBackgroundColor(0xFF33DD33.ToColor());

                Annotations.Add(priceMarker);
                Annotations.Add(maLowMarker);
                Annotations.Add(maHighMarker);
            }
        }

        private class VolumePaneModel : BasePaneModel
        {
            public VolumePaneModel(Context context, PriceSeries prices) : base(context, VOLUME, "###E+0", false)
            {
                var volumePrices = new XyDataSeries<DateTime, double> {SeriesName = "Volume"};
                volumePrices.Append(prices.TimeData, prices.VolumeData.Select(x => (double)x));
                AddRenderableSeries(new FastColumnRenderableSeries {DataSeries = volumePrices, YAxisId = VOLUME});

                Annotations.Add(new AxisMarkerAnnotation(context) {Y1 = (Java.Lang.IComparable)volumePrices.YValues.Get(volumePrices.Count - 1), YAxisId = VOLUME});
            }
        }

        private class RsiPaneModel : BasePaneModel
        {
            public RsiPaneModel(Context context, PriceSeries prices) : base(context, RSI, "0.0", false)
            {
                var rsiSeries = new XyDataSeries<DateTime, double> {SeriesName = "RSI"};
                var xData = prices.TimeData;
                var yData = prices.Rsi(14);

                rsiSeries.Append(xData, yData);
                AddRenderableSeries(new FastLineRenderableSeries  {DataSeries = rsiSeries, YAxisId = RSI});

                Annotations.Add(new AxisMarkerAnnotation(context) {Y1 = (Java.Lang.IComparable)rsiSeries.YValues.Get(rsiSeries.Count - 1), YAxisId = RSI});
            }
        }

        private class MacdPaneModel : BasePaneModel
        {
            public MacdPaneModel(Context context, PriceSeries prices) : base(context, MACD, "0.0", false)
            {
                var macdPoints = prices.CloseData.Macd(12, 25, 9);

                var histogramSeries = new XyDataSeries<DateTime, double> {SeriesName = "Histogram"};
                histogramSeries.Append(prices.TimeData, macdPoints.Select(x => x.Divergence));
                AddRenderableSeries(new FastColumnRenderableSeries {DataSeries = histogramSeries, YAxisId = MACD});

                var macdSeries = new XyyDataSeries<DateTime, double> {SeriesName = "MACD"};
                macdSeries.Append(prices.TimeData, macdPoints.Select(x => x.Macd), macdPoints.Select(x => x.Signal));
                AddRenderableSeries(new FastBandRenderableSeries {DataSeries = macdSeries, YAxisId = MACD});

                Annotations.Add(new AxisMarkerAnnotation(context) {Y1 = (Java.Lang.IComparable)histogramSeries.YValues.Get(histogramSeries.Count - 1), YAxisId = MACD});
                Annotations.Add(new AxisMarkerAnnotation(context) {Y1 = (Java.Lang.IComparable)macdSeries.YValues.Get(macdSeries.Count - 1), YAxisId = MACD});
            }
        }
    }
}
