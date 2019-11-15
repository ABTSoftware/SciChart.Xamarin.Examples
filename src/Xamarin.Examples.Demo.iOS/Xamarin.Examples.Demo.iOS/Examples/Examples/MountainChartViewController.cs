using System;
using CoreGraphics;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Mountain Chart", description: "Creates a simple Mountain/Area chart", icon: ExampleIcon.MountainChart)]
    public class MountainChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCIDateAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var priceData = DataManager.Instance.GetPriceDataIndu();
			var dataSeries = new XyDataSeries<DateTime, double>();
            dataSeries.Append(priceData.TimeData, priceData.CloseData);

            var rSeries = new SCIFastMountainRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xAAFFC9A8, 2f),
                AreaStyle = new SCILinearGradientBrushStyle(new CGPoint(0.5, 0), new CGPoint(0.5, 1), 0xAAFF8D42, 0x88090E11),
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
				Surface.ChartModifiers.Add(CreateDefaultModifiers());

				SCIAnimations.SweepSeries(rSeries, 3, new SCICubicEase());
			}
		}
    }
}