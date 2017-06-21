using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITimeSpanDeltaCalculatorBase : NSObject <SCIDateDeltaCalculatorProtocol>
    [BaseType(typeof(NSObject))]
    interface SCITimeSpanDeltaCalculatorBase : SCIDateDeltaCalculatorProtocol
    {
        // -(double)getTicks:(id)value;
        [Export("getTicks:")]
        double GetTicks(NSObject value);
    }
}