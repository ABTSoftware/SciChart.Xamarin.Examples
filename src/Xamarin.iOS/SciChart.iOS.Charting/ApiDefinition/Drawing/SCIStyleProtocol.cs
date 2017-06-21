using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIStyleProtocol { }

    // @protocol ISCIStyleProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIStyleProtocol
    {
        // @property(nonatomic, copy) SCIActionBlock styleChanged;
        [Abstract]
        [Export("styleChanged")]
        SCIActionBlock styleChanged { get; set; }
    }
}