using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIZoomExtentsModifier : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIZoomExtentsModifier
    {
        // @property (nonatomic) BOOL isAnimated;
        [Export("isAnimated")]
        bool IsAnimated { get; set; }

        // @property (nonatomic) SCIXYDirection xyDirection;
        [Export("xyDirection", ArgumentSemantic.Assign)]
        SCIXYDirection XyDirection { get; set; }
    }
}