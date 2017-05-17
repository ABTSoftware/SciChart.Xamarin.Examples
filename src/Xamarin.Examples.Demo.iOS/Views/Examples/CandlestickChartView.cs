using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Candlestick Chart", description:"A simple candlestick chart with Up/Down bars", icon: ExampleIcon.CandlestickChart)]
    public class CandlestickChartView : ExampleBaseView
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleViewLayout;

        protected override void UpdateFrame()
        {
            _exampleViewLayout.SciChartSurfaceView.Frame = _exampleViewLayout.Frame;
            _exampleViewLayout.SciChartSurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            Surface = new SCIChartSurface(_exampleViewLayout.SciChartSurfaceView);

            var priceSeries = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>(TypeOfSeries.XCategory);
            dataSeries.Append(priceSeries.TimeData, priceSeries.OpenData, priceSeries.HighData, priceSeries.LowData, priceSeries.CloseData);

            var size = priceSeries.Count;
            var xAxis = new SCICategoryDateTimeAxis {VisibleRange = new SCIDoubleRange(size - 30, size), GrowBy = new SCIDoubleRange(0, 0.1)};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0, 0.1), AutoRange = SCIAutoRange.Always};

            var renderSeries = new SCIFastCandlestickRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeUpStyle = new SCISolidPenStyle(0xFF00AA00, 1f),
                StrokeDownStyle = new SCISolidPenStyle(0xFFFF0000, 1f),
                FillUpBrushStyle = new SCISolidBrushStyle(0x8800AA00),
                FillDownBrushStyle = new SCISolidBrushStyle(0x88FF0000)
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(renderSeries);

            Surface.ChartModifiers = new SCIChartModifierCollection(
				new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            );

            Surface.InvalidateElement();
        }
    }
}