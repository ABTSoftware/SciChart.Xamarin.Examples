using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisPinchZoomModifier
    [BaseType(typeof(SCIRelativeZoomModifierBase))]
    interface SCIAxisPinchZoomModifier
    {
        // @property (readonly, nonatomic) BOOL gestureLocked;
        [Export("gestureLocked")]
        bool GestureLocked { get; }

        // @property (copy, nonatomic) NSString * axisId;
        [Export("axisId")]
        string AxisId { get; set; }
    }
}