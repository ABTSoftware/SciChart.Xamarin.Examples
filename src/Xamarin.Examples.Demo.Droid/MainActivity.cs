using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Application;

namespace Xamarin.Examples.Demo.Droid
{
    [Activity(Label = "Xamarin Demo", MainLauncher = true, Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
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
            listView.Adapter = new ExampleAdapter(this, ExampleManager.Instance.Examples);

            var examples2dButton = FindViewById<RadioButton>(Resource.Id.examples2dButton);
            var examples3dButton = FindViewById<RadioButton>(Resource.Id.examples3dButton);

            examples2dButton.Click += (s, e) =>
            {
                listView.Adapter = new ExampleAdapter(this, ExampleManager.Instance.Examples);
            };

            examples3dButton.Click += (s, e) =>
            {
                listView.Adapter = new ExampleAdapter(this, ExampleManager.Instance.Examples3D);
            };

            listView.ItemClick += (s, e) =>
            {
                OpenExample(e.Position);
            };
        }

        private void OpenExample(int exampleIndex)
        {
            var adapter = listView.Adapter as ExampleAdapter;
            if (adapter != null)
            {
                var example = adapter[exampleIndex];

                var intent = new Intent(this, typeof(ExampleActivity));
                intent.PutExtra(DemoKeys.ExampleId, example.Title);
                intent.PutExtra(DemoKeys.IsExample3D, example.IsExample3D);

                StartActivityForResult(intent, 1);
                OverridePendingTransition(Resource.Animation.abc_grow_fade_in_from_bottom, Resource.Animation.abc_shrink_fade_out_from_bottom);
            }
        }
    }
}