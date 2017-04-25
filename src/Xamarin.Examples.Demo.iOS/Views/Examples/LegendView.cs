using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Chart Legends API", description:"Demonstrates the SciChart Legend API", icon:ExampleIcon.LineChart)]
    public class LegendView : ExampleBaseView
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

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Curve A"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Curve B"};
            var ds3 = new XyDataSeries<double, double> {SeriesName = "Curve C"};
            var ds4 = new XyDataSeries<double, double> {SeriesName = "Curve D"};

            var ds1Points = DataManager.Instance.GetStraightLine(4000, 1.0, 10);
            var ds2Points = DataManager.Instance.GetStraightLine(3000, 1.0, 10);
            var ds3Points = DataManager.Instance.GetStraightLine(2000, 1.0, 10);
            var ds4Points = DataManager.Instance.GetStraightLine(1000, 1.0, 10);

            ds1.Append(ds1Points.XData, ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);
            ds3.Append(ds3Points.XData, ds3Points.YData);
            ds4.Append(ds4Points.XData, ds4Points.YData);

            var legendModifier = new SCILegendCollectionModifier {SourceMode = SCISourceMode.AllSeries};

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries {DataSeries = ds1, Style = {LinePen = new SCISolidPenStyle(0xFFFFFF00, 2f)}});
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries {DataSeries = ds2, Style = {LinePen = new SCISolidPenStyle(0xFF279B27, 2f)}});
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries {DataSeries = ds3, Style = {LinePen = new SCISolidPenStyle(0xFFFF1919, 2f)}});
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries {DataSeries = ds4, IsVisible = false, Style = {LinePen = new SCISolidPenStyle(0xFF1964FF, 2f)}});

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[] {legendModifier});

            Surface.InvalidateElement();
        }
    }
}