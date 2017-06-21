using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCICategoryNumericLabelProvider : SCINumericLabelProvider
    [BaseType(typeof(SCINumericLabelProvider))]
    interface SCICategoryNumericLabelProvider
    {
    }
}