using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIMountainHitTestProvider : SCIHitTestProviderBase
    [BaseType(typeof(SCIHitTestProviderBase))]
    interface SCIMountainHitTestProvider
    {
    }
}