using Android.App;
using Android.OS;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;

namespace Tutorial02_CreateChart
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
        }
    }
}

