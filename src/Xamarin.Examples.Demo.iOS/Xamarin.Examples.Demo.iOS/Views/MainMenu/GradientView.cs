using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class GradientView : UIView
    {
        public GradientView (IntPtr handle) : base (handle) { }

        [Export("layerClass")]
        public static ObjCRuntime.Class GetLayerClass()
        {
            return new ObjCRuntime.Class(typeof(CAGradientLayer));
        }

        [Export("awakeFromNib")]
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            CAGradientLayer gradientLayer = (CAGradientLayer)Layer;
            gradientLayer.Colors = new CGColor[] { 0xFF151515.ToUIColor().CGColor, 0xFF282929.ToUIColor().CGColor };
        }
    }
}