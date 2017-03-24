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
    [ExampleDefinition("Stacked Column Chart")]
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

            var porkSeries = GetRenderableSeries(ds1, Color.Rgb(0x22, 0x57, 0x9D), Color.Rgb(0x22, 0x6f, 0xb7));
            var vealSeries = GetRenderableSeries(ds1, Color.Rgb(0xBE, 0x64, 0x2D), Color.Rgb(0xff, 0x9a, 0x2e));
            var tomatoSeries = GetRenderableSeries(ds1, Color.Rgb(0xA3, 0x36, 0x31), Color.Rgb(0xdc, 0x44, 0x3f));
            var cucumberSeries = GetRenderableSeries(ds1, Color.Rgb(0x73, 0x95, 0x3D), Color.Rgb(0xaa, 0xd3, 0x4f));
            var pepperSeries = GetRenderableSeries(ds1, Color.Rgb(0x64, 0x45, 0x8A), Color.Rgb(0x85, 0x62, 0xb4));

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

        private StackedColumnRenderableSeries GetRenderableSeries(IDataSeries dataSeries, Color strokeColor, Color fillColor)
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