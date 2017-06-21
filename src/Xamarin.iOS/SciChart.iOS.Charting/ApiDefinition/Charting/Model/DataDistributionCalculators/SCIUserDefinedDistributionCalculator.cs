using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIUserDefinedDistributionCalculator : SCIDataDistributionCalculatorBase
    [BaseType(typeof(SCIDataDistributionCalculatorBase))]
    interface SCIUserDefinedDistributionCalculator
    {
    }
}