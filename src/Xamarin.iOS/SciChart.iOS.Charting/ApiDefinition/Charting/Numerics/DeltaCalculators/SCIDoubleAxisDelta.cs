using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIDoubleAxisDelta : NSObject <SCIAxisDeltaProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDoubleAxisDelta : ISCIAxisDeltaProtocol
    {
        // -(id)initWithMin:(double)min Max:(double)max;
        [Export("initWithMin:Max:")]
        IntPtr Constructor(double min, double max);

        // -(SCIDoubleAxisDelta *)clone;
        [Export("clone")]
        SCIDoubleAxisDelta Clone { get; }

        // -(BOOL)equals:(id)object;
        [Export("equals:")]
        bool Equals(NSObject @object);
    }
}