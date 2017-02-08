using Android.Graphics;
using Android.Util;
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
    [ExampleDefinition("Stacked Bar Chart")]
    public class StackedBarChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) {AxisAlignment = AxisAlignment.Left};
            var yAxis = new NumericAxis(Activity) {AxisAlignment = AxisAlignment.Bottom, FlipCoordinates = true};

            var yValues1 = new[] {0.0, 0.1, 0.2, 0.4, 0.8, 1.1, 1.5, 2.4, 4.6, 8.1, 11.7, 14.4, 16.0, 13.7, 10.1, 6.4, 3.5, 2.5, 5.4, 6.4, 7.1, 8.0, 9.0};
            var yValues2 = new[] {2.0, 10.1, 10.2, 10.4, 10.8, 1.1, 11.5, 3.4, 4.6, 0.1, 1.7, 14.4, 16.0, 13.7, 10.1, 6.4, 3.5, 2.5, 1.4, 0.4, 10.1, 0.0, 0.0};
            var yValues3 = new[] {20.0, 4.1, 4.2, 10.4, 10.8, 1.1, 11.5, 3.4, 4.6, 5.1, 5.7, 14.4, 16.0, 13.7, 10.1, 6.4, 3.5, 2.5, 1.4, 10.4, 8.1, 10.0, 15.0};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "data 1"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "data 2"};
            var ds3 = new XyDataSeries<double, double> {SeriesName = "data 3"};

            for (var i = 0; i < yValues1.Length; i++)
            {
                ds1.Append(i, yValues1[i]);
                ds2.Append(i, yValues2[i]);
                ds3.Append(i, yValues3[i]);
            }

            var series1 = GetRenderableSeries(ds1, Color.Rgb(0x56, 0x78, 0x93), Color.Rgb(0x56, 0x78, 0x93), Color.Rgb(0x3D, 0x55, 0x68));
            var series2 = GetRenderableSeries(ds2, Color.Rgb(0xAC, 0xBC, 0xCA), Color.Rgb(0xAC, 0xBC, 0xCA), Color.Rgb(0x43, 0x9A, 0xAF));
            var series3 = GetRenderableSeries(ds3, Color.Rgb(0xDB, 0xE0, 0xE1), Color.Rgb(0xDB, 0xE0, 0xE1), Color.Rgb(0xB6, 0xC1, 0xC3));

            var columnsCollection = new VerticallyStackedColumnsCollection();
            columnsCollection.Add(series1);
            columnsCollection.Add(series2);
            columnsCollection.Add(series3);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(columnsCollection);

                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new CursorModifier(),
                    new ZoomExtentsModifier(),
                };
            }
        }

        private StackedColumnRenderableSeries GetRenderableSeries(IDataSeries dataSeries, Color strokeColor, Color fillColorStart, Color fillColorEbd)
        {
            return new StackedColumnRenderableSeries
            {
                DataSeries = dataSeries,
                DataPointWidth = 0.8,
                StrokeStyle = new SolidPenStyle(Activity, strokeColor),
                FillBrushStyle = new LinearGradientBrushStyle(0,0,0,1, fillColorStart, fillColorEbd)
            };
        }
    }
}