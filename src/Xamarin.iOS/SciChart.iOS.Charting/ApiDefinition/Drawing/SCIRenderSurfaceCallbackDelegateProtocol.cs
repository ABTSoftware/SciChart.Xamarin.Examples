using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIRenderSurfaceCallbackDelegateProtocol { }

    // @protocol SCIRenderSurfaceCallbackDelegateProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
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