using Android.App;
using Android.OS;
using Android.Views;

namespace Xamarin.Examples.Demo.Droid.Fragments.Base
{
    public abstract class ExampleBaseFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(ExampleLayoutId, null);
        }

        public abstract int ExampleLayoutId { get; }

        public override void OnStart()
        {
            base.OnStart();

            InitExample();
        }

        protected abstract void InitExample();
    }
}