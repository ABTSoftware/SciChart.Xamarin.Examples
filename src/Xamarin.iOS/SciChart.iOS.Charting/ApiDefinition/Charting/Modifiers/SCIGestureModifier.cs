using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIGestureModifier : SCIChartModifierBase <SCIGestureEventsHandlerProtocol>
    [BaseType(typeof(SCIChartModifierBase))]
    interface SCIGestureModifier : SCIGestureEventsHandlerProtocol
    {
    }
}