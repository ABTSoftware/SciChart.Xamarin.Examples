using Xamarin.Examples.Demo;
using Color = System.Drawing.Color;
using AndroidColor = Android.Graphics.Color;

namespace Xamarin.Examples.Demo.Droid
{
    public static class ColorExtensions
    {
        public static Color ToColor(this uint colorUInt)
        {
            return Color.FromArgb(colorUInt.A(), colorUInt.R(), colorUInt.G(), colorUInt.B());
        }

        public static Color ToColor(this int colorInt)
        {
            unchecked
            {
                var colorUInt = (uint)colorInt;
                return Color.FromArgb(colorUInt.A(), colorUInt.R(), colorUInt.G(), colorUInt.B());
            }
        }

        public static AndroidColor ToAndroidColor(this uint colorUInt)
        {
            return AndroidColor.Argb(colorUInt.A(), colorUInt.R(), colorUInt.G(), colorUInt.B());
        }

        public static AndroidColor ToAndroidColor(this int colorInt)
        {
            unchecked
            {
                var colorUInt = (uint)colorInt;
                return AndroidColor.Argb(colorUInt.A(), colorUInt.R(), colorUInt.G(), colorUInt.B());
            }
        }
    }
}