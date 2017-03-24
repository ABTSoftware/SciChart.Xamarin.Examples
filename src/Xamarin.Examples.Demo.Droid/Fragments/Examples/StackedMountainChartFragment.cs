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
    [ExampleDefinition("Stacked Mountain Chart")]
    public class StackedMountainChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity);
            var yAxis = new NumericAxis(Activity);

            var yValues1 = new[] { 4.0, 7, 5.2, 9.4, 3.8, 5.1, 7.5, 12.4, 14.6, 8.1, 11.7, 14.4, 16.0, 3.7, 5.1, 6.4, 3.5, 2.5, 12.4, 16.4, 7.1, 8.0, 9.0 };
            var yValues2 = new[] { 15.0, 10.1, 10.2, 10.4, 10.8, 1.1, 11.5, 3.4, 4.6, 0.1, 1.7, 14.4, 6.0, 13.7, 10.1, 8.4, 8.5, 12.5, 1.4, 0.4, 10.1, 5.0, 1.0 };

            var ds1 = new XyDataSeries<double, double> { SeriesName = "data 1" };
            var ds2 = new XyDataSeries<double, double> { SeriesName = "data 2" };

            for (var i = 0; i < yValues1.Length; i++) ds1.Append(i, yValues1[i]);
            for (var i = 0; i < yValues2.Length; i++) ds2.Append(i, yValues2[i]);

            var series1 = GetRenderableSeries(ds1, Color.Argb(0xDD, 0xDB, 0xE0, 0xE1), Color.Argb(0x88, 0xB6, 0xC1, 0xC3));
            var series2 = GetRenderableSeries(ds2, Color.Argb(0xDD, 0xDA, 0xCB, 0xCCA), Color.Argb(0x88, 0x43, 0x9A, 0xAF));

            var seriesCollection = new VerticallyStackedMountainsCollection();
            seriesCollection.Add(series1);
            seriesCollection.Add(series2);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(seriesCollection);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new CursorModifier(),
                    new ZoomExtentsModifier(),
                };
            }
        }

        private StackedMountainRenderableSeries GetRenderableSeries(IDataSeries dataSeries, Color fillColorStart, Color fillColorEbd)
        {
            return new StackedMountainRenderableSeries
            {
                DataSeries = dataSeries,
                AreaStyle = new LinearGradientBrushStyle(0, 0, 0, 1, fillColorStart, fillColorEbd)
            };
        }
    }
}