using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Examples.Demo.Droid.Application;

namespace Xamarin.Examples.Demo.Droid
{
    [Activity(Label = "Xamarin Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class StartupActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set your trial or purchased license key here!
            // 
            // If you don't have a trial key you can get one from www.scichart.com/licensing-scichart-android
            // 
            // Use code similar to the following: 
            // 
            // var licensingContract = @"Get your license from www.scichart.com/licensing-scichart-android";
            // SciChart.Charting.Visuals.SciChartSurface.SetRuntimeLicenseKey(licensingContract);

            SetContentView(Resource.Layout.startup_activity);

            FindViewById(Resource.Id.charts2dCard).Click += Open2DExamples;
            FindViewById(Resource.Id.charts3dCard).Click += Open3DExamples;
            FindViewById(Resource.Id.featuredChartsCard).Click += OpenFeaturedExamples;
        }

        private void Open2DExamples(object sender, EventArgs e)
        {
            OpenExampleListActivity(DemoKeys.Charts2D);
        }

        private void Open3DExamples(object sender, EventArgs e)
        {
            OpenExampleListActivity(DemoKeys.Charts3D);
        }

        private void OpenFeaturedExamples(object sender, EventArgs e)
        {
            OpenExampleListActivity(DemoKeys.Featured);
        }

        private void OpenExampleListActivity(string category)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra(DemoKeys.CategoryId, category);
            StartActivity(intent);
        }
    }

}