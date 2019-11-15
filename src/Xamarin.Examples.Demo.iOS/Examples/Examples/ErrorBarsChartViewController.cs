using System;
using CoreGraphics;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("ErrorBars Chart", description: "Demonstrates Error Bars showing point uncertainty", icon: ExampleIcon.ErrorBars)]
    public class ErrorBarsChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var dataSeries0 = new HlDataSeries<double, double>();
            var dataSeries1 = new HlDataSeries<double, double>();

            var fourierSeries = DataManager.Instance.GetFourierSeries(1.0, 0.1, 5.0, 5.15);
            FillDataSeries(dataSeries0, fourierSeries, 1.0);
            FillDataSeries(dataSeries1, fourierSeries, 1.3);

            const uint color = 0xFFC6E6FF;
            var strokeStyle = new SCISolidPenStyle(0xFFC6E6FF, 1f);

            var errorBars0 = new SCIFastErrorBarsRenderableSeries
            {
                DataSeries = dataSeries0,
                StrokeStyle = strokeStyle,
                ErrorDirection = SCIErrorDirection.Vertical,
                ErrorType = SCIErrorType.Absolute
            };
            var lineSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries0,
                StrokeStyle = strokeStyle,
                PointMarker = new SCIEllipsePointMarker { FillStyle = new SCISolidBrushStyle(color), Size = new CGSize(5, 5) }
            };

            var errorBars1 = new SCIFastErrorBarsRenderableSeries
            {
                DataSeries = dataSeries1,
                StrokeStyle = strokeStyle,
                ErrorDirection = SCIErrorDirection.Vertical,
                ErrorType = SCIErrorType.Absolute
            };
            var scatterSeries = new SCIXyScatterRenderableSeries
            {
                DataSeries = dataSeries1,
                PointMarker = new SCIEllipsePointMarker { Size = new CGSize(7, 7), FillStyle = new SCISolidBrushStyle(ColorUtil.Transparent), StrokeStyle = strokeStyle }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(new SCINumericAxis());
                Surface.YAxes.Add(new SCINumericAxis());
                Surface.RenderableSeries = new SCIRenderableSeriesCollection { lineSeries, scatterSeries, errorBars0, errorBars1};
                Surface.ChartModifiers.Add(CreateDefaultModifiers());

                SCIAnimations.ScaleSeries(lineSeries, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeries(scatterSeries, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeries(errorBars0, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeries(errorBars1, 3, new SCIElasticEase());
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