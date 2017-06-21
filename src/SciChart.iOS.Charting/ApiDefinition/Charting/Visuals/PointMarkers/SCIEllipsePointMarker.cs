using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIEllipsePointMarker : SCIPointMarkerBase
    [BaseType(typeof(SCIPointMarkerBase))]
    interface SCIEllipsePointMarker
    {
        // @property (nonatomic) int detalization;
        [Export("detalization")]
        int Detalization { get; set; }
    }
}