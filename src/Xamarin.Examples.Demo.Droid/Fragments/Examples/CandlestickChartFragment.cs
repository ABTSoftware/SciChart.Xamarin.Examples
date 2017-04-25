using System;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Candlestick Chart", description:"Creates a simple Candlestick Chart")]
    public class CandlestickChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var priceSeries = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>();
            dataSeries.Append(priceSeries.TimeData, priceSeries.OpenData, priceSeries.HighData, priceSeries.LowData, priceSeries.CloseData);

            var size = priceSeries.Count;
            var xAxis = new CategoryDateAxis(Activity) {VisibleRange = new DoubleRange(size - 30, size), GrowBy = new DoubleRange(0, 0.1)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0, 0.1), AutoRange = AutoRange.Always};

            var candlestickSeries = new FastCandlestickRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeUpStyle = new SolidPenStyle(0xFF00AA00, 1.ToDip(Activity)),
                StrokeDownStyle = new SolidPenStyle(0xFFFF0000, 1.ToDip(Activity)),
                FillUpBrushStyle = new SolidBrushStyle(0x8800AA00),
                FillDownBrushStyle = new SolidBrushStyle(0x88FF0000)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(candlestickSeries);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };
            }
        }
    }
}