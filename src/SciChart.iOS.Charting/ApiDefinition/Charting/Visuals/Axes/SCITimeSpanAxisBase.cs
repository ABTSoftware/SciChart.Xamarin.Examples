using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITimeSpanAxisBase : SCIAxisBase
    [BaseType(typeof(SCIAxisBase))]
    interface SCITimeSpanAxisBase
    {
        // -(id<SCIRangeProtocol>)toVisibleRangeMin:(id)min Max:(id)max;
        [Export("toVisibleRangeMin:Max:")]
        ISCIRangeProtocol ToVisibleRangeMin(NSObject min, NSObject max);
    }
}