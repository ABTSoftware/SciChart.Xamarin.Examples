using Android.App;
using System.Drawing;
using Android.OS;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Math = System.Math;

namespace Tutorial03_AddSeries
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
            for (var i = 0; i < 1000; i++)
            {
                lineData.Append(i, Math.Sin(i * 0.1));
                scatterData.Append(i, Math.Cos(i * 0.1));
            }

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
        }
    }
}

