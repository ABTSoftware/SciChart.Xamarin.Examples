using System.Timers;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.OS;
using Java.Lang;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Core.Model;
using SciChart.Core.Utility;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Math = System.Math;
using Orientation = SciChart.Core.Framework.Orientation;

namespace Xamarin.Android.Tutorial
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

            // Get the second chart from the layout resource.
            var secondChart = FindViewById<SciChartSurface>(Resource.Id.SecondChart);

            InitChart(chart);
            InitChart(secondChart);

            const int fifoCapacity = 500;

            // Create XyDataSeries to host data for our chart
            var lineData = new XyDataSeries<double, double>() { SeriesName = "Sin(x)", FifoCapacity = new Integer(fifoCapacity) };
            var scatterData = new XyDataSeries<double, double>() { SeriesName = "Cos(x)", FifoCapacity = new Integer(fifoCapacity) };

            //            // Append data which should be drawn
            //            for (var i = 0; i < 1000; i++)
            //            {
            //                lineData.Append(i, Math.Sin(i*0.1));
            //                scatterData.Append(i, Math.Cos(i*0.1));
            //            }

            double phase = 0;

            var timer = new Timer(30) { AutoReset = true };
            var lineBuffer = new DoubleValues(1000);
            var scatterBuffer = new DoubleValues(1000);

            // Update on each tick of timer
            //            timer.Elapsed += (s, e) =>
            //            {
            //                lineBuffer.Clear();
            //                scatterBuffer.Clear();
            //                for (int i = 0; i < 1000; i++)
            //                {
            //                    lineBuffer.Add(Math.Sin(i*0.1 + phase));
            //                    scatterBuffer.Add(Math.Cos(i*0.1 + phase));
            //                }
            //
            //                using (chart.SuspendUpdates())
            //                {
            //                    lineData.UpdateRangeYAt(0, lineBuffer);
            //                    scatterData.UpdateRangeYAt(0, scatterBuffer);
            //                }
            //
            //                phase += 0.01;
            //            };

            //
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
                            Background = new ColorDrawable(Color.DarkGreen),
                            ZIndex = 1,
                            YAxisId = x % 200 == 0 ? AxisBase.DefaultAxisId : "SecondaryAxis"
                        };

                        Dispatcher.PostOnUiThread(new Runnable(() =>
                        {
                // add label into annotation collection
                chart.Annotations.Add(label);
                        }));

            // if we add annotation and x > fifoCapacity 
            // then we need to remove annotation which goes out of the screen
            if (x > fifoCapacity)
                            Dispatcher.PostOnUiThread(new Runnable(() =>
                            {
                                chart.Annotations.Remove(0);
                            }));
                    }
                    // zoom series to fit viewport size into XAxis direction

                    chart.ZoomExtentsX();

                    x++;

                    if (x == 1000)
                        timer.Stop();
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


            var mountainSeries = new FastMountainRenderableSeries()
            {
                DataSeries = scatterData,
                StrokeStyle = new SolidPenStyle(Color.LightSteelBlue),
                AreaStyle = new SolidBrushStyle(Color.SteelBlue),
            };

            // Add the renderable series to the RenderableSeries collection of the chart
            chart.RenderableSeries.Add(lineSeries);
            chart.RenderableSeries.Add(scatterSeries);

            // Add the renderable series to the RenderableSeries collection of the second chart
            secondChart.RenderableSeries.Add(mountainSeries);

            // Share chart's XAxis VisibleRange with secondChart's X            
            secondChart.XAxes[0].VisibleRange = chart.XAxes[0].VisibleRange;
        }

        private void InitChart(SciChartSurface chart)
        {
            // Create a numeric X axis
            var xAxis = new NumericAxis(this) { AxisTitle = "Number of Samples (per Series)" };

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

            // Create interactivity modifiers
            var pinchZoomModifier = new PinchZoomModifier();
            pinchZoomModifier.SetReceiveHandledEvents(true);

            var zoomPanModifier = new ZoomPanModifier();
            zoomPanModifier.SetReceiveHandledEvents(true);

            var zoomExtentsModifier = new ZoomExtentsModifier();
            zoomExtentsModifier.SetReceiveHandledEvents(true);

            // Create RolloverModifier to show tooltips
            var rolloverModifier = new RolloverModifier();
            rolloverModifier.SetReceiveHandledEvents(true);

            var yAxisDragModifier = new YAxisDragModifier();
            yAxisDragModifier.SetReceiveHandledEvents(true);

            // Create and configure legend
            var legendModifier = new LegendModifier(this);
            legendModifier.SetLegendPosition(GravityFlags.Bottom | GravityFlags.CenterHorizontal, 10);
            legendModifier.SetOrientation(Orientation.Horizontal);

            var modifiers = new ModifierGroup(pinchZoomModifier, zoomPanModifier, zoomExtentsModifier, rolloverModifier,
                legendModifier, yAxisDragModifier);

            modifiers.SetReceiveHandledEvents(true);
            modifiers.MotionEventGroup = "SharedEvents";

            // Add xAxis to the XAxes collection of the chart
            chart.XAxes.Add(xAxis);

            // Add yAxis to the YAxes collection of the chart
            chart.YAxes.Add(yAxis);

            // Add secondaryYAxis to the YAxes collection of the chart
            chart.YAxes.Add(secondaryYAxis);

            // Add the interactions to the ChartModifiers collection of the chart
            chart.ChartModifiers.Add(modifiers);
        }
    }
}

