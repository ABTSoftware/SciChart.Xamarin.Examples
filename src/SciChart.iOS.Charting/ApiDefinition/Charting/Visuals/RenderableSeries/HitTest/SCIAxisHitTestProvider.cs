using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisHitTestProvider : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIAxisHitTestProvider
    {
        // -(id)hitTestAxis:(id<SCIAxis2DProtocol>)axis AtX:(double)x Y:(double)y;
        [Export("hitTestAxis:AtX:Y:")]
        NSObject HitTestAxis(ISCIAxis2DProtocol axis, double x, double y);

        // -(id)hitTestAxis:(id<SCIAxis2DProtocol>)axis AtValue:(id)dataValue;
        [Export("hitTestAxis:AtValue:")]
        NSObject HitTestAxis(ISCIAxis2DProtocol axis, NSObject dataValue);
    }
}