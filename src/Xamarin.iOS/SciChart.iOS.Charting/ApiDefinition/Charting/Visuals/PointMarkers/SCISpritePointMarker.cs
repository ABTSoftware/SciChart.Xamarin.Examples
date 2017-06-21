using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCISpritePointMarker : SCIPointMarkerBase
    [BaseType(typeof(SCIPointMarkerBase))]
    interface SCISpritePointMarker
    {
        // @property (nonatomic, strong) id<SCITexturedBrushProtocol> brush;
        [Export("brush", ArgumentSemantic.Strong)]
        ISCITexturedBrushProtocol Brush { get; set; }
    }
}