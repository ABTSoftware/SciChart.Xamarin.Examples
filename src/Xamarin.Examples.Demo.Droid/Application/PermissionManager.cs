using Android.App;
using Android.Content.PM;
using Android.Support.V4.App;
using Android.Support.V4.Content;

namespace Xamarin.Examples.Demo.Droid.Application
{
    public class PermissionManager
    {
        private const int ShowcaseRequestCode = 42;

        private readonly Activity _activity;

        public PermissionManager(Activity activity)
        {
            _activity = activity;
        }

        public void TryRequestPermission(string permission)
        {
            if (ContextCompat.CheckSelfPermission(_activity, permission) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(_activity, new []{permission}, ShowcaseRequestCode);
            }
        }
    }
}