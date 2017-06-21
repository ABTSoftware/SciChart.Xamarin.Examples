using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastMountainRenderableSeries : SCIBaseMountainRenderableSeries
    [BaseType(typeof(SCIBaseMountainRenderableSeries))]
    interface SCIFastMountainRenderableSeries
    {
    }
}