using Foundation;
using System;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class BorderedView : UIView
    {
        public BorderedView (IntPtr handle) : base (handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            Layer.CornerRadius = 2;
            Layer.BorderColor = new UIColor(217, 217, 193, 1).CGColor;
            Layer.BorderWidth = 1;
            ClipsToBounds = true;
        }
    }
}
