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
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Android.Graphics;

using Color = System.Drawing.Color;
using AndroidColor = Android.Graphics.Color;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Custom Styling via API", description: "Change all chart styles and colors programmatically", icon: ExampleIcon.Themes)]
    public class CustomStylingFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            // Initializes the SCIChartSurface with Left YAxis, right YAxis and single XAxis 
            SetupSurface();
            SetupAxes();
            SetupRenderableSeries();
        }

        private void SetupSurface()
        {
            // surface background. If you set color for chart background than it is color only for axes area
            Surface.SetBackgroundColor(AndroidColor.Orange);
            // chart area (viewport) background fill color            
            Surface.RenderableSeriesAreaFillStyle = new SolidBrushStyle(color: 0xFFFFB6C1);
            // chart area border color and thickness
            Surface.RenderableSeriesAreaBorderStyle = new SolidPenStyle(color: 0xFF4682b4, thickness: 2);
        }

        private void SetupAxes()
        {
            // Brushes and styles for the XAxis, vertical gridlines, vertical tick marks, vertical axis bands and xaxis labels
            var xAxisGridBandBrush = new SolidBrushStyle(color: 0x55ff6655);
            var xAxisMajorGridLineBrush = new SolidPenStyle(color: Color.Green, thickness: 1);
            var xAxisMinorGridLineBrush = new SolidPenStyle(color: Color.Yellow, thickness: 0.5f, strokeDashArray: new float[] { 10, 3, 10, 3 }, antiAliasing:true);
            var xAxisMajorTickBrush = new SolidPenStyle(color: Color.Green, thickness: 1);
            var xAxisMinorTickBrush = new SolidPenStyle(color: Color.Yellow, thickness: 0.5f, strokeDashArray: new float[] { 10, 3, 10, 3 }, antiAliasing: true);
            var xAxisFontName = "Helvetica";
            var xAxisFontSize = 14.0f;
            var xAxisDrawLabels = true;
            var xAxisDrawMajorTicks = true;
            var xAxisDrawMinorTicks = true;
            var xAxisDrawMajorGridlines = true;
            var xAxisDrawMinorGridlines = true;

            // Create the XAxis
            var xAxis = new NumericAxis(Activity);
            xAxis.GrowBy = new DoubleRange(min: 0.1, max: 0.1);
            xAxis.VisibleRange = new DoubleRange(min: 150, max: 180);

            // Apply styles to the XAxis (see above)
            xAxis.AxisBandsStyle = xAxisGridBandBrush;
            xAxis.MajorGridLineStyle = xAxisMajorGridLineBrush;
            xAxis.MinorGridLineStyle = xAxisMinorGridLineBrush;
            xAxis.TickLabelStyle = new FontStyle(Typeface.Create(xAxisFontName, TypefaceStyle.Normal), xAxisFontSize, Color.Black);            
            xAxis.DrawMajorTicks = xAxisDrawMajorTicks;
            xAxis.DrawMinorTicks = xAxisDrawMinorTicks;
            xAxis.DrawMajorGridLines = xAxisDrawMajorGridlines;
            xAxis.DrawMinorGridLines = xAxisDrawMinorGridlines;
            xAxis.DrawLabels = xAxisDrawLabels;
            xAxis.MajorTickLineLength = 5;
            xAxis.MajorTickLineStyle = xAxisMajorTickBrush;
            xAxis.MinorTickLineLength = 2;
            xAxis.MinorTickLineStyle = xAxisMinorTickBrush;

            // Brushes and styles for the Right YAxis, horizontal gridlines, horizontal tick marks, horizontal axis bands and right yaxis labels
            var yRightAxisMajorTickBrush = new SolidPenStyle(color: Color.Purple, thickness: 1);
            var yRightAxisMinorTickBrush = new SolidPenStyle(color: Color.Red, thickness: 0.5f);
            var yRightAxisMajorBandBrush = new SolidBrushStyle(color: 0x55ff6655);
            var yRightAxisMajorGridLineBrush = new SolidPenStyle(color: Color.Green, thickness: 1);
            var yRightAxisMinorGridLineBrush = new SolidPenStyle(color: Color.Yellow, thickness: 0.5f, strokeDashArray: new float[] { 10, 3, 10, 3 }, antiAliasing:true);
            var yRightAxisLabelFormatter = new ThousandsLabelProvider(); // see LabelProvider API documentation for more info
            var yRightAxisLabelColor = Color.Green;
            var yRightAxisFontSize = 12.0f;
            var yRightAxisDrawLabels = true;
            var yRightAxisDrawMajorTicks = true;
            var yRightAxisDrawMinorTicks = true;
            var yRightAxisDrawMajorGridlines = true;
            var yRightAxisDrawMinorGridlines = true;

            // Create the Right YAxis
            var yRightAxis = new NumericAxis(Activity);
            yRightAxis.GrowBy = new DoubleRange(min: 0.1, max: 0.1);
            yRightAxis.AxisAlignment = AxisAlignment.Right;
            yRightAxis.AutoRange = AutoRange.Always;

            yRightAxis.AxisId = "PrimaryAxisId";

            // Apply styles to the Right YAxis (see above)
            yRightAxis.AxisBandsStyle = yRightAxisMajorBandBrush;
            yRightAxis.MajorGridLineStyle = yRightAxisMajorGridLineBrush;
            yRightAxis.MinorGridLineStyle = yRightAxisMinorGridLineBrush;
            yRightAxis.LabelProvider = yRightAxisLabelFormatter;
            yRightAxis.TickLabelStyle = new FontStyle(Typeface.Create("Arial", TypefaceStyle.Normal), yRightAxisFontSize, yRightAxisLabelColor);            
            yRightAxis.MajorTickLineLength = 3;
            yRightAxis.MajorTickLineStyle = yRightAxisMajorTickBrush;
            yRightAxis.MinorTickLineLength = 2;
            yRightAxis.MinorTickLineStyle = yRightAxisMinorTickBrush;
            yRightAxis.DrawMajorTicks = yRightAxisDrawMajorTicks;
            yRightAxis.DrawMinorTicks = yRightAxisDrawMinorTicks;
            yRightAxis.DrawMajorGridLines = yRightAxisDrawMajorGridlines;
            yRightAxis.DrawMinorGridLines = yRightAxisDrawMinorGridlines;
            yRightAxis.DrawLabels = yRightAxisDrawLabels;

            // Brushes and styles for the Left YAxis, horizontal gridlines, horizontal tick marks, horizontal axis bands and left yaxis labels
            var yLeftAxisMajorTickBrush = new SolidPenStyle(color: Color.Black, thickness: 1);
            var yLeftAxisMinorTickBrush = new SolidPenStyle(color: Color.Black, thickness: 0.5f);
            var yLeftAxisLabelFormatter = new BillionsLabelProvider(); // See LabelProvider API documentation
            var yLeftAxisLabelColor = Color.DarkGray;
            var yLeftAxisFontSize = 12.0f;
            var yLeftAxisDrawMajorBands = false;
            var yLeftAxisDrawLabels = true;
            var yLeftAxisDrawMajorTicks = true;
            var yLeftAxisDrawMinorTicks = true;
            var yLeftAxisDrawMajorGridlines = false;
            var yLeftAxisDrawMinorGridlines = false;


            // Create the left YAxis
            var yLeftAxis = new NumericAxis(Activity);
            yLeftAxis.GrowBy = new DoubleRange(min: 0, max: 3);
            yLeftAxis.AxisAlignment = AxisAlignment.Left;
            yLeftAxis.AutoRange = AutoRange.Always;
            yLeftAxis.AxisId = "SecondaryAxisId";

            // Apply styles to the left YAxis (see above)
            yLeftAxis.DrawMajorBands = yLeftAxisDrawMajorBands;
            yLeftAxis.DrawMajorGridLines = yLeftAxisDrawMajorGridlines;
            yLeftAxis.DrawMinorGridLines = yLeftAxisDrawMinorGridlines;
            yLeftAxis.DrawMajorTicks = yLeftAxisDrawMajorTicks;
            yLeftAxis.DrawMinorTicks = yLeftAxisDrawMinorTicks;
            yLeftAxis.DrawLabels = yLeftAxisDrawLabels;
            yLeftAxis.LabelProvider = yLeftAxisLabelFormatter;
            yRightAxis.TickLabelStyle = new FontStyle(Typeface.Create("Arial", TypefaceStyle.Normal), yLeftAxisFontSize, yLeftAxisLabelColor);            
            yLeftAxis.MajorTickLineLength = 3;
            yLeftAxis.MajorTickLineStyle = yLeftAxisMajorTickBrush;
            yLeftAxis.MinorTickLineLength = 2;
            yLeftAxis.MinorTickLineStyle = yLeftAxisMinorTickBrush;

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

            var mountainSeries = new FastMountainRenderableSeries { DataSeries = mountainDataSeries, YAxisId = "PrimaryAxisId" };
            var lineSeries = new FastLineRenderableSeries { DataSeries = lineDataSeries, YAxisId = "PrimaryAxisId" };
            var columnSeries = new FastColumnRenderableSeries { DataSeries = columnDataSeries, YAxisId = "SecondaryAxisId" };
            var candlestickSeries = new FastCandlestickRenderableSeries { DataSeries = candlestickDataSeries, YAxisId = "PrimaryAxisId" };

            var legendModifier = new LegendModifier(Activity);
            legendModifier.SetShowCheckboxes(false);

            using (Surface.SuspendUpdates())
            {
                Surface.RenderableSeries.Add(mountainSeries);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(columnSeries);
                Surface.RenderableSeries.Add(candlestickSeries);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    legendModifier,
                    new CursorModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };

                new ScaleAnimatorBuilder(mountainSeries, 10500d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
                new ScaleAnimatorBuilder(candlestickSeries, 11700d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
                new ScaleAnimatorBuilder(lineSeries, 12250d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
                new ScaleAnimatorBuilder(columnSeries, 10500d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
            }
        }
    }
}