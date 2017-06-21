using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyySeriesInfo : SCISeriesInfo
    [BaseType(typeof(SCISeriesInfo))]
    interface SCIXyySeriesInfo
    {
        // -(id)y1Value;
        [Export("y1Value")]
        NSObject Y1Value { get; }

        // -(id)y2Value;
        [Export("y2Value")]
        NSObject Y2Value { get; }
    }
}