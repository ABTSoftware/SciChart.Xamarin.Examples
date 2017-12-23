using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Xamarin.Examples.Demo.Droid.Components
{
    public class SpinnerStringAdapter : ArrayAdapter<string>
    {
        private readonly LayoutInflater inflater;

        public SpinnerStringAdapter(Context context, int array)
            : base(context, Resource.Layout.example_sortby_spinner_top_item, context.Resources.GetStringArray(array))
        {
            inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
        }

        public SpinnerStringAdapter(Context context, IList<string> strings)
            : base(context, Resource.Layout.example_sortby_spinner_top_item, strings)
        {
            inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = inflater.Inflate(Resource.Layout.example_sortby_spinner_top_item, parent, false);

            var title = view.FindViewById<TextView>(Resource.Id.text);
            title.SetText(GetItem(position), TextView.BufferType.Normal);

            return view;
        }

        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            var view = inflater.Inflate(Resource.Layout.example_sortby_spinner_item, parent, false);

            var title = view.FindViewById<TextView>(Resource.Id.text);
            title.SetText(GetItem(position), TextView.BufferType.Normal);

            return view;
        }
    }
}