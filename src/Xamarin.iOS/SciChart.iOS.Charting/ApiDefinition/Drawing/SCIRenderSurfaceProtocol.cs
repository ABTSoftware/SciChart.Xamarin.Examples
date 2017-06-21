using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIRenderSurfaceProtocol { }

    // @protocol SCIRenderSurfaceProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIRenderSurfaceProtocol
    {
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

        // @required -(id<ISCIRenderContext2DProtocol>)renderContext;
        [Abstract]
        [Export("renderContext")]
        ISCIRenderContext2DProtocol RenderContext { get; }

        // @required -(id<ISCIRenderContext2DProtocol>)modifierContext;
        [Abstract]
        [Export("modifierContext")]
        ISCIRenderContext2DProtocol ModifierContext { get; }

        // @required -(id<ISCIRenderContext2DProtocol>)backgroundContext;
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

        // @required -(void)drawBackground:(id<ISCIRenderContext2DProtocol>)context Style:(SCIRenderSurfaceStyle *)style;
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

        // @required @property (copy, nonatomic) int renderedCallback;
        [Abstract]
        [Export("renderedCallback")]
        int RenderedCallback { get; set; }

        // @required -(void)resetWatermark;
        [Abstract]
        [Export("resetWatermark")]
        void ResetWatermark();
    }
}