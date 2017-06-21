using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIRenderSurfaceCallbackDelegateProtocol { }

    // @protocol SCIRenderSurfaceCallbackDelegateProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIRenderSurfaceCallbackDelegateProtocol
    {
        // @required -(void)onRenderSurfaceDraw;
        [Abstract]
        [Export("onRenderSurfaceDraw")]
        void OnRenderSurfaceDraw();

        // @required -(void)onRenderSurfaceDrawModifiers;
        [Abstract]
        [Export("onRenderSurfaceDrawModifiers")]
        void OnRenderSurfaceDrawModifiers();
    }
}