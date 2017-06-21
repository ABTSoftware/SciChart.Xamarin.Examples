using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIChartSurface : SCIChartSurfaceView <SCIChartSurfaceProtocol, SCIChartControllerProtocol, SCIRenderSurfaceCallbackDelegateProtocol>
    [BaseType(typeof(SCIChartSurfaceView))]
    interface SCIChartSurface : SCIChartSurfaceProtocol, SCIChartControllerProtocol, SCIRenderSurfaceCallbackDelegateProtocol
    {
        // @property (copy, nonatomic) UIColor * _Nullable backgroundColor;
        [NullAllowed, Export("backgroundColor", ArgumentSemantic.Copy)]
        UIColor BackgroundColor { get; set; }
    }
}