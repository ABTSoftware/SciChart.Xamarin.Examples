using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIPenSolid : NSObject <SCIPen2DProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIPenSolid : SCIPen2DProtocol
    {
        // -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color Width:(float)width;
        [Export("initWithColor:Width:")]
        IntPtr Constructor(UIColor color, float width);

        // -(instancetype _Nonnull)initWithColorCode:(unsigned int)color Width:(float)width;
        [Export("initWithColorCode:Width:")]
        IntPtr Constructor(uint color, float width);
    }
}