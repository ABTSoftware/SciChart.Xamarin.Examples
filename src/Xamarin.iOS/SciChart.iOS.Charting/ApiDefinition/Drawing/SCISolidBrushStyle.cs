using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCISolidBrushStyle : SCIBrushStyle
    [BaseType(typeof(SCIBrushStyle))]
    interface SCISolidBrushStyle
    {
        // -(instancetype _Nonnull)initWithColorCode:(unsigned int)colorCode;
        [Export("initWithColorCode:")]
        IntPtr Constructor(uint colorCode);

        // -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color;
        [Export("initWithColor:")]
        IntPtr Constructor(UIColor color);
    }
}