using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCILogarithmicAxisProtocol : ISCIAxis2DProtocol { }

    interface ISCILogarithmicAxis : ISCILogarithmicAxisProtocol { }
    
    // @protocol SCILogarithmicAxisProtocol <SCIAxis2DProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCILogarithmicAxisProtocol : SCIAxis2DProtocol
    {
        // @required @property (nonatomic) double logarithmicBase;
        [Abstract]
        [Export("logarithmicBase")]
        double LogarithmicBase { get; set; }
    }
}