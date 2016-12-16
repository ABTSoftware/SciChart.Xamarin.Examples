using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using SciChart.Examples.Demo.Application;

namespace Xamarin.Examples.Demo.Droid.Application
{
    public class ExampleAdapter : BaseAdapter<Example>
    {
        private readonly Activity _activity;
        private readonly List<Example> _examples;

        public ExampleAdapter(Activity activity)
        {
            _activity = activity;
            _examples = ExampleManager.Instance.Examples;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count => _examples.Count;

        public override Example this[int position] => _examples[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var example = _examples[position];

            var view = _activity.LayoutInflater.Inflate(Resource.Layout.Example_List_Item, null);

            view.FindViewById<TextView>(Resource.Id.exampleName).Text = example.Title;

            return view;
        }
    }
}