using Android.Graphics;
using Xamarin.Examples.Demo.Extensions;

namespace Xamarin.Examples.Demo.Droid
{
    public static class ColorExtensions
    {
        public static Color ToColor(this uint colorUInt)
        {
            return Color.Argb(colorUInt.A(), colorUInt.R(), colorUInt.G(), colorUInt.B());
        }
    }
}