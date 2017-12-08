using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using SciChart.Examples.Demo.Application;
using Xamarin.Examples.Demo.Droid.Application;
namespace Xamarin.Examples.Demo.Droid
{
    [Activity(Label = "Xamarin Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView listView;
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
            SetContentView(Resource.Layout.MainView);
            listView = FindViewById<ListView>(Resource.Id.examplesList);
            listView.ChoiceMode = ChoiceMode.Single;
            listView.Adapter = new ExampleAdapter(this);
            listView.ItemClick += (s, e) =>
            {
                OpenExample(e.Position);
            };
        }
        private void OpenExample(int exampleIndex)
        {
            var example = ExampleManager.Instance.Examples[exampleIndex];
            var intent = new Intent(this, typeof(ExampleActivity));
            intent.PutExtra(DemoKeys.ExampleId, example.Title);
            StartActivityForResult(intent, 1);
            OverridePendingTransition(Resource.Animation.abc_grow_fade_in_from_bottom, Resource.Animation.abc_shrink_fade_out_from_bottom);
        }
    }
}
