using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIXySeriesInfo : SCISeriesInfo
    [BaseType(typeof(SCISeriesInfo))]
    interface SCIXySeriesInfo
    {
    }
}