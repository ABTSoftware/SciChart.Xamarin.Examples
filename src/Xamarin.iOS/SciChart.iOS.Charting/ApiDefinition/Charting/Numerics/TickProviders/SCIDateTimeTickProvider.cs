using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIDateTimeTickProvider : SCITimeSpanTickProviderBase
    [BaseType(typeof(SCITimeSpanTickProviderBase))]
    interface SCIDateTimeTickProvider
    {
    }
}