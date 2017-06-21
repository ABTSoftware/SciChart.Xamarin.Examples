using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCINiceDoubleScale : NSObject <SCINiceScaleProtocol>
    [BaseType(typeof(NSObject))]
    interface SCINiceDoubleScale : SCINiceScaleProtocol
    {
        // -(id)initWithMin:(double)min Max:(double)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(int)maxTicks;
        [Export("initWithMin:Max:MinorsPerMajor:MaxTicks:")]
        IntPtr Constructor(double min, double max, int minorsPerMajor, int maxTicks);

        // -(SCIDoubleRange *)niceRange;
        [Export("niceRange")]
        SCIDoubleRange NiceRange();

        // -(double)niceNumWithRange:(double)range Round:(BOOL)round;
        [Export("niceNumWithRange:Round:")]
        double NiceNumWithRange(double range, bool round);
    }
}