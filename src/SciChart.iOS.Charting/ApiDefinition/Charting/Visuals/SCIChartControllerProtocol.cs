using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIChartControllerProtocol { }

    // @protocol SCIChartControllerProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIChartControllerProtocol
    {
        // @required -(void)zoomExtents;
        [Abstract]
        [Export("zoomExtents")]
        void ZoomExtents();

        // @required -(void)animateZoomExtents:(float)duration;
        [Abstract]
        [Export("animateZoomExtents:")]
        void AnimateZoomExtents(float duration);

        // @required -(void)zoomExtentsY;
        [Abstract]
        [Export("zoomExtentsY")]
        void ZoomExtentsY();

        // @required -(void)animateZoomExtentsY:(float)duration;
        [Abstract]
        [Export("animateZoomExtentsY:")]
        void AnimateZoomExtentsY(float duration);

        // @required -(void)zoomExtentsX;
        [Abstract]
        [Export("zoomExtentsX")]
        void ZoomExtentsX();

        // @required -(void)animateZoomExtentsX:(float)duration;
        [Abstract]
        [Export("animateZoomExtentsX:")]
        void AnimateZoomExtentsX(float duration);
    }
}