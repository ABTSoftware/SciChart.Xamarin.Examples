using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Scatter Chart")]
    public class ScatterChartView : ExampleBaseView
    {
        private readonly SingleChartView _exampleView = SingleChartView.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleView;

        protected override void InitExample()
        {
            var surfaceView = _exampleView.SciChartSurfaceView;
            surfaceView.Frame = _exampleView.Frame;
            surfaceView.TranslatesAutoresizingMaskIntoConstraints = true;

            Surface = new SCIChartSurface(surfaceView);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            var dampedSinewave = DataManager.Instance.GetDampedSinewave(1.0, 0.02, 150, 5);

            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(dampedSinewave.XData, dampedSinewave.YData);

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCINumericAxis {IsXAxis = true, GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};

            var renderSeries = new SCIXyScatterRenderableSeries
            {
                DataSeries = dataSeries,
                Style =
                {
                    PointMarker = new SCIEllipsePointMarker
                    {
                        FillBrush = new SCIBrushSolid(UIColor.FromRGB(70, 130, 180)),
                        BorderPen = new SCIPenSolid(UIColor.FromRGB(176, 196, 222), 2f),
                        Width = 15,
                        Height = 15
                    }
                }
            };

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
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