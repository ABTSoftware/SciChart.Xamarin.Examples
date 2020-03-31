using System.Linq;
using System.Reflection;
using Android.App;
using Android.Content.PM;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Application
{
    public static class PermissionExtensions
    {
        public static bool AskForPermissions(this Activity activity, int requestCode, Example example)
        {
            var permissions = example.GetPermissions();

            return AskForPermissions(activity, requestCode, permissions);
        }

        private static string[] GetPermissions(this Example example)
        {
            var attribute = example.ExampleType.GetCustomAttributes<PermissionsDefinition>().FirstOrDefault();
            return attribute != null ? attribute.Permissions : new string[0];
        }

        public static bool AskForPermissions(this Activity activity, int requestCode, string[] permissions)
        {
            var hasPermissions = true;

            foreach (var permission in permissions)
            {
                hasPermissions &= ContextCompat.CheckSelfPermission(activity, permission) == Permission.Granted;
            }

            if (!hasPermissions)
            {
                ActivityCompat.RequestPermissions(activity, permissions, requestCode);
            }

            return hasPermissions;
        }
    }
}