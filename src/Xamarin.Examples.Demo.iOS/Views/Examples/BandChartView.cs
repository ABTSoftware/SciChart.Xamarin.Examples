using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Band Chart")]
    public class BandChartView : ExampleBaseView
    {
        public SCIChartSurface Surface;

        protected override void InitExample()
        {
            var data0 = DataManager.Instance.GetDampedSinewave(1.0, 0.01, 1000);
            var data1 = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 12);

            var dataSeries = new SCIXyyDataSeries<double, double>();
            dataSeries.Append(data0.XData, data0.YData, data1.YData);

            //TODO Remove AxisId, should be default (DefaultAxisId)
            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            //TODO Add VisibleRange = new SCIDoubleRange(1.1, 2.7)
            var xAxis = new SCINumericAxis {IsXAxis = true, AxisId = "xAxis", Style = axisStyle};
            //TODO Add GrowBy = new DoubleRange(0.1, 0.1)
            var yAxis = new SCINumericAxis {AxisId = "yAxis", Style = axisStyle};

            //TODO Add SCIBandRenderableSeries
            var renderSeries = new SCIBandRenderableSeries
            {
                DataSeries = dataSeries,
                XAxisId = "xAxis",
                YAxisId = "yAxis",
                Style = new SCIBandSeriesStyle
                {
                    Pen1 = new SCIPenSolid(0xFFFF1919, 0.7f),
                    Pen2 = new SCIPenSolid(0xFF279B27, 0.7f),
                    Brush1 = new SCIBrushSolid(0x33279B27),
                    Brush2 = new SCIBrushSolid(0x33FF1919)
                }
            };

            Surface = new SCIChartSurface(this);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(renderSeries);

            var modifierGroup = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            });
            Surface.ChartModifier = modifierGroup;

            Surface.InvalidateElement();
        }
    }
}