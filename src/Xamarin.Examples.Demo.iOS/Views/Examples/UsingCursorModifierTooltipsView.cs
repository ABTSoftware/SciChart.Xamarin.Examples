using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using CursorModifier Tooltips")]
    public class UsingCursorModifierTooltipsView : ExampleBaseView
    {
        private const uint GoldColor = 4294956800U;

        public SCIChartSurface Surface;

        protected override void InitExample()
        {
            //TODO Remove AxisId, should be default (DefaultAxisId)
            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            //TODO Add VisibleRange = new SCIDoubleRange(3, 6)
            var xAxis = new SCINumericAxis { IsXAxis = true, AxisId = "xAxis", AutoRange = SCIAutoRangeMode.Always, Style = axisStyle };
            //TODO Add GrowBy = new DoubleRange(0, 0.1)
            var yAxis = new SCINumericAxis { AxisId = "yAxis", Style = axisStyle };

            var ds1 = new SCIXyDataSeries<double, double> { SeriesName = "Green Series" };
            var ds2 = new SCIXyDataSeries<double, double> { SeriesName = "Red Series" };
            var ds3 = new SCIXyDataSeries<double, double> { SeriesName = "Gray Series" };
            var ds4 = new SCIXyDataSeries<double, double> { SeriesName = "Gold Series" };

            var data1 = DataManager.Instance.GetNoisySinewave(300, 1, 300, 0.25);
            var data2 = DataManager.Instance.GetSinewave(100, 2, 300);
            var data3 = DataManager.Instance.GetSinewave(200, 1.5, 300);
            var data4 = DataManager.Instance.GetSinewave(50, 0.1, 300);

            ds1.Append(data1.XData, data1.YData);
            ds2.Append(data2.XData, data2.YData);
            ds3.Append(data3.XData, data3.YData);
            ds4.Append(data4.XData, data4.YData);

            Surface = new SCIChartSurface(this);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries {DataSeries = ds1, XAxisId = "xAxis", YAxisId = "yAxis", Style = {LinePen = new SCIPenSolid(UIColor.Green, 2f)}});
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries {DataSeries = ds2, XAxisId = "xAxis", YAxisId = "yAxis", Style = {LinePen = new SCIPenSolid(UIColor.Red, 2f)}});
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries {DataSeries = ds3, XAxisId = "xAxis", YAxisId = "yAxis", Style = {LinePen = new SCIPenSolid(UIColor.Gray, 2f)}});
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries {DataSeries = ds4, XAxisId = "xAxis", YAxisId = "yAxis", Style = {LinePen = new SCIPenSolid(GoldColor, 2f)}});

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCICursorModifier
                {
                    Style =
                    {
                        
                    }
                    //ShowAxisLabels = true,
                    //ShowTooltip = true,
                    //UseInterpolation = true,
                }
            });

            Surface.InvalidateElement();
        }
    }
}