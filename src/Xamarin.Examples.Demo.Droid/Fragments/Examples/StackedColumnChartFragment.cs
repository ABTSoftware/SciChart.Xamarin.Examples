using Android.Graphics;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Stacked Column Chart", description: "Demonstrates Stacked Columns Chart", icon: ExampleIcon.StackedColumn)]
    public class StackedColumnChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity);
            var yAxis = new NumericAxis(Activity);

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

            var verticalCollection1 = new VerticallyStackedColumnsCollection();
            verticalCollection1.Add(porkSeries);
            verticalCollection1.Add(vealSeries);

            var verticalCollection2 = new VerticallyStackedColumnsCollection();
            verticalCollection2.Add(tomatoSeries);
            verticalCollection2.Add(cucumberSeries);
            verticalCollection2.Add(pepperSeries);

            var columnsCollection = new HorizontallyStackedColumnsCollection();
            columnsCollection.Add(verticalCollection1);
            columnsCollection.Add(verticalCollection2);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(columnsCollection);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new RolloverModifier(),
                    new ZoomExtentsModifier(),
                };
            }
        }

        private StackedColumnRenderableSeries GetRenderableSeries(IDataSeries dataSeries, uint strokeColor, uint fillColor)
        {
            return new StackedColumnRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(Activity, strokeColor),
                FillBrushStyle = new SolidBrushStyle(fillColor)
            };
        }
    }
}