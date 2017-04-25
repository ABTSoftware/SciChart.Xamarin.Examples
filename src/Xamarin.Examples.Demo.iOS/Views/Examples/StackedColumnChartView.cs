using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Stacked Column Chart", description:"Demonstrates Stacked Columns Chart")]
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

            var xAxis = new SCINumericAxis();
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

            var porkSeries = GetRenderableSeries(ds1, 0xFF22579D, 0xFF226FB7);
            var vealSeries = GetRenderableSeries(ds2, 0xFFBE642D, 0xFFFF9A2E);
            var tomatoSeries = GetRenderableSeries(ds3, 0xFFA33631, 0xFFDC443F);
            var cucumberSeries = GetRenderableSeries(ds4, 0xFF73953D, 0xFFAAD34F);
            var pepperSeries = GetRenderableSeries(ds5, 0xFF64458A, 0xFF8562B4);

            var verticalCollection1 = new SCIVerticallyStackedColumnsCollection();
            verticalCollection1.Add(porkSeries);
            verticalCollection1.Add(vealSeries);

            var verticalCollection2 = new SCIVerticallyStackedColumnsCollection();
            verticalCollection2.Add(tomatoSeries);
            verticalCollection2.Add(cucumberSeries);
            verticalCollection2.Add(pepperSeries);

            var columnsCollection = new SCIHorizontallyStackedColumnsCollection();
            columnsCollection.Add(verticalCollection1);
            columnsCollection.Add(verticalCollection2);

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(verticalCollection1);
            Surface.RenderableSeries.Add(verticalCollection2);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIRolloverModifier(),
                new SCIZoomExtentsModifier()
            });

            Surface.InvalidateElement();
        }

        private SCIStackedColumnRenderableSeries GetRenderableSeries(IDataSeries dataSeries, uint strokeColor, uint fillColor)
        {
            return new SCIStackedColumnRenderableSeries
            {
                DataSeries = dataSeries,
                Style = new SCIColumnSeriesStyle
                {
                    FillBrush = new SCISolidBrushStyle(fillColor),
                    BorderPen = new SCISolidPenStyle(strokeColor, 1f)
                }
            };
        }
    }
}