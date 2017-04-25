using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Stacked Mountain Chart", description:"Demonstrates a Stacked Mountain Chart", icon: ExampleIcon.StackedMountainChart)]
    public class StackedMountainChartView : ExampleBaseView
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

            var xAxis = new SCINumericAxis();
            var yAxis = new SCINumericAxis();

            var yValues1 = new[] {4.0, 7, 5.2, 9.4, 3.8, 5.1, 7.5, 12.4, 14.6, 8.1, 11.7, 14.4, 16.0, 3.7, 5.1, 6.4, 3.5, 2.5, 12.4, 16.4, 7.1, 8.0, 9.0};
            var yValues2 = new[] {15.0, 10.1, 10.2, 10.4, 10.8, 1.1, 11.5, 3.4, 4.6, 0.1, 1.7, 14.4, 6.0, 13.7, 10.1, 8.4, 8.5, 12.5, 1.4, 0.4, 10.1, 5.0, 1.0};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "data 1"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "data 2"};

            for (var i = 0; i < yValues1.Length; i++) ds1.Append(i, yValues1[i]);
            for (var i = 0; i < yValues2.Length; i++) ds2.Append(i, yValues2[i]);

            var series1 = GetRenderableSeries(ds1, 0xDDDBE0E1, 0x88B6C1C3);
            var series2 = GetRenderableSeries(ds2, 0xDDACBCCA, 0x88439AAF);

            var seriesCollection = new SCIVerticallyStackedMountainsCollection();
            seriesCollection.Add(series1);
            seriesCollection.Add(series2);

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(seriesCollection);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCICursorModifier(), 
                new SCIZoomExtentsModifier()
            });

            Surface.InvalidateElement();
        }

        private SCIStackedMountainRenderableSeries GetRenderableSeries(IDataSeries dataSeries, uint fillColorStart, uint fillColorEbd)
        {
            return new SCIStackedMountainRenderableSeries
            {
                DataSeries = dataSeries,
                Style =
                {
                    AreaBrush = new SCILinearGradientBrushStyle(fillColorStart, fillColorEbd, SCILinearGradientDirection.Vertical),
                }
            };
        }
    }
}