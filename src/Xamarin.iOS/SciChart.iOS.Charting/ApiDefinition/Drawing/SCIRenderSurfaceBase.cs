using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIRenderSurfaceBase : UIView <SCIRenderSurfaceProtocol>
    [BaseType(typeof(UIView))]
    interface SCIRenderSurfaceBase : ISCIRenderSurfaceProtocol
    {
        // -(void)onRenderTimeElapsed;
        [Export("onRenderTimeElapsed")]
        void OnRenderTimeElapsed();

        // -(BOOL)needRedraw;
        [Export("needRedraw")]
        bool NeedRedraw { get; }
    }
}