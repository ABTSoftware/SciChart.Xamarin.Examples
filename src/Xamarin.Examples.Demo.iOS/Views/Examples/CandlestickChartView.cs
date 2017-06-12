using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Candlestick Chart", description: "A simple candlestick chart with Up/Down bars", icon: ExampleIcon.CandlestickChart)]
    public class CandlestickChartView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        protected override void UpdateFrame()
        {
            Surface.TranslatesAutoresizingMaskIntoConstraints = false;

            NSLayoutConstraint constraintRight = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint constraintLeft = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint constraintTop = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 0);
            NSLayoutConstraint constraintBottom = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0);

            this.AddConstraint(constraintRight);
            this.AddConstraint(constraintLeft);
            this.AddConstraint(constraintTop);
            this.AddConstraint(constraintBottom);
        }

        protected override void InitExampleInternal()
        {
            var priceSeries = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>();
            dataSeries.Append(priceSeries.TimeData, priceSeries.OpenData, priceSeries.HighData, priceSeries.LowData, priceSeries.CloseData);

            var size = priceSeries.Count;
            var xAxis = new SCICategoryDateTimeAxis { VisibleRange = new SCIDoubleRange(size - 30, size), GrowBy = new SCIDoubleRange(0, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0, 0.1), AutoRange = SCIAutoRange.Always };

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
        }
    }
}