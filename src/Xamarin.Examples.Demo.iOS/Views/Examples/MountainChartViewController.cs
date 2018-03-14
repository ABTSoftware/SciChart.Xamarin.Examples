using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Mountain Chart", description: "Creates a simple Mountain/Area chart", icon: ExampleIcon.MountainChart)]
    public class MountainChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            var xAxis = new SCIDateTimeAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var priceData = DataManager.Instance.GetPriceDataIndu();
            var dataSeries = new XyDataSeries<DateTime, double> { DataDistributionCalculator = new SCIUserDefinedDistributionCalculator() };
            dataSeries.Append(priceData.TimeData, priceData.CloseData);

            var renderableSeries = new SCIFastMountainRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xAAFFC9A8, 2f),
                AreaStyle = new SCILinearGradientBrushStyle(0xAAFF8D42, 0x88090E11, SCILinearGradientDirection.Horizontal),
            };

            var animation = new SCIWaveRenderableSeriesAnimation(3, SCIAnimationCurve.EaseOut);
            animation.StartAfterDelay(0.3f);
            renderableSeries.AddAnimation(animation);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(renderableSeries);
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