using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIViewportManagerProtocol { }

    // @protocol SCIViewportManagerProtocol <NSObject, SCIInvalidatableElementProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIViewportManagerProtocol : SCIInvalidatableElementProtocol
    {
        // @required -(BOOL)isAttached;
        [Abstract]
        [Export("isAttached")]
        bool IsAttached { get; }

        // @required -(id<SCIRangeProtocol>)calculateNewYAxisRange:(id<SCIAxis2DProtocol>)yAxis WithInfo:(SCIRenderPassInfo *)renderPassInfo;
        [Abstract]
        [Export("calculateNewYAxisRange:WithInfo:")]
        ISCIRangeProtocol CalculateNewYAxisRange(ISCIAxis2DProtocol yAxis, SCIRenderPassInfo renderPassInfo);

        // @required -(id<SCIRangeProtocol>)calculateNewXAxisRange:(id<SCIAxis2DProtocol>)xAxis;
        [Abstract]
        [Export("calculateNewXAxisRange:")]
        ISCIRangeProtocol CalculateNewXAxisRange(ISCIAxis2DProtocol xAxis);

        // @required -(id<SCIRangeProtocol>)calculateAutoRange:(id<SCIAxis2DProtocol>)axis;
        [Abstract]
        [Export("calculateAutoRange:")]
        ISCIRangeProtocol CalculateAutoRange(ISCIAxis2DProtocol axis);

        // @required -(void)attachSciChartSurface:(id<SCIChartSurfaceProtocol>)scs;
        [Abstract]
        [Export("attachSciChartSurface:")]
        void AttachSciChartSurface(ISCIChartSurfaceProtocol scs);        

        // @required -(void)detachSciChartSurface;
        [Abstract]
        [Export("detachSciChartSurface")]
        void DetachSciChartSurface();

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

        // @required -(void)autorangeAxes;
        [Abstract]
        [Export("autorangeAxes")]
        void AutorangeAxes();
    }
}