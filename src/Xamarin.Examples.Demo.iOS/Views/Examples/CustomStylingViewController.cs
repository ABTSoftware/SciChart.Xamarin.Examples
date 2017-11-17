using System;
using System.Linq;
using Foundation;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Components;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Custom Styling via API", description: "Change all chart styles and colors programmatically", icon: ExampleIcon.Themes)]
    public partial class CustomStylingViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);       

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            // Initializes the SCIChartSurface with Left YAxis, right YAxis and single XAxis 
            // 
            SetupSurface();
            SetupAxes();
            SetupRenderableSeries();
        }

        private void SetupSurface()
        {
            // surface background. If you set color for chart background than it is color only for axes area
            Surface.BackgroundColor = UIColor.Orange;
            // chart area (viewport) background fill color
            Surface.RenderableSeriesAreaFill = new SCISolidBrushStyle(colorCode: 0xFFFFB6C1);
            // chart area border color and thickness
            Surface.RenderableSeriesAreaBorder = new SCISolidPenStyle(colorCode: 0xFF4682b4, thickness: 2); 
        }        

        private void SetupAxes()
        {            
            // Create the XAxis
            var xAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(min: 0.1, max: 0.1),
                VisibleRange = new SCIDoubleRange(min: 150, max: 180),
                Style =
                {
                    GridBandBrush = new SCISolidBrushStyle(colorCode: 0x55ff6655),
                    MajorGridLineBrush = new SCISolidPenStyle(color: UIColor.Green, thickness: 1),
                    MinorGridLineBrush = new SCISolidPenStyle(color: UIColor.Yellow, thickness: 0.5f, strokeDashArray: new NSNumber[] { 10,3,10,3 }),
                    LabelStyle =
                    {
                        Color = UIColor.Purple,
                        FontName = "Helvetica",
                        FontSize = 14.0f
                    },
                    DrawMajorTicks = true,
                    DrawMinorTicks = true,
                    DrawMajorGridLines = true,
                    DrawMinorGridLines = true,
                    DrawLabels = true,
                    MajorTickSize = 5,
                    MajorTickBrush = new SCISolidPenStyle(color: UIColor.Green, thickness: 1),
                    MinorTickSize = 2,
                    MinorTickBrush = new SCISolidPenStyle(color: UIColor.Yellow, thickness: 0.5f, strokeDashArray: new NSNumber[] { 10,3,10,3 })
                }
            };            

            // Create the Right YAxis withs tyles
            var yRightAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(min: 0.1, max: 0.1),
                AxisAlignment = SCIAxisAlignment.Right,
                AutoRange = SCIAutoRange.Always,
                AxisId = "PrimaryAxisId",
                Style =
                {
                    GridBandBrush = new SCISolidBrushStyle(colorCode: 0x55ff6655),
                    MajorGridLineBrush = new SCISolidPenStyle(color: UIColor.Green, thickness: 1),
                    MinorGridLineBrush = new SCISolidPenStyle(color: UIColor.Yellow, thickness: 0.5f, strokeDashArray: new NSNumber[] { 10,3,10,3 }),
                    LabelStyle =
                    {
                        Color = UIColor.Green,
                        FontSize = 12.0f
                    },
                    MajorTickSize = 3,
                    MajorTickBrush = new SCISolidPenStyle(color: UIColor.Purple, thickness: 1),
                    MinorTickSize = 2,
                    MinorTickBrush = new SCISolidPenStyle(color: UIColor.Red, thickness: 0.5f),
                    DrawMajorTicks = true,
                    DrawMinorTicks = true,
                    DrawMajorGridLines = true,
                    DrawMinorGridLines = true,
                    DrawLabels = true,                     
                },
            };

            // Brushes and styles for the Left YAxis, horizontal gridlines, horizontal tick marks, horizontal axis bands and left yaxis labels


            // Create the left YAxis
            var yLeftAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(min: 0, max: 3),
                AxisAlignment = SCIAxisAlignment.Left,
                AutoRange = SCIAutoRange.Always,
                AxisId = "SecondaryAxisId",
                Style =
                {
                    DrawMajorBands = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false,
                    DrawMajorTicks = true,
                    DrawMinorTicks = true,
                    DrawLabels = true,
                    LabelStyle =
                    {
                        Color = UIColor.DarkGray,
                        FontSize = 12.0f
                    },
                    MajorTickSize = 3,
                    MajorTickBrush = new SCISolidPenStyle(color: UIColor.Black, thickness: 1),
                    MinorTickSize = 2,
                    MinorTickBrush = new SCISolidPenStyle(color: UIColor.Black, thickness: 0.5f)
                },
            };

            // Add the axes to the chart
            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yRightAxis);
            Surface.YAxes.Add(yLeftAxis);
        }

        private void SetupRenderableSeries()
        {
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

            var mountainRenderableSeries = new SCIFastMountainRenderableSeries { DataSeries = mountainDataSeries, YAxisId = "PrimaryAxisId" };
            var lineRenderableSeries = new SCIFastLineRenderableSeries { DataSeries = lineDataSeries, YAxisId = "PrimaryAxisId" };
            var columnRenderableSeries = new SCIFastColumnRenderableSeries { DataSeries = columnDataSeries, YAxisId = "SecondaryAxisId" };
            var candlestickRenderableSeries = new SCIFastCandlestickRenderableSeries { DataSeries = candlestickDataSeries, YAxisId = "PrimaryAxisId" };

            using (Surface.SuspendUpdates())
            {                
                Surface.RenderableSeries.Add(mountainRenderableSeries);
                Surface.RenderableSeries.Add(lineRenderableSeries);
                Surface.RenderableSeries.Add(columnRenderableSeries);
                Surface.RenderableSeries.Add(candlestickRenderableSeries);
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCILegendModifier {ShowCheckBoxes = false},
                    new SCICursorModifier(),
                    new SCIZoomExtentsModifier()
                };
            }
        }
    }
}