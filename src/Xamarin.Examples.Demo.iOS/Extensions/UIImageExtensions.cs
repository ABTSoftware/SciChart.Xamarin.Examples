using CoreGraphics;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public static class UIImageExtensions
    {
        public static SCIBitmap ToBitmap(this UIImage image)
        {
            var size = new CGSize(image.Size.Width * UIScreen.MainScreen.NativeScale, image.Size.Height * UIScreen.MainScreen.NativeScale);
            var rect = new CGRect(CGPoint.Empty, size);
            var bitmap = new SCIBitmap(size);

            bitmap.Context.DrawImage(rect, image.CGImage);

            return bitmap;
        }
    }
}
