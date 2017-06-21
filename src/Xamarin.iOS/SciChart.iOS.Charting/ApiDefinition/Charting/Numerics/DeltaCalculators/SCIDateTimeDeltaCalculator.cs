using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIDateTimeDeltaCalculator : SCITimeSpanDeltaCalculatorBase
    [BaseType(typeof(SCITimeSpanDeltaCalculatorBase))]
    interface SCIDateTimeDeltaCalculator
    {
        // +(SCIDateTimeDeltaCalculator *)instance;
        [Static]
        [Export("instance")]
        SCIDateTimeDeltaCalculator Instance { get; }
    }
}