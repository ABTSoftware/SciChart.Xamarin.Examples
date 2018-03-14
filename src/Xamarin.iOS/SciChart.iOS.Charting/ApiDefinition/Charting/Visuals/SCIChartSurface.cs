using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIChartSurface : SCIChartSurfaceView <SCIChartSurfaceProtocol, SCIChartControllerProtocol, SCIRenderSurfaceCallbackDelegateProtocol>
    [BaseType(typeof(SCIChartSurfaceView))]
    interface SCIChartSurface : SCIChartSurfaceProtocol, SCIChartControllerProtocol, SCIRenderSurfaceCallbackDelegateProtocol
    {
        // @property (copy, nonatomic) UIColor * _Nullable backgroundColor;
        [NullAllowed, Export("backgroundColor", ArgumentSemantic.Copy)]
        UIColor BackgroundColor { get; set; }

        // +(void)setDisplayLinkRunLoopMode:(NSRunLoopMode _Nonnull)runLoopMode;
        [Static]
        [Export("setDisplayLinkRunLoopMode:")]
        void SetDisplayLinkRunLoopMode(string runLoopMode);

        // +(NSRunLoopMode _Nonnull)getDisplayLinkRunLoopMode;
        [Static]
        [Export("getDisplayLinkRunLoopMode")]
        string DisplayLinkRunLoopMode { get; }
    }
}