using System;
using SciChart.Examples.Demo.Data;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    //[ExampleDefinition("Fan Chart", description: "Uses Band-Series to generate a Fan-Chart", icon: ExampleIcon.Fan)]
    public class FanChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            var xAxis = new SCIDateTimeAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), TextFormatting = "dd/MM/YYYY" };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var dataSeries = new XyDataSeries<DateTime, double> { DataDistributionCalculator = new SCIUserDefinedDistributionCalculator() };
            var xyyDataSeries = new XyyDataSeries<DateTime, double> { DataDistributionCalculator = new SCIUserDefinedDistributionCalculator() };
            var xyyDataSeries1 = new XyyDataSeries<DateTime, double> { DataDistributionCalculator = new SCIUserDefinedDistributionCalculator() };
            var xyyDataSeries2 = new XyyDataSeries<DateTime, double> { DataDistributionCalculator = new SCIUserDefinedDistributionCalculator() };

            DataManager.Instance.GetFanData(10, result =>
            {
                dataSeries.Append(result.Date, result.ActualValue);
                xyyDataSeries.Append(result.Date, result.MaxValue, result.MinValue);
                xyyDataSeries1.Append(result.Date, result.Value1, result.Value4);
                xyyDataSeries2.Append(result.Date, result.Value2, result.Value3);
            });

            var dataRenderSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(UIColor.Red, 1.0f)
            };

            var animation = new SCIWaveRenderableSeriesAnimation(3, SCIAnimationCurve.EaseOut);
            animation.StartAfterDelay(0.3f);
            dataRenderSeries.AddAnimation(animation);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);

                Surface.RenderableSeries.Add(createRenderableSeriesWith(xyyDataSeries));
                Surface.RenderableSeries.Add(createRenderableSeriesWith(xyyDataSeries1));
                Surface.RenderableSeries.Add(createRenderableSeriesWith(xyyDataSeries2));
                Surface.RenderableSeries.Add(dataRenderSeries);

                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomPanModifier(),
                    new SCIPinchZoomModifier(),
                    new SCIZoomExtentsModifier()
                };
            }
        }

        SCIFastBandRenderableSeries createRenderableSeriesWith(SCIXyyDataSeries dataSeries)
        {
            var renderebleDataSeries = new SCIFastBandRenderableSeries
            {
                DataSeries = dataSeries,
                FillBrushStyle = new SCISolidBrushStyle(new UIColor(1.0f, 0.4f, 0.4f, 0.5f)),
                FillY1BrushStyle = new SCISolidBrushStyle(new UIColor(1.0f, 0.4f, 0.4f, 0.5f)),
                StrokeStyle = new SCISolidPenStyle(UIColor.Green, 0.5f),
                StrokeY1Style = new SCISolidPenStyle(UIColor.Clear, 0.5f),
            };

            return renderebleDataSeries;
        }
    }
}