using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIViewportManagerProtocol : INSObjectProtocol { }

    // @protocol SCIViewportManagerProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIViewportManagerProtocol
    {
        //- (BOOL)isAttached;
        [Abstract]
        [Export("isAttached")]
        bool IsAttached { get; }

        //- (id <SCIRangeProtocol>)calculateNewYAxisRange:(id <SCIAxis2DProtocol>)yAxis WithInfo:(SCIRenderPassInfo *)renderPassInfo;
        [Abstract]
        [Export("calculateNewYAxisRange:WithInfo:")]
        ISCIRangeProtocol CalculateNewYAxisRange(ISCIAxis2DProtocol xAxis, SCIRenderPassInfo renderPassInfo);        

        //- (id <SCIRangeProtocol>)calculateNewXAxisRange:(id <SCIAxis2DProtocol>)xAxis;
        [Abstract]
        [Export("calculateNewXAxisRange:")]
        ISCIRangeProtocol CalculateNewXAxisRange(ISCIAxis2DProtocol xAxis);
        
        //- (id <SCIRangeProtocol>)calculateAutoRange:(id <SCIAxis2DProtocol>)axis;
        [Abstract]
        [Export("calculateAutoRange:")]
        ISCIRangeProtocol CalculateAutoRange(ISCIAxis2DProtocol axis);

        //- (void)attachSciChartSurface:(id <SCIChartSurfaceProtocol>)scs;
        [Abstract]
        [Export("attachSciChartSurface:")]
        void AttachSciChartSurface(ISCIChartSurfaceProtocol scs);        

        //- (void)detachSciChartSurface;
        [Abstract]
        [Export("detachSciChartSurface")]
        void DetachSciChartSurface();

        //- (void)zoomExtents;
        [Abstract]
        [Export("zoomExtents")]
        void ZoomExtents();

        //- (void)animateZoomExtents:(float)duration;
        [Abstract]
        [Export("animateZoomExtents:")]
        void AnimateZoomExtents(float duration);

        //- (void)zoomExtentsY;
        [Abstract]
        [Export("zoomExtentsY")]
        void ZoomExtentsY();

        //- (void)animateZoomExtentsY:(float)duration;
        [Abstract]
        [Export("animateZoomExtentsY:")]
        void AnimateZoomExtentsY(float duration);

        //- (void)zoomExtentsX;
        [Abstract]
        [Export("zoomExtentsX")]
        void ZoomExtentsX();

        //- (void)animateZoomExtentsX:(float)duration;
        [Abstract]
        [Export("animateZoomExtentsX:")]
        void AnimateZoomExtentsX(float duration);

        //- (void)autorangeAxes;
        [Abstract]
        [Export("autorangeAxes")]
        void AutorangeAxes();
    }
}