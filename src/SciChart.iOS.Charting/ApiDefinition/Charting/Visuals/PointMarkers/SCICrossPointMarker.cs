using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCICrossPointMarker : SCIPointMarkerBase
    [BaseType(typeof(SCIPointMarkerBase))]
    interface SCICrossPointMarker
    {
        // @property (nonatomic) BOOL drawRotated;
        [Export("drawRotated")]
        bool DrawRotated { get; set; }
    }
}