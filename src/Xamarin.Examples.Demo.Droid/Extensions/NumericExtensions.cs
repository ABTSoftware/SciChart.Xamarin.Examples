using System;
using Android.Content;
using Android.Util;

namespace Xamarin.Examples.Demo.Droid.Extensions
{
    public static class NumericExtensions
    {
        public static float ToDip(this float value, Context context)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, value, context.Resources.DisplayMetrics);
        }

        public static int ToDip(this int value, Context context)
        {
            var dipValue = TypedValue.ApplyDimension(ComplexUnitType.Dip, value, context.Resources.DisplayMetrics);
            return (int) Math.Round(dipValue);
        }

        public static float ToSp(this float value, Context context)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Sp, value, context.Resources.DisplayMetrics);
        }
    }
}