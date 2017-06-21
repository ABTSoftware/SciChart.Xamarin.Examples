using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIHitTestProviderBase : NSObject <ISCIHitTestProviderProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIHitTestProviderBase : SCIHitTestProviderProtocol
    {
        // -(int)getClosestPointToCoordX:(double)x Y:(double)y From:(id<ISCIRenderPassDataProtocol>)data;
        [Export("getClosestPointToCoordX:Y:From:")]
        int GetClosestPointToCoordX(double x, double y, ISCIRenderPassDataProtocol data);

        // -(CGPoint)getClosestPointOnSegmentToCoordX:(double)x Y:(double)y From:(id<ISCIRenderPassDataProtocol>)data;
        [Export("getClosestPointOnSegmentToCoordX:Y:From:")]
        CGPoint GetClosestPointOnSegmentToCoordX(double x, double y, ISCIRenderPassDataProtocol data);
    }
}