using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyzSeriesInfo : SCISeriesInfo
    [BaseType(typeof(SCISeriesInfo))]
    interface SCIXyzSeriesInfo
    {
        // -(SCIGenericType)zValue;
        //[Export("zValue")]
        //SCIGenericType ZValue { get; }
    }
}