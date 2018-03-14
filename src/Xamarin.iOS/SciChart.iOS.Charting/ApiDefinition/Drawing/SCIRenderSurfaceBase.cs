using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIRenderSurfaceBase : UIView <SCIRenderSurfaceProtocol>
    [BaseType(typeof(UIView))]
    interface SCIRenderSurfaceBase : SCIRenderSurfaceProtocol
    {
        // -(void)onRenderTimeElapsed;
        [Export("onRenderTimeElapsed")]
        void OnRenderTimeElapsed();

        // -(void)addRenderContext:(id<SCIRenderContext2DProtocol>)context;
        [Export("addRenderContext:")]
        void AddRenderContext(SCIRenderContext2DProtocol context);

        // -(void)addModifierContext:(id<SCIRenderContext2DProtocol>)context;
        [Export("addModifierContext:")]
        void AddModifierContext(SCIRenderContext2DProtocol context);

        // -(void)addBackgroundContext:(id<SCIRenderContext2DProtocol>)context;
        [Export("addBackgroundContext:")]
        void AddBackgroundContext(SCIRenderContext2DProtocol context);

        // -(BOOL)needRedraw;
        [Export("needRedraw")]
        bool NeedRedraw { get; }
    }
}