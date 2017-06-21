using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    [BaseType(typeof(SCIBrushStyle))]
    interface SCISolidBrushStyle : SCIBrushStyle
    {
        // -(id)initWithColor:(UIColor *)color;
        [Export("initWithColor:")]
        IntPtr Constructor(UIColor color);

        // -(id)initWithColorCode:(unsigned int)color;
        [Export("initWithColorCode:")]
        IntPtr Constructor(uint color);
    }
}
