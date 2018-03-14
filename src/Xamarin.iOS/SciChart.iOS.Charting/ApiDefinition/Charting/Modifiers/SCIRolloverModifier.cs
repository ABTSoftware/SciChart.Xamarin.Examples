using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIRolloverModifier : SCIGestureModifier <SCIThemeableProtocol>
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIRolloverModifier : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCIRolloverModifierStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIRolloverModifierStyle Style { get; set; }

        // @property (nonatomic) double hitTestRadius;
        [Export("hitTestRadius")]
        double HitTestRadius { get; set; }

        // -(SCIHitTestInfo)hitTestWithProvider:(id<SCIHitTestProviderProtocol>)provider Location:(CGPoint)location Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data hitTestMode:(SCIHitTestMode)hitTestMode;
        [Export("hitTestWithProvider:Location:Radius:onData:hitTestMode:")]
        SCIHitTestInfo HitTestWithProvider(ISCIHitTestProviderProtocol provider, CGPoint location, double radius, ISCIRenderPassDataProtocol data, SCIHitTestMode hitTestMode);
    }
}