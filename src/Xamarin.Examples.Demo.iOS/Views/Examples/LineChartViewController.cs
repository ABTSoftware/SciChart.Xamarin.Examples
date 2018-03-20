using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Line Chart", description: "Creates a simple line chart", icon: ExampleIcon.LineChart)]
    public class LineChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(1.1, 2.7) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var fourierSeries = DataManager.Instance.GetFourierSeries(1.0, 0.1);
            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(fourierSeries.XData, fourierSeries.YData);

            var renderSeries = new SCIFastLineRenderableSeries { DataSeries = dataSeries, StrokeStyle = new SCISolidPenStyle(0xFF279B27, 2f) };

            var animation = new SCISweepRenderableSeriesAnimation(3, SCIAnimationCurve.EaseOut);
            animation.StartAfterDelay(0.3f);

            renderSeries.AddAnimation(animation);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(renderSeries);

                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomPanModifier(),
                    new SCIPinchZoomModifier(),
                    new SCIZoomExtentsModifier()
                };
            }
        }
    }
}