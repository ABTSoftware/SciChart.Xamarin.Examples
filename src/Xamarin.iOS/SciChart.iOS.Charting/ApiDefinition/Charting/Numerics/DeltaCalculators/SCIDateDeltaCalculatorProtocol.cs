using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIDateDeltaCalculatorProtocol : ISCIDeltaCalculatorProtocol { }

    // @protocol SCIDateDeltaCalculatorProtocol <SCIDeltaCalculatorProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIDateDeltaCalculatorProtocol
    {
    }
}