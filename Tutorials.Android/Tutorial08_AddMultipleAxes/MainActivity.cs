using System.Timers;
using Android.App;
using System.Drawing;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Java.Lang;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using FontStyle = SciChart.Drawing.Common.FontStyle;
using Math = System.Math;
using Orientation = SciChart.Core.Framework.Orientation;

namespace Tutorial08_AddMultipleAxes
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
            var xAxis = new NumericAxis(this) {AxisTitle = "Number of Samples (per Series)"};

            // Create a numeric Y axis
            var yAxis = new NumericAxis(this)
            {
                AxisTitle = "Value",
                VisibleRange = new DoubleRange(-1, 1)
            };

            // Create a secondary numeric Y Axis
            var secondaryYAxis = new NumericAxis(this)
            {
                AxisTitle = "Secondary",
                AxisId = "SecondaryAxis",
                AxisAlignment = AxisAlignment.Left,
                VisibleRange = new DoubleRange(-2, 2)
            };

            // Add xAxis to the XAxes collection of the chart
            chart.XAxes.Add(xAxis);

            // Add yAxis to the YAxes collection of the chart
            chart.YAxes.Add(yAxis);

            // Add secondaryYAxis to the YAxes collection of the chart
            chart.YAxes.Add(secondaryYAxis);

            const int fifoCapacity = 500;

            // Create XyDataSeries to host data for our chart
            var lineData =
                new XyDataSeries<double, double>() {SeriesName = "Sin(x)", FifoCapacity = new Integer(fifoCapacity)};
            var scatterData =
                new XyDataSeries<double, double>() {SeriesName = "Cos(x)", FifoCapacity = new Integer(fifoCapacity)};

            var timer = new Timer(30) {AutoReset = true};

            var x = lineData.Count;

            // Append on each tick of timer
            timer.Elapsed += (s, e) =>
            {
                using (chart.SuspendUpdates())
                {
                    lineData.Append(x, Math.Sin(x * 0.1));
                    scatterData.Append(x, Math.Cos(x * 0.1));

                    // add label every 100 data points
                    if (x % 100 == 0)
                    {
                        // create text annotation with label
                        var label = new TextAnnotation(this)
                        {
                            Text = "N",
                            X1Value = x,
                            Y1Value = 0,
                            HorizontalAnchorPoint = HorizontalAnchorPoint.Center,
                            VerticalAnchorPoint = VerticalAnchorPoint.Center,
                            FontStyle = new FontStyle(20, Color.White),
                            Background = new ColorDrawable(Android.Graphics.Color.DarkGreen),
                            ZIndex = 1,
                            YAxisId = x % 200 == 0 ? AxisBase.DefaultAxisId : "SecondaryAxis"
                        };

                        // add label into annotation collection
                        chart.Annotations.Add(label);

                        // if we add annotation and x > fifoCapacity
                        // then we need to remove annotation which goes out of the screen
                        if (x > fifoCapacity)
                            chart.Annotations.Remove(0);
                    }

                    // zoom series to fit viewport size into XAxis direction
                    chart.ZoomExtentsX();
                    x++;
                }
            };

            timer.Start();

            // Create line series with data appended into lineData
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
                },
                YAxisId = "SecondaryAxis"
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

