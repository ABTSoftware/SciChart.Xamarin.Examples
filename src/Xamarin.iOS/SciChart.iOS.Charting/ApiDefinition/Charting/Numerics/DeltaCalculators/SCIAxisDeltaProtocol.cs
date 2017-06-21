using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIAxisDeltaProtocol { }

    // @protocol SCIAxisDeltaProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIAxisDeltaProtocol
    {
        // @required @property (nonatomic) int majorDelta;
        [Abstract]
        [Export("majorDelta")]
        int MajorDelta { get; set; }

        // @required @property (nonatomic) int minorDelta;
        [Abstract]
        [Export("minorDelta")]
        int MinorDelta { get; set; }
    }
}