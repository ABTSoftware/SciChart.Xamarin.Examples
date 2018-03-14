using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIBrushSolid : NSObject <SCIBrush2DProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIBrushSolid : SCIBrush2DProtocol
    {
        // -(id)initWithColor:(UIColor *)color;
        [Export("initWithColor:")]
        IntPtr Constructor(UIColor color);

        // -(id)initWithColorCode:(unsigned int)color;
        [Export("initWithColorCode:")]
        IntPtr Constructor(uint color);
    }
}