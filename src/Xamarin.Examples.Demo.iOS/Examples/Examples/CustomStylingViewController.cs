using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Custom Styling via API", description: "Change all chart styles and colors programmatically", icon: ExampleIcon.Themes)]
    public class CustomStylingViewController : SingleChartViewController<SCIChartSurface>
    {
        // Initializes the SCIChartSurface with Left YAxis, right YAxis and single XAxis 
        protected override void InitExample()
        {            
            // Surface background. If you set color for chart background than it is color only for axes area
            Surface.BackgroundColor = UIColor.Orange;
            // Chart area (viewport) background fill color
            Surface.RenderableSeriesAreaFillStyle = new SCISolidBrushStyle(colorCode: 0xFFFFB6C1);
            // Chart area border color and thickness
            Surface.RenderableSeriesAreaBorderStyle = new SCISolidPenStyle(colorCode: 0xFF4682b4, thickness: 2);

            // Create the XAxis
            var xAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0.1, 0.1),
                VisibleRange = new SCIDoubleRange(150, 180),
                // Brushes and styles for the XAxis, vertical gridlines, vertical tick marks, vertical axis bands and xaxis labels
                AxisBandsStyle = new SCISolidBrushStyle(0x55ff6655),
                MajorGridLineStyle = new SCISolidPenStyle(UIColor.Green, 1),
                MinorGridLineStyle = new SCISolidPenStyle(UIColor.Yellow, 0.5f, new NSNumber[] { 10, 3, 10, 3 }),
                TickLabelStyle = new SCIFontStyle("Helvetica", 14, UIColor.Purple),
                DrawMajorTicks = true,
                DrawMinorTicks = true,
                DrawMajorGridLines = true,
                DrawMinorGridLines = true,
                DrawLabels = true,
                MajorTickLineLength = 5,
                MajorTickLineStyle = new SCISolidPenStyle(UIColor.Green, 1),
                MinorTickLineLength = 2,
                MinorTickLineStyle = new SCISolidPenStyle(UIColor.Yellow, 0.5f, new NSNumber[] { 10, 3, 10, 3 }),
            };

            // Create the Right YAxis withs tyles
            var yRightAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(min: 0.1, max: 0.1),
                AxisAlignment = SCIAxisAlignment.Right,
                AutoRange = SCIAutoRange.Always,
                AxisId = "PrimaryAxisId",
                // Brushes and styles for the Right YAxis, horizontal gridlines, horizontal tick marks, horizontal axis bands and right yaxis labels
                AxisBandsStyle = new SCISolidBrushStyle(0x55ff6655),
                MajorGridLineStyle = new SCISolidPenStyle(UIColor.Green, 1),
                MinorGridLineStyle = new SCISolidPenStyle(UIColor.Yellow, 0.5f, new NSNumber[] { 10, 3, 10, 3 }),
                TickLabelStyle = new SCIFontStyle(12, UIColor.Green),
                LabelProvider = new ThousandsLabelProvider(), // see LabelProvider API documentation for more info
                DrawMajorTicks = true,
                DrawMinorTicks = true,
                DrawMajorGridLines = true,
                DrawMinorGridLines = true,
                DrawLabels = true,
                MajorTickLineLength = 3,
                MajorTickLineStyle = new SCISolidPenStyle(UIColor.Purple, 1),
                MinorTickLineLength = 2,
                MinorTickLineStyle = new SCISolidPenStyle(UIColor.Red, 0.5f),
            };

            // Create the left YAxis
            var yLeftAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0, 3),
                AxisAlignment = SCIAxisAlignment.Left,
                AutoRange = SCIAutoRange.Always,
                AxisId = "SecondaryAxisId",
                // Brushes and styles for the Left YAxis, horizontal gridlines, horizontal tick marks, horizontal axis bands and left yaxis labels
                LabelProvider = new BillionsLabelProvider(), // see LabelProvider API documentation for more info
                TickLabelStyle = new SCIFontStyle(12, UIColor.Green),
                DrawMajorBands = false,
                DrawMajorGridLines = false,
                DrawMinorGridLines = false,
                DrawMajorTicks = true,
                DrawMinorTicks = true,
                DrawLabels = true,
                MajorTickLineLength = 3,
                MajorTickLineStyle = new SCISolidPenStyle(UIColor.Black, 1),
                MinorTickLineLength = 2,
                MinorTickLineStyle = new SCISolidPenStyle(UIColor.Black, 0.5f),
            };

            // Create and populate data series
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

            var mountainSeries = new SCIFastMountainRenderableSeries
            {
                DataSeries = mountainDataSeries,
                YAxisId = "PrimaryAxisId",
                // Mountain series area fill
                AreaStyle = new SCISolidBrushStyle(0xA000D0D0),
                // Mountain series line (just on top of mountain). If set to nil, there will be no line
                StrokeStyle = new SCISolidPenStyle(0xFF00D0D0, 2),
                // Setting to true gives jagged mountains. set to false if you want regular mountain chart
                IsDigitalLine = true
            };
            var lineSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = lineDataSeries,
                YAxisId = "PrimaryAxisId",
                // Line series color and thickness
                StrokeStyle = new SCISolidPenStyle(0xFF0000FF, 3),
                // Setting to true gives jagged line. set to false if you want regular line chart
                IsDigitalLine = false,
                // Point marers at data points. set to nil if you don't need them
                PointMarker = new SCIEllipsePointMarker { Size = new CGSize(7, 7) },
            };
            var columnSeries = new SCIFastColumnRenderableSeries
            {
                DataSeries = columnDataSeries,
                YAxisId = "SecondaryAxisId",
                // Column series fill color
                FillBrushStyle = new SCISolidBrushStyle(0xE0D030D0),
                // column series outline color and width. It is set to nil to disable outline
                StrokeStyle = null
            };
            var candlestickSeries = new SCIFastCandlestickRenderableSeries
            {
                DataSeries = candlestickDataSeries,
                YAxisId = "PrimaryAxisId",
                // Candlestick series has separate color for data where close is higher that open value (up) and oposite when close is lower than open (down)
                // Candlestick stroke color and thicknes for "up" data
                StrokeUpStyle = new SCISolidPenStyle(0xFF00FF00, 1),
                // Candlestick fill color for "up" data
                FillUpBrushStyle = new SCISolidBrushStyle(0x7000FF00),
                // Candlestick stroke color and thicknes for "down" data
                StrokeDownStyle = new SCISolidPenStyle(0xFFFF0000, 1),
                // Candlestick fill color for "down" data
                FillDownBrushStyle = new SCISolidBrushStyle(0xFFFF0000),
            };

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
            }
        }
    }
}