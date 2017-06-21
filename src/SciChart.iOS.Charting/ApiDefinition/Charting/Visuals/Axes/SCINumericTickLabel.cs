using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCINumericTickLabel : SCIDefaultTickLabel
    [BaseType(typeof(SCIDefaultTickLabel))]
    interface SCINumericTickLabel
    {
    }
}