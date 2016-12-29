using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Band Chart")]
    public class BandChartView : ExampleBaseView
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

            var data0 = DataManager.Instance.GetDampedSinewave(1.0, 0.01, 1000);
            var data1 = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 12);

            var dataSeries = new XyyDataSeries<double, double>();
            dataSeries.Append(data0.XData, data0.YData, data1.YData);

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCINumericAxis {IsXAxis = true, VisibleRange = new SCIDoubleRange(1.1, 2.7), Style = axisStyle};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};

            var renderSeries = new SCIBandRenderableSeries
            {
                DataSeries = dataSeries,
                Style = new SCIBandSeriesStyle
                {
                    Pen1 = new SCIPenSolid(0xFFFF1919, 0.7f),
                    Pen2 = new SCIPenSolid(0xFF279B27, 0.7f),
                    Brush1 = new SCIBrushSolid(0x33279B27),
                    Brush2 = new SCIBrushSolid(0x33FF1919)
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