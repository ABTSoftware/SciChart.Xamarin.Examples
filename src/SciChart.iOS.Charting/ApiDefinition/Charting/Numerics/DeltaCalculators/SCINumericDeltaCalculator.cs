using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCINumericDeltaCalculator : SCINumericDeltaCalculatorBase
    [BaseType(typeof(SCINumericDeltaCalculatorBase))]
    interface SCINumericDeltaCalculator
    {
        // +(SCINumericDeltaCalculatorBase *)instance;
        [Static]
        [Export("instance")]
        SCINumericDeltaCalculatorBase Instance { get; }
    }
}