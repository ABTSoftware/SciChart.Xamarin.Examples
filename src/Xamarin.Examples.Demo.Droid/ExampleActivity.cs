using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Orientation = Android.Content.Res.Orientation;
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

            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            if(Resources.Configuration.Orientation == Orientation.Landscape)
                Window.AddFlags(WindowManagerFlags.Fullscreen);

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
            var categoryId = Intent.GetStringExtra(DemoKeys.CategoryId);
            _example = ExampleManager.Instance.GetExampleByTitle(exampleId, categoryId);

            Title = _example.Title;
            FindViewById<TextView>(Resource.Id.exampleTitle).Text = Title;

            if (savedInstanceState != null)
            {
                _exampleFragment = SupportFragmentManager.FindFragmentByTag(DemoKeys.FragmentTag) as ExampleBaseFragment;
            }
            else
            {
                _exampleFragment = Activator.CreateInstance(_example.ExampleType) as ExampleBaseFragment;
            }

            if (_exampleFragment != null && !_exampleFragment.IsInLayout)
            {
                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.fragment_container, _exampleFragment, DemoKeys.FragmentTag)
                    .Commit();
            }
        }

        [Export("InitExampleForUiTest")]
        public void InitExampleForUiTest()
        {
            try
            {
                _exampleFragment?.InitExampleForUiTest();
            }
            catch (Exception e)
            {
                Log.Error("InitExampleForUiTest", e.Message, e);
            }
        }
    }
}