using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCINumericAxis : SCIAxisBase
    [BaseType(typeof(SCIAxisBase))]
    interface SCINumericAxis
    {
        // @property (nonatomic) NSNumberFormatter * numberFormatter;
        [Export("numberFormatter", ArgumentSemantic.Assign)]
        NSNumberFormatter NumberFormatter { get; set; }
    }
}