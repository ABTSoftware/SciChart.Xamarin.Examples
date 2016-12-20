using System;
using System.Linq;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Bubble Chart")]
    public class BubbleChartView : ExampleBaseView
    {
        public SCIChartSurface Surface;

        protected override void InitExample()
        {
            var dataSeries = new SCIXyzDataSeries<DateTime, double, double>();
            var tradeDataSource = DataManager.Instance.GetTradeticks().ToArray();

            dataSeries.Append(
                tradeDataSource.Select(x => x.TradeDate).ToArray(),
                tradeDataSource.Select(x => x.TradePrice).ToArray(),
                tradeDataSource.Select(x => x.TradeSize).ToArray());

            //TODO Remove AxisId, should be default (DefaultAxisId)
            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            //TODO Add GrowBy = new DoubleRange(0, 0.1)
            var xAxis = new SCIDateTimeAxis {IsXAxis = true, AxisId = "xAxis", Style = axisStyle};
            //TODO Add GrowBy = new DoubleRange(0, 0.1)
            var yAxis = new SCINumericAxis {AxisId = "yAxis", Style = axisStyle};

            var lineSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                XAxisId = "xAxis",
                YAxisId = "yAxis",
                Style = {LinePen = new SCIPenSolid(0xFFFF3333, 1f)}
            };

            //var stops = new[] { 0, 0.95f, 1 };
            //var colors = new int[] { Color.Transparent, Resources.GetColor(Resource.Color.color_primary), Color.Transparent };
            //var gradientFill = new RadialGradientBrushStyle(0.5f, 0.5f, 0.5f, 0.5f, colors, stops, TileMode.Clamp);
            var bubbleSeries = new SCIBubbleRenderableSeries
            {
                DataSeries = dataSeries,
                XAxisId = "xAxis",
                YAxisId = "yAxis",
                ZScale = 3,
                //AutoZRange = false,
                Style =
                {
                    BubbleBrush =
                        new SCIBrushLinearGradient(0x7f090048, 0x30090048, SCILinearGradientDirection.Vertical)
                }
            };

            Surface = new SCIChartSurface(this);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(lineSeries);
            Surface.AttachRenderableSeries(bubbleSeries);

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