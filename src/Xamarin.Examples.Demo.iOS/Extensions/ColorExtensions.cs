using UIKit;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public static class ColorExtensions
    {
        public static UIColor ToUIColor(this uint colorUInt)
        {
            return UIColor.FromRGBA(colorUInt.R(), colorUInt.G(), colorUInt.B(), colorUInt.A());
        }

        public static UIColor ToUIColor(this int colorInt)
        {
            return ToUIColor((uint)colorInt);
        }

        public static uint Argb(this UIColor color, float opacity)
        {
            return color.Argb(color.ColorARGBCode(), opacity);
        }
    }
}