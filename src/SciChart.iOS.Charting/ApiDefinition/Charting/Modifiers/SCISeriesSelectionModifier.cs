using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCISeriesSelectionModifier : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCISeriesSelectionModifier
    {
        // @required @property (nonatomic) int hitTestMode;
        [Export("hitTestMode")]
        int HitTestMode { get; set; }

        // @property (nonatomic) double hitTestRadius;
        [Export("hitTestRadius")]
        double HitTestRadius { get; set; }
    }
}