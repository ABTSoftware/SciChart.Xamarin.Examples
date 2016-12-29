using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Impulse Chart")]
    public class ImpulseChartView : ExampleBaseView
    {
        private readonly SingleChartView _exampleView = SingleChartView.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleView;

        protected override void UpdateFrame()
        {
            _exampleView.SciChartSurfaceView.Frame = _exampleView.Frame;
            _exampleView.SciChartSurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            Surface = new SCIChartSurface(_exampleView.SciChartSurfaceView);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            var ds1Points = DataManager.Instance.GetDampedSinewave(1.0, 0.05, 50, 5);

            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(ds1Points.XData, ds1Points.YData);

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCINumericAxis {IsXAxis = true, GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};

            var renderSeries = new SCIFastImpulseRenderableSeries
            {
                DataSeries = dataSeries,
                Style =
                {
                    LinePen = new SCIPenSolid(UIColor.FromRGB(0x00, 0x66, 0xFF), 0.7f),
                    PointMarker = new SCIEllipsePointMarker
                    {
                        FillBrush = new SCIBrushSolid(UIColor.FromRGB(0x00, 0x66, 0xFF)),
                        BorderPen = new SCIPenSolid(UIColor.FromRGB(0x00, 0x66, 0xFF), 2f),
                        Width = 10,
                        Height = 10
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