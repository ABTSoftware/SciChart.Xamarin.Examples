using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIPathColorProtocol : INSCopying, INSObjectProtocol { }

    // @protocol SCIPathColorProtocol <NSObject, NSCopying>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
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