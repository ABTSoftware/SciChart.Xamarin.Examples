using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIZoomPanModifierBase : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIZoomPanModifierBase
    {
        // @property (nonatomic) SCIXYDirection xyDirection;
        [Export("xyDirection", ArgumentSemantic.Assign)]
        SCIXYDirection XyDirection { get; set; }

        // @property (nonatomic) SCIClipMode clipModeX;
        [Export("clipModeX", ArgumentSemantic.Assign)]
        SCIClipMode ClipModeX { get; set; }

        // @property (nonatomic) BOOL zoomExtentsY;
        [Export("zoomExtentsY")]
        bool ZoomExtentsY { get; set; }

        // -(void)panFrom:(CGPoint)lastPoint To:(CGPoint)currentPoint Start:(CGPoint)startPoint;
        [Export("panFrom:To:Start:")]
        void PanFrom(CGPoint lastPoint, CGPoint currentPoint, CGPoint startPoint);

        // @property (readonly, nonatomic) BOOL gestureLocked;
        [Export("gestureLocked")]
        bool GestureLocked { get; }
    }
}