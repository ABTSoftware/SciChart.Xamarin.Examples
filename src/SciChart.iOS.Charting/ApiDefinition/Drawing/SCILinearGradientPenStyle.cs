using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    [BaseType(typeof(SCIPenStyle))]
    interface SCILinearGradientPenStyle : SCIPenStyle
    {
        // -(id)initWithColorStart:(UIColor *)colorStart Finish:(UIColor *)colorFinish Direction:(id)direction
        [Export("initWithColorStart:finish:direction:thickness:")]
        IntPtr Constructor(UIColor colorStart, UIColor colorFinish, SCILinearGradientDirection direction, float thickness);

        // -(id)initWithColorCodeStart:(unsigned int)colorStart Finish:(unsigned int)colorFinish Direction:(id)direction
        [Export("initWithColorCodeStart:finish:direction:thickness:")]
        IntPtr Constructor(uint colorStart, uint colorFinish, SCILinearGradientDirection direction, float thickness);
    }
}
