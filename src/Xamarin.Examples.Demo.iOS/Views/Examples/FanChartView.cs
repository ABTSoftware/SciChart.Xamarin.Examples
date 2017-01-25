using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Fan Chart")]
    public class FanChartView : ExampleBaseView
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

            var xAxis = new SCIDateTimeAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), TextFormatting = "dd/MM/YYYY"};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};

            var dataSeries = new XyDataSeries<DateTime, double> {DataDistributionCalculator = new SCIUserDefinedDistributionCalculator()};
            var xyyDataSeries = new XyyDataSeries<DateTime, double> {DataDistributionCalculator = new SCIUserDefinedDistributionCalculator()};
            var xyyDataSeries1 = new XyyDataSeries<DateTime, double> {DataDistributionCalculator = new SCIUserDefinedDistributionCalculator()};
            var xyyDataSeries2 = new XyyDataSeries<DateTime, double> {DataDistributionCalculator = new SCIUserDefinedDistributionCalculator()};

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
                Style = { LinePen = new SCIPenSolid(UIColor.Red, 1.0f) }
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);

            Surface.RenderableSeries.Add(createRenderableSeriesWith(xyyDataSeries));
            Surface.RenderableSeries.Add(createRenderableSeriesWith(xyyDataSeries1));
            Surface.RenderableSeries.Add(createRenderableSeriesWith(xyyDataSeries2));
            Surface.RenderableSeries.Add(dataRenderSeries);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            });

            Surface.InvalidateElement();
        }

        SCIBandRenderableSeries createRenderableSeriesWith(SCIXyyDataSeries dataSeries)
        {
            var renderebleDataSeries = new SCIBandRenderableSeries
            {
                Style =
                {
                    Brush1 = new SCIBrushSolid(new UIColor(1.0f, 0.4f, 0.4f, 0.5f)),
                    Brush2 = new SCIBrushSolid(new UIColor(1.0f, 0.4f, 0.4f, 0.5f)),
                    Pen1 = new SCIPenSolid(UIColor.Green, 0.5f),
                    Pen2 = new SCIPenSolid(UIColor.Clear, 0.5f),
                    DrawPointMarkers = false
                },
                DataSeries = dataSeries
            };

            return renderebleDataSeries;
        }
    }
}
