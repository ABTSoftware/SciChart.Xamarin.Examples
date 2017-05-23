using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("ErrorBars Chart", description:"Demonstrates Error Bars showing point uncertainty", icon: ExampleIcon.ErrorBars)]
    public class ErrorBarsChartView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        protected override void UpdateFrame()
        {
            ExampleViewLayout.SciChartSurface.Frame = ExampleViewLayout.Frame;
            ExampleViewLayout.SciChartSurface.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            var data0 = DataManager.Instance.GetRandomDoubleSeries(10);

            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(data0.XData, data0.YData);

            var xAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};

            var verticalRenderableSeries = new SCIFastFixedErrorBarsRenderableSeries
            {
                DataSeries = dataSeries,
                ErrorLow = 0.1,
                ErrorHigh = 0.3,
                ErrorType = SCIErrorBarType.SCIErrorBarTypeRelative,
                StrokeStyle = new SCISolidPenStyle( new UIColor( 70.0f / 255.0f, 130.0f / 255.0f, 180.0f / 255.0f, 1.0f), 0.7f)
            };

            var horizontalRenderableSeries = new SCIFastFixedErrorBarsRenderableSeries
            {
                DataSeries = dataSeries,
                ErrorDirection = SCIErrorBarDirection.SCIErrorBarDirectionHorizontal,
                DataPointWidth = 0.5,
                StrokeStyle = new SCISolidPenStyle(UIColor.Red, 0.7f)
            };

            var renderSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(new UIColor(176.0f / 255.0f, 196.0f / 255.0f, 222.0f / 255.0f, 1.0f), 0.7f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Width = 15,
                    Height = 15,
                    StrokeStyle = new SCISolidPenStyle(new UIColor(176.0f / 255.0f, 196.0f / 255.0f, 222.0f / 255.0f, 1.0f), 1.0f),
                    FillStyle = new SCISolidBrushStyle(new UIColor(70.0f / 255.0f, 130.0f / 255.0f, 180.0f / 255.0f, 1.0f))
                }
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(verticalRenderableSeries);
            Surface.RenderableSeries.Add(horizontalRenderableSeries);
            Surface.RenderableSeries.Add(renderSeries);

            Surface.ChartModifiers = new SCIChartModifierCollection(
				new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            );

            Surface.InvalidateElement();
        }
    }
}