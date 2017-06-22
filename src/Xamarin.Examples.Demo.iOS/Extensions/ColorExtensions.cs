using UIKit;
using Xamarin.Examples.Demo.Extensions;

namespace Xamarin.Examples.Demo.iOS
{
    public static class ColorExtensions
    {
        public static UIColor ToColor(this uint colorUInt)
        {
            return UIColor.FromRGBA(colorUInt.R(), colorUInt.G(), colorUInt.B(), colorUInt.A());
        }
    }
}