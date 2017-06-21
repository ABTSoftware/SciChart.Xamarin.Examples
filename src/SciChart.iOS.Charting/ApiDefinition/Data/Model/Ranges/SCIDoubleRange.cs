using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIDoubleRange : NSObject <SCIRangeProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDoubleRange : SCIRangeProtocol
    {
    }
}