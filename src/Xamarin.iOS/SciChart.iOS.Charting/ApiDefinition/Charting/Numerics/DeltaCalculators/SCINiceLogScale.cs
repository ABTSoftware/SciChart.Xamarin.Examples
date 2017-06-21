using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCINiceLogScale : SCINiceDoubleScale
    [BaseType(typeof(SCINiceDoubleScale))]
    interface SCINiceLogScale
    {
        // -(id)initWithMin:(double)min Max:(double)max LogBase:(double)logBase MinorsPerMajor:(int)minorsPerMajor MaxTicks:(int)maxTicks;
        [Export("initWithMin:Max:LogBase:MinorsPerMajor:MaxTicks:")]
        IntPtr Constructor(double min, double max, double logBase, int minorsPerMajor, int maxTicks);
    }
}