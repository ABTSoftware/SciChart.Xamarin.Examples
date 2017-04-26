using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using SciChart.Examples.Demo.Application;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Xamarin.Examples.Demo.Droid
{
    [Activity(Label = "ExampleActivity")]
    public class ExampleActivity : AppCompatActivity
    {
        private Example _example;
        private ExampleBaseFragment _exampleFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Example_Activity);

            var toolbar = FindViewById<Toolbar>(Resource.Id.exampleToolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);    
                this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);                    
                this.SupportActionBar.SetDisplayShowHomeEnabled(true);

                toolbar.NavigationClick += (s, e) =>
                {
                    this.OnBackPressed();
                };
            }
            SetUpExample(savedInstanceState);            
        }

        private void SetUpExample(Bundle savedInstanceState)
        {
            var exampleId = Intent.GetStringExtra(DemoKeys.ExampleId);
            _example = ExampleManager.Instance.GetExampleByTitle(exampleId);

            Title = _example.Title;
            FindViewById<TextView>(Resource.Id.exampleTitle).Text = Title;

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