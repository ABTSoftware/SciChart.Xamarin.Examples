using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Stacked Column Chart")]
    public class StackedColumnChartView : ExampleBaseView
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
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            var xAxis = new SCINumericAxis { IsXAxis = true };
            var yAxis = new SCINumericAxis();

            var porkData = new double[] {10, 13, 7, 16, 4, 6, 20, 14, 16, 10, 24, 11};
            var vealData = new double[] {12, 17, 21, 15, 19, 18, 13, 21, 22, 20, 5, 10};
            var tomatoesData = new double[] {7, 30, 27, 24, 21, 15, 17, 26, 22, 28, 21, 22};
            var cucumberData = new double[] {16, 10, 9, 8, 22, 14, 12, 27, 25, 23, 17, 17};
            var pepperData = new double[] {7, 24, 21, 11, 19, 17, 14, 27, 26, 22, 28, 16};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Pork Series"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Veal Series"};
            var ds3 = new XyDataSeries<double, double> {SeriesName = "Tomato Series"};
            var ds4 = new XyDataSeries<double, double> {SeriesName = "Cucumber Series"};
            var ds5 = new XyDataSeries<double, double> {SeriesName = "Pepper Series"};

            const int data = 1992;
            for (var i = 0; i < porkData.Length; i++)
            {
                ds1.Append(data + i, porkData[i]);
                ds2.Append(data + i, vealData[i]);
                ds3.Append(data + i, tomatoesData[i]);
                ds4.Append(data + i, cucumberData[i]);
                ds5.Append(data + i, pepperData[i]);
            }

            var porkSeries = GetRenderableSeries(ds1, UIColor.FromRGB(0x22, 0x57, 0x9D), UIColor.FromRGB(0x22, 0x6f, 0xb7));
            var vealSeries = GetRenderableSeries(ds1, UIColor.FromRGB(0xBE, 0x64, 0x2D), UIColor.FromRGB(0xff, 0x9a, 0x2e));
            var tomatoSeries = GetRenderableSeries(ds1, UIColor.FromRGB(0xA3, 0x36, 0x31), UIColor.FromRGB(0xdc, 0x44, 0x3f));
            var cucumberSeries = GetRenderableSeries(ds1, UIColor.FromRGB(0x73, 0x95, 0x3D), UIColor.FromRGB(0xaa, 0xd3, 0x4f));
            var pepperSeries = GetRenderableSeries(ds1, UIColor.FromRGB(0x64, 0x45, 0x8A), UIColor.FromRGB(0x85, 0x62, 0xb4));

            var verticalCollection1 = new SCIStackedVerticalColumnGroupSeries();
            verticalCollection1.AddSeries(porkSeries);
            verticalCollection1.AddSeries(vealSeries);

            var verticalCollection2 = new SCIStackedVerticalColumnGroupSeries();
            verticalCollection2.AddSeries(tomatoSeries);
            verticalCollection2.AddSeries(cucumberSeries);
            verticalCollection2.AddSeries(pepperSeries);

            //var columnsCollection = new SCIStackedHorizontalColumnGroupSeries();
            //columnsCollection.AddSeries(verticalCollection1);
            //columnsCollection.AddSeries(verticalCollection2);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(verticalCollection1);
            Surface.AttachRenderableSeries(verticalCollection2);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIRolloverModifier(),
                new SCIZoomExtentsModifier()
            });

            Surface.InvalidateElement();
        }

        private SCIStackedColumnRenderableSeries GetRenderableSeries(IDataSeries dataSeries, UIColor strokeColor, UIColor fillColor)
        {
            return new SCIStackedColumnRenderableSeries
            {
                DataSeries = dataSeries,
                Style = new SCIColumnSeriesStyle
                {
                    FillBrush = new SCIBrushSolid(fillColor),
                    BorderPen = new SCIPenSolid(strokeColor, 1f)
                }
            };
        }
    }
}