using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIPenSolid : NSObject <SCIPen2DProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIPenSolid : SCIPen2DProtocol
    {
        // -(id)initWithColor:(UIColor *)color Width:(float)width;
        [Export("initWithColor:Width:")]
        IntPtr Constructor(UIColor color, float width);

        // -(id)initWithColorCode:(unsigned int)color Width:(float)width;
        [Export("initWithColorCode:Width:")]
        IntPtr Constructor(uint color, float width);
    }
}