using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITimeSpanDelta : NSObject <SCIAxisDeltaProtocol>
    [BaseType(typeof(NSObject))]
    interface SCITimeSpanDelta : SCIAxisDeltaProtocol
    {
        // -(id)initWithMin:(NSTimeInterval)min Max:(NSTimeInterval)max;
        [Export("initWithMin:Max:")]
        IntPtr Constructor(double min, double max);

        // -(SCITimeSpanDelta *)clone;
        [Export("clone")]
        SCITimeSpanDelta Clone { get; }

        // -(BOOL)equals:(id)object;
        [Export("equals:")]
        bool Equals(NSObject @object);
    }
}