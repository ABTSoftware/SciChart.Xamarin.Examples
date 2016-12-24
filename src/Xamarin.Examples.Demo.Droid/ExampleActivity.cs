using System;
using Android.App;
using Android.OS;
using SciChart.Examples.Demo.Application;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid
{
    [Activity(Label = "ExampleActivity")]
    public class ExampleActivity : Activity
    {
        private Example _example;
        private ExampleBaseFragment _exampleFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Example_Activity);

            SetUpExample(savedInstanceState);
        }

        private void SetUpExample(Bundle savedInstanceState)
        {
            var exampleId = Intent.GetStringExtra(DemoKeys.ExampleId);
            _example = ExampleManager.Instance.GetExampleByTitle(exampleId);

            Title = _example.Title;

            if (savedInstanceState != null)
            {
                _exampleFragment = FragmentManager.FindFragmentByTag<ExampleBaseFragment>(DemoKeys.FragmentTag);
            }
            else
            {
                _exampleFragment = Activator.CreateInstance(_example.ExampleType) as ExampleBaseFragment;
            }

            if (_exampleFragment != null && !_exampleFragment.IsInLayout)
            {
                FragmentManager.BeginTransaction()
                    .Replace(Resource.Id.fragment_container, _exampleFragment, DemoKeys.FragmentTag)
                    .Commit();
            }
        }
    }
}