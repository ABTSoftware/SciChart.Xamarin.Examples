using System;
using System.Linq;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Bubble Chart")]
    public class BubbleChartView : ExampleBaseView
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

            var dataSeries = new XyzDataSeries<DateTime, double, double>();
            var tradeDataSource = DataManager.Instance.GetTradeticks().ToArray();

            dataSeries.Append(
                tradeDataSource.Select(x => x.TradeDate).ToArray(),
                tradeDataSource.Select(x => x.TradePrice).ToArray(),
                tradeDataSource.Select(x => x.TradeSize).ToArray());

            var xAxis = new SCIDateTimeAxis {GrowBy = new SCIDoubleRange(0.0, 0.1)};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0, 0.1)};

            var lineSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                Style = {LinePen = new SCISolidPenStyle(0xFFFF3333, 1f)}
            };

            //var stops = new[] { 0, 0.95f, 1 };
            //var colors = new int[] { Color.Transparent, Resources.GetColor(Resource.Color.color_primary), Color.Transparent };
            //var gradientFill = new RadialGradientBrushStyle(0.5f, 0.5f, 0.5f, 0.5f, colors, stops, TileMode.Clamp);
            var bubbleSeries = new SCIBubbleRenderableSeries
            {
                DataSeries = dataSeries,
                ZScaleFactor = 1,
                AutoZRange = false,
                Style =
                {
                    BubbleBrush = new SCILinearGradientBrushStyle(0x7f090048, 0x30090048, SCILinearGradientDirection.Vertical)
                }
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(lineSeries);
            Surface.RenderableSeries.Add(bubbleSeries);

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