using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastColumnRenderableSeries : SCIBaseColumnRenderableSeries
    [BaseType(typeof(SCIBaseColumnRenderableSeries))]
    interface SCIFastColumnRenderableSeries
    {
    }
}