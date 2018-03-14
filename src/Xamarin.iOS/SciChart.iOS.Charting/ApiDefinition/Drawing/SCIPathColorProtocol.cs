using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    interface ISCIPathColorProtocol { }

    // @protocol SCIPathColorProtocol <NSObject, NSCopying>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIPathColorProtocol : INSCopying
    {
        // @required -(UIColor *)color;
        [Abstract]
        [Export("color")]
        UIColor Color { get; }

        // @required -(unsigned int)colorCode;
        [Abstract]
        [Export("colorCode")]
        uint ColorCode { get; }

        // @required -(unsigned int)colorCodeAtX:(double)x Y:(double)y;
        [Abstract]
        [Export("colorCodeAtX:Y:")]
        uint Y(double x, double y);
    }
}