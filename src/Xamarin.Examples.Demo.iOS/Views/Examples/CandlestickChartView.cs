using System;
using System.Linq;
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

            var dataSeries = new SCIOhlcDataSeries<DateTime, double>();
            dataSeries.Append(data.TimeData, data.OpenData, data.HighData, data.LowData, data.CloseData);

            //TODO Remove AxisId, should be default (DefaultAxisId)
            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCICategoryDateTimeAxis{ IsXAxis = true, AxisId = "xAxis", Style = axisStyle };
            //TODO Add GrowBy = new DoubleRange(0.1, 0.1)
            var yAxis = new SCINumericAxis { AxisId = "yAxis", Style = axisStyle };

            var renderSeries = new SCIFastCandlestickRenderableSeries
            {
                DataSeries = dataSeries,
                XAxisId = "xAxis",
                YAxisId = "yAxis",
                Style =
                {
                    UpWickPen = new SCIPenSolid(UIColor.Green, 1f),
                    DownWickPen = new SCIPenSolid(UIColor.Red, 1f),
                    UpBodyBrush = new SCIBrushSolid(UIColor.Green),
                    DownBodyBrush= new SCIBrushSolid(UIColor.Red)
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