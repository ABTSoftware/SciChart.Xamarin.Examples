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
    [ExampleDefinition("Bubble Chart", description: "Generates a Line and Bubble series chart in code", icon: ExampleIcon.BubbleChart)]
    public class BubbleChartView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        protected override void UpdateFrame()
        {
            ExampleViewLayout.SciChartSurface.Frame = ExampleViewLayout.Frame;
            ExampleViewLayout.SciChartSurface.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            var xAxis = new SCIDateTimeAxis { GrowBy = new SCIDoubleRange(0.0, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0, 0.1) };

            var dataSeries = new XyzDataSeries<DateTime, double, double>();
            var tradeDataSource = DataManager.Instance.GetTradeticks().ToArray();

            dataSeries.Append(
                tradeDataSource.Select(x => x.TradeDate).ToArray(),
                tradeDataSource.Select(x => x.TradePrice).ToArray(),
                tradeDataSource.Select(x => x.TradeSize).ToArray());

            var lineSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFFFF3333, 1f)
            };

            var bubbleSeries = new SCIBubbleRenderableSeries
            {
                DataSeries = dataSeries,
                ZScaleFactor = 1,
                AutoZRange = false,
                BubbleBrushStyle = new SCISolidBrushStyle(0x77CCCCCC),
                StrokeStyle = new SCISolidPenStyle(0xCCCCCC, 2f)
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(lineSeries);
            Surface.RenderableSeries.Add(bubbleSeries);

            Surface.ChartModifiers = new SCIChartModifierCollection(
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            );

            Surface.InvalidateElement();
        }
    }
}