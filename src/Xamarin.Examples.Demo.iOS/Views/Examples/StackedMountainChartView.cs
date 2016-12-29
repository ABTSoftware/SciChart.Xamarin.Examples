using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Stacked Mountain Chart")]
    public class StackedMountainChartView : ExampleBaseView
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

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCIDateTimeAxis {IsXAxis = true, GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};

            var yValues1 = new[] {4.0, 7, 5.2, 9.4, 3.8, 5.1, 7.5, 12.4, 14.6, 8.1, 11.7, 14.4, 16.0, 3.7, 5.1, 6.4, 3.5, 2.5, 12.4, 16.4, 7.1, 8.0, 9.0};
            var yValues2 = new[] {15.0, 10.1, 10.2, 10.4, 10.8, 1.1, 11.5, 3.4, 4.6, 0.1, 1.7, 14.4, 6.0, 13.7, 10.1, 8.4, 8.5, 12.5, 1.4, 0.4, 10.1, 5.0, 1.0};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "data 1"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "data 2"};

            for (var i = 0; i < yValues1.Length; i++) ds1.Append(i, yValues1[i]);
            for (var i = 0; i < yValues2.Length; i++) ds2.Append(i, yValues2[i]);

            var bottomRenderSeries = new SCIStackedMountainRenderableSeries
            {
                DataSeries = ds1,
                Style =
                {
                    AreaBrush = new SCIBrushLinearGradient(0xe1e0dbdd, 0xc3c1b688, SCILinearGradientDirection.Vertical),
                    BorderPen = new SCIPenSolid(0xaaffc9a8, 0.7f)
                }
            };
            var topRenderSeries = new SCIStackedMountainRenderableSeries
            {
                DataSeries = ds2,
                Style =
                {
                    AreaBrush = new SCIBrushLinearGradient(0xcacbdadd, 0xaf9a4388, SCILinearGradientDirection.Vertical),
                    BorderPen = new SCIPenSolid(0xaaffc9a8, 0.7f)
                }
            };

            var stackedGroup = new SCIStackedGroupSeries();
            stackedGroup.AddSeries(bottomRenderSeries);
            stackedGroup.AddSeries(topRenderSeries);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(stackedGroup);

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