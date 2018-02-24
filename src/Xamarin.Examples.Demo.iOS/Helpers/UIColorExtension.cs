using UIKit;

namespace Xamarin.Examples.Demo.iOS.Helpers
{
    public static class UIColorExtension
    {
        public static byte R(this UIColor color)
        {
            return (byte) (color.CGColor.Components[0]*255);
        }

        public static byte G(this UIColor color)
        {
            return (byte) (color.CGColor.Components[1]*255);
        }

        public static byte B(this UIColor color)
        {
            return (byte) (color.CGColor.Components[2]*255);
        }

        public static byte A(this UIColor color)
        {
            return (byte) (color.CGColor.Components[3]*255);
        }
    }
}