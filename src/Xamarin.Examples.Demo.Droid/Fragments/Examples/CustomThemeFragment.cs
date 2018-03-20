using System.Linq;
using Android.Views.Animations;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Create a Custom Theme", description: "Demonstrates how to create a Custom Theme using resources", icon: ExampleIcon.Themes)]
    public class CustomThemeFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            // Apply a theme to the chart
            // The custom theme is named SciChart_BerryBlue and is included as a number of resource files in the application resources
            // The xml resources contain all the keys for theme colors and brushes and styles to apply to the chart
            Surface.Theme = Resource.Style.SciChart_BerryBlue;

            // The rest of this example is setting up the chart with some axis, and data
            var xAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1), VisibleRange = new DoubleRange(150, 180) };

            var yRightAxis = new NumericAxis(Activity)
            {
                GrowBy = new DoubleRange(0.1, 0.1),
                AxisAlignment = AxisAlignment.Right,
                AutoRange = AutoRange.Always,
                AxisId = "PrimaryAxisId",
                DrawMajorTicks = false,
                DrawMinorTicks = false,
                LabelProvider = new ThousandsLabelProvider(),
            };

            var yLeftAxis = new NumericAxis(Activity)
            {
                GrowBy = new DoubleRange(0, 3d),
                AxisAlignment = AxisAlignment.Left,
                AutoRange = AutoRange.Always,
                AxisId = "SecondaryAxisId",
                DrawMajorTicks = false,
                DrawMinorTicks = false,
                LabelProvider = new BillionsLabelProvider(),
            };

            var dataManager = DataManager.Instance;
            var priceBars = dataManager.GetPriceDataIndu();

            var mountainDataSeries = new XyDataSeries<double, double> { SeriesName = "Mountain Series" };
            var lineDataSeries = new XyDataSeries<double, double> { SeriesName = "Line Series" };
            var columnDataSeries = new XyDataSeries<double, long> { SeriesName = "Column Series" };
            var candlestickDataSeries = new OhlcDataSeries<double, double> { SeriesName = "Candlestick Series" };

            var xValues = Enumerable.Range(0, priceBars.Count).Select(x => (double)x).ToArray();

            mountainDataSeries.Append(xValues, priceBars.LowData.Select(x => x - 1000d));
            lineDataSeries.Append(xValues, dataManager.ComputeMovingAverage(priceBars.CloseData, 50));
            columnDataSeries.Append(xValues, priceBars.VolumeData);
            candlestickDataSeries.Append(xValues, priceBars.OpenData, priceBars.HighData, priceBars.LowData, priceBars.CloseData);

            var mountainSeries = new FastMountainRenderableSeries { DataSeries = mountainDataSeries, YAxisId = "PrimaryAxisId" };
            var lineSeries = new FastLineRenderableSeries { DataSeries = lineDataSeries, YAxisId = "PrimaryAxisId" };
            var columnSeries = new FastColumnRenderableSeries { DataSeries = columnDataSeries, YAxisId = "SecondaryAxisId" };
            var candlestickSeries = new FastCandlestickRenderableSeries { DataSeries = candlestickDataSeries, YAxisId = "PrimaryAxisId" };

            var legendModifier = new LegendModifier(Activity);
            legendModifier.SetShowCheckboxes(false);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yRightAxis);
                Surface.YAxes.Add(yLeftAxis);
                Surface.RenderableSeries.Add(mountainSeries);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(columnSeries);
                Surface.RenderableSeries.Add(candlestickSeries);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    legendModifier,
                    new CursorModifier(),
                    new ZoomExtentsModifier(),
                };

                new ScaleAnimatorBuilder(mountainSeries, 10500d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600}.Start();
                new ScaleAnimatorBuilder(candlestickSeries, 11700d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600}.Start();
                new ScaleAnimatorBuilder(lineSeries, 12250d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600}.Start();
                new ScaleAnimatorBuilder(columnSeries, 10500d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600}.Start();
            }
        }
    }
}