using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIDataDistributionCalculatorProtocol { }

    // @interface SCIDataDistributionCalculatorBase : NSObject <ISCIDataDistributionCalculatorProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDataDistributionCalculatorBase : SCIDataDistributionCalculatorProtocol
    {
    }
}
