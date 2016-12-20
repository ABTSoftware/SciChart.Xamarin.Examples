using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Scatter Chart")]
    public class ScatterChartView : ExampleBaseView
    {
        public SCIChartSurface Surface;

        protected override void InitExample()
        {
            var dampedSinewave = DataManager.Instance.GetDampedSinewave(1.0, 0.02, 150, 5);

            var dataSeries = new SCIXyDataSeries<double, double>();
            dataSeries.AppendRange(dampedSinewave.XData, dampedSinewave.YData, 150);

            //TODO Remove AxisId, should be default (DefaultAxisId)
            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            //TODO Add GrowBy = new DoubleRange(0.1, 0.1)
            var xAxis = new SCINumericAxis {IsXAxis = true, AxisId = "xAxis", Style = axisStyle};
            //TODO Add GrowBy = new DoubleRange(0.1, 0.1)
            var yAxis = new SCINumericAxis {AxisId = "yAxis", Style = axisStyle};

            var renderSeries = new SCIXyScatterRenderableSeries
            {
                DataSeries = dataSeries,
                XAxisId = "xAxis",
                YAxisId = "yAxis",
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

            Surface = new SCIChartSurface(this);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

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