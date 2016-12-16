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
            var data = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>();
            dataSeries.Append(data.TimeData, data.OpenData, data.HighData, data.LowData, data.CloseData);

            var xAxis = new CategoryDateAxis(Activity);
            var yAxis = new NumericAxis(Activity)
            {
                GrowBy = new DoubleRange(0, 0.1)
            };

            var rs = new FastCandlestickRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeUpStyle = new PenStyle.Builder(Activity).WithColor(Color.Green).Build(),
                StrokeDownStyle = new PenStyle.Builder(Activity).WithColor(Color.Red).Build(),
                FillUpBrushStyle = new SolidBrushStyle(Color.Green),
                FillDownBrushStyle = new SolidBrushStyle(Color.Red)
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(rs);

            Surface.ChartModifiers = new ChartModifierCollection()
            {
                new ZoomPanModifier(),
                new PinchZoomModifier(),
                new ZoomExtentsModifier(),
            };
        }
    }
}