using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILogarithmicDeltaCalculator : SCINumericDeltaCalculatorBase
    [BaseType(typeof(SCINumericDeltaCalculatorBase))]
    interface SCILogarithmicDeltaCalculator
    {
        // +(SCINumericDeltaCalculatorBase *)instance;
        [Static]
        [Export("instance")]
        SCINumericDeltaCalculatorBase Instance { get; }

        // @property (nonatomic) double logarithmicBase;
        [Export("logarithmicBase")]
        double LogarithmicBase { get; set; }
    }
}