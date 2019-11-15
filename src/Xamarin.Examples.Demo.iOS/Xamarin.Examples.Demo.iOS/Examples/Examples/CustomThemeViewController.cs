using System.Linq;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Create a Custom Theme", description: "Demonstrates how to create a Custom Theme using a PList", icon: ExampleIcon.Themes)]
    public class CustomThemeViewController : SingleChartViewController<SCIChartSurface>
    {
        private const string SCIChart_BerryBlueStyleKey = "SciChart_BerryBlue";

        // Setting up the chart with some axis, and data
        protected override void InitExample()
        {
            // Create our XAxis, YAxis and Left YAxis 
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(150, 180) };

            var yRightAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0.1, 0.1),
                AxisAlignment = SCIAxisAlignment.Right,
                AutoRange = SCIAutoRange.Always,
                AxisId = "PrimaryAxisId",
                DrawMajorTicks = false,
                DrawMinorTicks = false,
                LabelProvider = new ThousandsLabelProvider(),
            };

            var yLeftAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0, 3d),
                AxisAlignment = SCIAxisAlignment.Left,
                AutoRange = SCIAutoRange.Always,
                AxisId = "SecondaryAxisId",
                DrawMajorTicks = false,
                DrawMinorTicks = false,
                LabelProvider = new BillionsLabelProvider(),
            };

            // Create some data on the chart 
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

            var mountainSeries = new SCIFastMountainRenderableSeries { DataSeries = mountainDataSeries, YAxisId = "PrimaryAxisId" };
            var lineSeries = new SCIFastLineRenderableSeries { DataSeries = lineDataSeries, YAxisId = "PrimaryAxisId" };
            var columnSeries = new SCIFastColumnRenderableSeries { DataSeries = columnDataSeries, YAxisId = "SecondaryAxisId" };
            var candlestickSeries = new SCIFastCandlestickRenderableSeries { DataSeries = candlestickDataSeries, YAxisId = "PrimaryAxisId" };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yRightAxis);
                Surface.YAxes.Add(yLeftAxis);
                Surface.RenderableSeries = new SCIRenderableSeriesCollection { mountainSeries, lineSeries, columnSeries, candlestickSeries };
                Surface.ChartModifiers.Add(CreateDefaultModifiers());
                Surface.ChartModifiers.Add(new SCILegendModifier { ShowCheckBoxes = false });

                SCIAnimations.ScaleSeriesWithZeroLine(mountainSeries, 10500, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(lineSeries, 11700, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(columnSeries, 12250, 3, new SCIElasticEase());
                SCIAnimations.ScaleSeriesWithZeroLine(candlestickSeries, 10500, 3, new SCIElasticEase());

                // Apply a theme to the chartå
                // The custom theme is named SciChart_BerryBlue and is included as a .plist in the application resources
                // The .plist contains all the keys for theme colors and brushes and styles to apply to the chart
                SCIThemeManager.ApplyTheme(Surface, SCIChart_BerryBlueStyleKey);
            }
        }
    }
}