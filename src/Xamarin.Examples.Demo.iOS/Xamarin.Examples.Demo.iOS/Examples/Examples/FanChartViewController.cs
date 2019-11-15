using System;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Fan Chart", description: "Uses Band-Series to generate a Fan-Chart", icon: ExampleIcon.Fan)]
    public class FanChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCIDateAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var actualDataSeries = new XyDataSeries<DateTime, double>();
            var var3DataSeries = new XyyDataSeries<DateTime, double>();
            var var2DataSeries = new XyyDataSeries<DateTime, double>();
            var var1DataSeries = new XyyDataSeries<DateTime, double>();

            DataManager.Instance.GetFanData(10, result =>
            {
                actualDataSeries.Append(result.Date, result.ActualValue);
                var3DataSeries.Append(result.Date, result.MinValue, result.MaxValue);
                var2DataSeries.Append(result.Date, result.Value1, result.Value4);
                var1DataSeries.Append(result.Date, result.Value2, result.Value3);
            });

            var transparentPen = new SCISolidPenStyle(ColorUtil.Transparent, 1);
            var projectedVar3 = new SCIFastBandRenderableSeries { DataSeries = var3DataSeries, StrokeStyle = transparentPen, StrokeY1Style = transparentPen };
            var projectedVar2 = new SCIFastBandRenderableSeries { DataSeries = var2DataSeries, StrokeStyle = transparentPen, StrokeY1Style = transparentPen };
            var projectedVar1 = new SCIFastBandRenderableSeries { DataSeries = var1DataSeries, StrokeStyle = transparentPen, StrokeY1Style = transparentPen };

            var lineSeries = new SCIFastLineRenderableSeries { DataSeries = actualDataSeries, StrokeStyle = new SCISolidPenStyle(ColorUtil.Red, 1.0f) };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(projectedVar3);
                Surface.RenderableSeries.Add(projectedVar2);
                Surface.RenderableSeries.Add(projectedVar1);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.ChartModifiers.Add(CreateDefaultModifiers());

                SCIAnimations.WaveSeries(projectedVar3, 3, new SCICubicEase());
                SCIAnimations.WaveSeries(projectedVar2, 3, new SCICubicEase());
                SCIAnimations.WaveSeries(projectedVar1, 3, new SCICubicEase());
                SCIAnimations.WaveSeries(lineSeries, 3, new SCICubicEase());
            }
        }
    }
}