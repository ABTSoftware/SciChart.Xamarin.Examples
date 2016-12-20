using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Mountain Chart")]
    public class MountainChartView : ExampleBaseView
    {
        public SCIChartSurface Surface;

        protected override void InitExample()
        {
            var priceData = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new SCIXyDataSeries<DateTime, double>();
            dataSeries.AppendRange(priceData.TimeData, priceData.CloseData, priceData.Count);

            //TODO Remove AxisId, should be default (DefaultAxisId)
            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            //TODO Add GrowBy = new DoubleRange(0.1, 0.1)
            var xAxis = new SCIDateTimeAxis {IsXAxis = true, AxisId = "xAxis", Style = axisStyle};
            //TODO Add GrowBy = new DoubleRange(0.1, 0.1)
            var yAxis = new SCINumericAxis {AxisId = "yAxis", Style = axisStyle};

            var renderSeries = new SCIFastMountainRenderableSeries
            {
                DataSeries = dataSeries,
                XAxisId = "xAxis",
                YAxisId = "yAxis",
                Style =
                {
                    AreaBrush = new SCIBrushLinearGradient(0xAAFF8D42, 0x88090E11, SCILinearGradientDirection.Vertical),
                    BorderPen = new SCIPenSolid(0xaaffc9a8, 0.7f)
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