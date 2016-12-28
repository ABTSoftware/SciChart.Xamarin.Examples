using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Mountain Chart")]
    public class MountainChartView : ExampleBaseView
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

            var priceData = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new XyDataSeries<DateTime, double>();
            dataSeries.Append(priceData.TimeData, priceData.CloseData);

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCIDateTimeAxis {IsXAxis = true, GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};

            var renderSeries = new SCIFastMountainRenderableSeries
            {
                DataSeries = dataSeries,
                Style =
                {
                    AreaBrush = new SCIBrushLinearGradient(0xAAFF8D42, 0x88090E11, SCILinearGradientDirection.Vertical),
                    BorderPen = new SCIPenSolid(0xaaffc9a8, 0.7f)
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