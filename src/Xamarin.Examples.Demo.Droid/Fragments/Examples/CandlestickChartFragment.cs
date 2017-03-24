using System;
using Android.Graphics;
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
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Candlestick Chart")]
    public class CandlestickChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var priceSeries = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>();
            dataSeries.Append(priceSeries.TimeData, priceSeries.OpenData, priceSeries.HighData, priceSeries.LowData,
                priceSeries.CloseData);

            var size = priceSeries.Count;
            var xAxis = new CategoryDateAxis(Activity) {VisibleRange = new DoubleRange(size - 30, size), GrowBy = new DoubleRange(0, 0.1)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0, 0.1), AutoRange = AutoRange.Always};

            var candlestickSeries = new FastCandlestickRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeUpStyle = new SolidPenStyle(Activity, Color.Argb(0xFF, 0x00, 0xAA, 0x00)),
                StrokeDownStyle = new SolidPenStyle(Activity, Color.Argb(0xFF, 0xFF, 0x00, 0x00)),
                FillUpBrushStyle = new SolidBrushStyle(Color.Argb(0x88, 0x00, 0xAA, 0x00)),
                FillDownBrushStyle = new SolidBrushStyle(Color.Argb(0x88, 0xFF, 0x00, 0x00))
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