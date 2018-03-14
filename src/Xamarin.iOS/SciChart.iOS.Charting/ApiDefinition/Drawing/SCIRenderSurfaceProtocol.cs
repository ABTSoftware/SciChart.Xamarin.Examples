using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    interface ISCIRenderSurfaceProtocol { }

    // @protocol SCIRenderSurfaceProtocol <NSObject, SCIInvalidatableElementProtocol>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIRenderSurfaceProtocol : SCIInvalidatableElementProtocol
    {
        //[Wrap("WeakDelegate"), Abstract]
        // TODO Discuss Delegate and it's Wrap on SCIRenderSurfaceProtocol with Andrii
        //ISCIRenderSurfaceCallbackDelegateProtocol Delegate { get; set; }

        //// @required @property (nonatomic, weak) id<SCIRenderSurfaceCallbackDelegateProtocol> delegate;
        //[Abstract]
        //[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        //NSObject WeakDelegate { get; set; }

        // @required @property (nonatomic) BOOL multisampling;
        [Abstract]
        [Export("multisampling")]
        bool Multisampling { get; set; }

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();

        // @required -(void)free;
        [Abstract]
        [Export("free")]
        void Free();

        // @required -(void)clearRenderSurface;
        [Abstract]
        [Export("clearRenderSurface")]
        void ClearRenderSurface();

        // @required -(void)clearModifiers;
        [Abstract]
        [Export("clearModifiers")]
        void ClearModifiers();

        // @required -(id<SCIRenderContext2DProtocol>)renderContext;
        [Abstract]
        [Export("renderContext")]
        ISCIRenderContext2DProtocol RenderContext { get; }

        // @required -(id<SCIRenderContext2DProtocol>)modifierContext;
        [Abstract]
        [Export("modifierContext")]
        ISCIRenderContext2DProtocol ModifierContext { get; }

        // @required -(id<SCIRenderContext2DProtocol>)backgroundContext;
        [Abstract]
        [Export("backgroundContext")]
        ISCIRenderContext2DProtocol BackgroundContext { get; }

        // @required @property (nonatomic, weak) UIView * chartFrameView;
        [Abstract]
        [Export("chartFrameView", ArgumentSemantic.Weak)]
        UIView ChartFrameView { get; set; }

        // @required -(CGRect)frame;
        [Abstract]
        [Export("frame")]
        CGRect Frame { get; }

        // @required -(CGRect)chartFrame;
        [Abstract]
        [Export("chartFrame")]
        CGRect ChartFrame { get; }

        // @required -(BOOL)isPointWithinBounds:(CGPoint)point;
        [Abstract]
        [Export("isPointWithinBounds:")]
        bool IsPointWithinBounds(CGPoint point);

        // @required -(CGPoint)pointInChartFrame:(CGPoint)point;
        [Abstract]
        [Export("pointInChartFrame:")]
        CGPoint PointInChartFrame(CGPoint point);

        // @required -(void)drawBackground:(id<SCIRenderContext2DProtocol>)context Style:(SCIRenderSurfaceStyle *)style;
        [Abstract]
        [Export("drawBackground:Style:")]
        void DrawBackground(ISCIRenderContext2DProtocol context, SCIRenderSurfaceStyle style);

        // @required @property (nonatomic) BOOL reduceCPUFrames;
        [Abstract]
        [Export("reduceCPUFrames")]
        bool ReduceCPUFrames { get; set; }

        // @required @property (nonatomic) BOOL reduceGPUFrames;
        [Abstract]
        [Export("reduceGPUFrames")]
        bool ReduceGPUFrames { get; set; }

        // @required @property (copy, nonatomic) SCIActionBlock_Pint renderedCallback;
        [Abstract]
        [Export("renderedCallback", ArgumentSemantic.Copy)]
        SCIActionBlock_Pint RenderedCallback { get; set; }

        // @required @property (nonatomic) BOOL isTransparent;
        [Abstract]
        [Export("isTransparent")]
        bool IsTransparent { get; set; }

        // @required -(void)resetWatermark;
        [Abstract]
        [Export("resetWatermark")]
        void ResetWatermark();
    }
}