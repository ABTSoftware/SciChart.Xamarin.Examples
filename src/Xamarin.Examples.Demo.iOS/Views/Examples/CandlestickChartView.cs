using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Candlestick Chart")]
    public class CandlestickChartView : ExampleBaseView
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

            var data = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>(TypeOfSeries.XCategory);
            dataSeries.Append(data.TimeData, data.OpenData, data.HighData, data.LowData, data.CloseData);

            var xAxis = new SCICategoryDateTimeAxis();
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};

            var renderSeries = new SCIFastCandlestickRenderableSeries
            {
                DataSeries = dataSeries,
                Style =
                {
                    StrokeUpStyle = new SCISolidPenStyle(UIColor.Green, 1f),
                    StrokeDownStyle = new SCISolidPenStyle(UIColor.Red, 1f),
                    FillUpBrushStyle = new SCISolidBrushStyle(UIColor.Green),
                    FillDownBrushStyle= new SCISolidBrushStyle(UIColor.Red)
                }
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(renderSeries);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            });

            Surface.InvalidateElement();
        }
    }
}