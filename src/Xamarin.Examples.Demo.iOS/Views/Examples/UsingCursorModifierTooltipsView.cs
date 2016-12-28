using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using CursorModifier Tooltips")]
    public class UsingCursorModifierTooltipsView : ExampleBaseView
    {
        private const uint GoldColor = 4294956800U;

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

            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCINumericAxis {IsXAxis = true, VisibleRange = new SCIDoubleRange(3, 6), AutoRange = SCIAutoRangeMode.Always, Style = axisStyle};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0, 0.1), Style = axisStyle};

            var ds1 = new XyDataSeries<double, double> { SeriesName = "Green Series" };
            var ds2 = new XyDataSeries<double, double> { SeriesName = "Red Series" };
            var ds3 = new XyDataSeries<double, double> { SeriesName = "Gray Series" };
            var ds4 = new XyDataSeries<double, double> { SeriesName = "Gold Series" };

            var data1 = DataManager.Instance.GetNoisySinewave(300, 1, 300, 0.25);
            var data2 = DataManager.Instance.GetSinewave(100, 2, 300);
            var data3 = DataManager.Instance.GetSinewave(200, 1.5, 300);
            var data4 = DataManager.Instance.GetSinewave(50, 0.1, 300);

            ds1.Append(data1.XData, data1.YData);
            ds2.Append(data2.XData, data2.YData);
            ds3.Append(data3.XData, data3.YData);
            ds4.Append(data4.XData, data4.YData);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries {DataSeries = ds1, Style = {LinePen = new SCIPenSolid(UIColor.Green, 2f)}});
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries {DataSeries = ds2, Style = {LinePen = new SCIPenSolid(UIColor.Red, 2f)}});
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries {DataSeries = ds3, Style = {LinePen = new SCIPenSolid(UIColor.Gray, 2f)}});
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries {DataSeries = ds4, Style = {LinePen = new SCIPenSolid(GoldColor, 2f)}});

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCICursorModifier
                {
                    Style = {HitTestMode = (int) SCIHitTestMode.Interpolate}
                    //ShowAxisLabels = true,
                    //ShowTooltip = true,
                }
            });

            Surface.InvalidateElement();
        }
    }
}