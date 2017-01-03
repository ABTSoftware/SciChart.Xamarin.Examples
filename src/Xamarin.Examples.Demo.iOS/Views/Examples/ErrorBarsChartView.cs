using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("ErrorBars Chart")]
    public class ErrorBarsChartView : ExampleBaseView
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
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            var data0 = DataManager.Instance.GetRandomDoubleSeries(10);

            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(data0.XData, data0.YData);

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCINumericAxis { IsXAxis = true, Style = axisStyle, AutoRange = SCIAutoRangeMode.Always };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle };

            var verticalRenderableSeries = new SCIFastFixedErrorBarsRenderableSeries
            {
                DataSeries = dataSeries,
                ErrorLow = 0.1,
                ErrorHigh = 0.3,
                ErrorType = SCIErrorBarType.SCIErrorBarTypeRelative,
                Style = new SCIErrorBarsSeriesStyle
                {
                    LinePen = new SCIPenSolid( new UIColor( 70.0f / 255.0f, 130.0f / 255.0f, 180.0f / 255.0f, 1.0f), 0.7f)
                }
            };

            var horizontalRenderableSeries = new SCIFastFixedErrorBarsRenderableSeries
            {
                DataSeries = dataSeries,
                ErrorDirection = SCIErrorBarDirection.SCIErrorBarDirectionHorizontal,
                ErrorDataPointWidth = 0.5,
                ErrorLow = 0.1,
                ErrorHigh = 0.3,
                ErrorType = SCIErrorBarType.SCIErrorBarTypeRelative,
                Style = new SCIErrorBarsSeriesStyle
                {
                    LinePen = new SCIPenSolid(UIColor.Red, 0.7f)
                }
            };

            var renderSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                Style = { 
                    LinePen = new SCIPenSolid(new UIColor( 176.0f/255.0f, 196.0f/255.0f, 222.0f/255.0f, 1.0f), 0.7f),
                    DrawPointMarkers = true,
                    PointMarker = new SCIEllipsePointMarker{
                        DrawBorder = true,
                        Width = 15,
                        Height = 15,
                        BorderPen = new SCIPenSolid(new UIColor(176.0f/255.0f, 196.0f/255.0f, 222.0f/255.0f, 1.0f), 1.0f),
                        FillBrush = new SCIBrushSolid(new UIColor( 70.0f/255.0f, 130.0f/255.0f, 180.0f/255.0f, 1.0f))
                    }
                }
            };

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(verticalRenderableSeries);
            Surface.AttachRenderableSeries(horizontalRenderableSeries);
            Surface.AttachRenderableSeries(renderSeries);

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
