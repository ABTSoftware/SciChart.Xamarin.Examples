using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCICursorModifier : SCIGestureModifier <SCIThemeableProtocol>
    [BaseType(typeof(SCIGestureModifier))]
    interface SCICursorModifier : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCICursorModifierStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCICursorModifierStyle Style { get; set; }

        // @property (nonatomic) double hitTestRadius;
        [Export("hitTestRadius")]
        double HitTestRadius { get; set; }

        // -(SCIHitTestInfo)hitTestWithProvider:(id<SCIHitTestProviderProtocol>)provider Location:(CGPoint)location Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data hitTestMode:(SCIHitTestMode)hitTestMode;
        [Export("hitTestWithProvider:Location:Radius:onData:hitTestMode:")]
        SCIHitTestInfo HitTestWithProvider(ISCIHitTestProviderProtocol provider, CGPoint location, double radius, ISCIRenderPassDataProtocol data, SCIHitTestMode hitTestMode);
    }
}