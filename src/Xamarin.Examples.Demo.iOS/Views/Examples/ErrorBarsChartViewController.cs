using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("ErrorBars Chart", description: "Demonstrates Error Bars showing point uncertainty", icon: ExampleIcon.ErrorBars)]
    public class ErrorBarsChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis();
            var yAxis = new SCINumericAxis();

            var fourierSeries = DataManager.Instance.GetFourierSeries(1.0, 0.1, 5.0, 5.15);

            var dataSeries0 = new HlDataSeries<double, double>();
            var dataSeries1 = new HlDataSeries<double, double>();

            FillDataSeries(dataSeries0, fourierSeries, 1.0);
            FillDataSeries(dataSeries1, fourierSeries, 1.3);

            const uint color = 0xFFC6E6FF;

            var strokeStyle = new SCISolidPenStyle(0xFFC6E6FF.ToColor(), 1f);

            var errorBars0 = new SCIFastErrorBarsRenderableSeries
            {
                DataSeries = dataSeries0,
                StrokeStyle = strokeStyle,
                ErrorDirection = SCIErrorBarDirection.Vertical,
                ErrorType = SCIErrorBarType.Absolute
            };
            errorBars0.AddAnimation(new SCIScaleRenderableSeriesAnimation(3, SCIAnimationCurve.EaseOutElastic));

            var lineSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries0,
                StrokeStyle = strokeStyle,
                PointMarker = new SCIEllipsePointMarker
                {
                    FillStyle = new SCISolidBrushStyle(color),
                    Width = 5,
                    Height = 5
                }
            };
            lineSeries.AddAnimation(new SCIScaleRenderableSeriesAnimation(3, SCIAnimationCurve.EaseOutElastic));

            var errorBars1 = new SCIFastErrorBarsRenderableSeries
            {
                DataSeries = dataSeries1,
                StrokeStyle = strokeStyle,
                DataPointWidth = 0.7f,
                ErrorDirection = SCIErrorBarDirection.Vertical,
                ErrorType = SCIErrorBarType.Absolute
            };
            errorBars1.AddAnimation(new SCIScaleRenderableSeriesAnimation(3, SCIAnimationCurve.EaseOutElastic));

            var scatterSeries = new SCIXyScatterRenderableSeries
            {
                DataSeries = dataSeries1,
                PointMarker = new SCIEllipsePointMarker
                {
                    FillStyle = new SCISolidBrushStyle(ColorUtil.Transparent),
                    StrokeStyle = strokeStyle,
                    Width = 7,
                    Height = 7
                }
            };
            scatterSeries.AddAnimation(new SCIScaleRenderableSeriesAnimation(3, SCIAnimationCurve.EaseOutElastic));

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries = new SCIRenderableSeriesCollection
                {
                    errorBars0,
                    lineSeries,
                    errorBars1,
                    scatterSeries
                };
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomPanModifier(),
                    new SCIPinchZoomModifier(),
                    new SCIZoomExtentsModifier()
                };
            }
        }

        private static void FillDataSeries(HlDataSeries<double, double> dataSeries, DoubleSeries sourceData, double scale)
        {
            var random = new Random(42);

            var xData = sourceData.XData;
            var yData = sourceData.YData;

            for (var i = 0; i < sourceData.Count; i++)
            {
                dataSeries.Append(xData[i], yData[i] + scale, random.NextDouble() * 0.2, random.NextDouble() * 0.2);
            }
        }
    }
}