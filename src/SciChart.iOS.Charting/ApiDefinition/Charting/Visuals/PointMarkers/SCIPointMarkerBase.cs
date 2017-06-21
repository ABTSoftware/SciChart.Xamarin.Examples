using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIPointMarkerProtocol { }

    // @interface SCIPointMarkerBase : NSObject <SCIPointMarkerProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIPointMarkerBase : SCIPointMarkerProtocol
    {
    }
}
