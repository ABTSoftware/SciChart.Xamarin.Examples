using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Candlestick Chart")]
    public class CandlestickChartView : ExampleBaseView
    {
        public SCIChartSurface Surface;

        protected override void InitExample()
        {
            var data = DataManager.Instance.GetPriceDataIndu();

			var dataSeries = new OhlcDataSeries<DateTime, double>(TypeOfSeries.XCategory);
            dataSeries.Append(data.TimeData, data.OpenData, data.HighData, data.LowData, data.CloseData);

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCICategoryDateTimeAxis {IsXAxis = true, Style = axisStyle};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};

            var renderSeries = new SCIFastCandlestickRenderableSeries
            {
                DataSeries = dataSeries,
                Style =
                {
                    StrokeUpStyle = new SCIPenSolid(UIColor.Green, 1f),
                    StrokeDownStyle = new SCIPenSolid(UIColor.Red, 1f),
                    FillUpBrushStyle = new SCIBrushSolid(UIColor.Green),
                    FillDownBrushStyle= new SCIBrushSolid(UIColor.Red)
                }
            };

            Surface = new SCIChartSurface(this);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(renderSeries);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            });

            Surface.InvalidateElement();
        }
    }
}