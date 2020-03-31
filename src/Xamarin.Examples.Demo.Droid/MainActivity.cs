using System.Linq;
using System.Reflection;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Xamarin.Examples.Demo.Droid.Application;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Xamarin.Examples.Demo.Droid
{
    [Activity(Label = "ExampleListActivity")]
    public class MainActivity : AppCompatActivity
    {
        private const int ExampleRequestCode = 42;

        private ListView _listView;
        private string _category = DemoKeys.Charts2D;

        private Example _example;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainView);

            var toolbar = FindViewById<Toolbar>(Resource.Id.appToolbar);
            SetSupportActionBar(toolbar);

            var actionBar = SupportActionBar;
            if (actionBar != null)
            {
                actionBar.SetDisplayShowHomeEnabled(true);
                actionBar.SetDisplayHomeAsUpEnabled(true);
                actionBar.SetHomeAsUpIndicator(GetDrawable(Resource.Drawable.ic_home_24dp));
            }

            toolbar.NavigationClick += (sender, args) => OnBackPressed();

            var categoryIcon = FindViewById<ImageView>(Resource.Id.category_icon);
            var categoryTitle = FindViewById<TextView>(Resource.Id.category_title);

            _listView = FindViewById<ListView>(Resource.Id.examplesList);
            _listView.ChoiceMode = ChoiceMode.Single;

            if (savedInstanceState != null)
            {
                _category = savedInstanceState.GetString(DemoKeys.CategoryId);
            }
            else
            {
                var extras = Intent.Extras;
                if (extras != null)
                    _category = extras.GetString(DemoKeys.CategoryId);
            }

            var examples = ExampleManager.Instance.GetExamplesByCategory(_category);

            int categoryIconDrawable;
            if (_category == DemoKeys.Featured)
                categoryIconDrawable = Resource.Drawable.ic_featured_icon_white;
            else if (_category == DemoKeys.Charts3D)
                categoryIconDrawable = Resource.Drawable.ic_3d_icon_white;
            else
                categoryIconDrawable = Resource.Drawable.ic_2d_icon_white;

            categoryIcon.SetImageResource(categoryIconDrawable);
            categoryTitle.Text = _category;

            _listView.Adapter = new ExampleAdapter(this, examples);

            _listView.ItemClick += (s, e) =>
            {
                OpenExample(e.Position);
            };
        }

        private void OpenExample(int exampleIndex)
        {
            var adapter = _listView.Adapter as ExampleAdapter;
            if (adapter != null)
            {
                _example = adapter[exampleIndex];

                if (this.AskForPermissions(ExampleRequestCode, _example))
                {
                    StartExampleActivity(_example);
                }
            }
        }

        private void StartExampleActivity(Example example)
        {
            var intent = new Intent(this, typeof(ExampleActivity));
            intent.PutExtra(DemoKeys.ExampleId, example.Title);
            intent.PutExtra(DemoKeys.CategoryId, _category);

            StartActivityForResult(intent, 1);
            OverridePendingTransition(Resource.Animation.abc_grow_fade_in_from_bottom,
                Resource.Animation.abc_shrink_fade_out_from_bottom);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            outState.PutString(DemoKeys.CategoryId, _category);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == ExampleRequestCode && _example != null)
            {
                StartExampleActivity(_example); 
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
}