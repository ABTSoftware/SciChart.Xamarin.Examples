using System.Timers;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Core.Framework;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Tutorial06_AddNewRealtimeValues;
using Math = System.Math;

namespace Tutorial06_AddRealtimeUpdates
{
    [Activity(Label = "Xamarin.Android.Tutorial", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our chart from the layout resource,
            var chart = FindViewById<SciChartSurface>(Resource.Id.Chart);

            // Create a numeric X axis
            var xAxis = new NumericAxis(this) { AxisTitle = "Number of Samples (per Series)" };

            // Create a numeric Y axis
            var yAxis = new NumericAxis(this)
            {
                AxisTitle = "Value",
                VisibleRange = new DoubleRange(-1, 1)
            };

            // Add xAxis to the XAxes collection of the chart
            chart.XAxes.Add(xAxis);

            // Add yAxis to the YAxes collection of the chart
            chart.YAxes.Add(yAxis);

            // Create XyDataSeries to host data for our chart
            var lineData = new XyDataSeries<double, double>() { SeriesName = "Sin(x)" };
            var scatterData = new XyDataSeries<double, double>() { SeriesName = "Cos(x)" };

            // Append data which should be drawn
            var timer = new Timer(30) { AutoReset = true };

            // Update on each tick of timer
            timer.Elapsed += (s, e) =>
            {
                using (chart.SuspendUpdates())
                {
                    var x = lineData.Count;
                    lineData.Append(x, Math.Sin(x * 0.1));
                    scatterData.Append(x, Math.Cos(x * 0.1));

                    // zoom series to fit viewport size into XAxis direction
                    chart.ZoomExtentsX();
                }
            };

            timer.Start();

            var lineSeries = new FastLineRenderableSeries()
            {
                DataSeries = lineData,
                StrokeStyle = new SolidPenStyle(Color.LightBlue, 2)
            };

            // Create scatter series with data appended into scatterData
            var scatterSeries = new XyScatterRenderableSeries()
            {
                DataSeries = scatterData,
                PointMarker = new EllipsePointMarker()
                {
                    Width = 10,
                    Height = 10,
                    StrokeStyle = new SolidPenStyle(Color.Green, 2),
                    FillStyle = new SolidBrushStyle(Color.LightBlue)
                }
            };

            // Add the renderable series to the RenderableSeries collection of the chart
            chart.RenderableSeries.Add(lineSeries);
            chart.RenderableSeries.Add(scatterSeries);

            // Create interactivity modifiers
            var pinchZoomModifier = new PinchZoomModifier();
            pinchZoomModifier.SetReceiveHandledEvents(true);

            var zoomPanModifier = new ZoomPanModifier();
            zoomPanModifier.SetReceiveHandledEvents(true);

            var zoomExtentsModifier = new ZoomExtentsModifier();
            zoomExtentsModifier.SetReceiveHandledEvents(true);

            var yAxisDragModifier = new YAxisDragModifier();
            yAxisDragModifier.SetReceiveHandledEvents(true);

            // Create and configure legend
            var legendModifier = new LegendModifier(this);
            legendModifier.SetLegendPosition(GravityFlags.Bottom | GravityFlags.CenterHorizontal, 10);
            legendModifier.SetOrientation(Orientation.Horizontal);

            // Create RolloverModifier to show tooltips
            var rolloverModifier = new RolloverModifier();
            rolloverModifier.SetReceiveHandledEvents(true);

            // Create modifier group from declared modifiers
            var modifiers = new ModifierGroup(pinchZoomModifier, zoomPanModifier, zoomExtentsModifier, yAxisDragModifier, rolloverModifier, legendModifier);

            // Add the interactions to the ChartModifiers collection of the chart
            chart.ChartModifiers.Add(modifiers);
        }
    }
}

