using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;

namespace Xamarin.Examples.Demo.Droid.Extensions
{
    public static class ContextExtensions
    {
        public static Drawable GetDrawableCompat(this Context context, int drawableId)
        {
            return ContextCompat.GetDrawable(context, drawableId);
        }
    }
}