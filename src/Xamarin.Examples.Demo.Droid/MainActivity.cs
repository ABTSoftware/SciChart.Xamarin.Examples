using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using SciChart.Examples.Demo.Application;
using Xamarin.Examples.Demo.Droid.Application;

namespace Xamarin.Examples.Demo.Droid
{
    [Activity(Label = "Xamarin Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ListView.ChoiceMode = ChoiceMode.Single;

            ListView.Adapter = new ExampleAdapter(this);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            OpenExample(position);
        }

        private void OpenExample(int exampleIndex)
        {
            var example = ExampleManager.Instance.Examples[exampleIndex];

            var intent = new Intent(this, typeof(ExampleActivity));
            intent.PutExtra(DemoKeys.ExampleId, example.Title);

            StartActivityForResult(intent, 1);
        }
    }
}