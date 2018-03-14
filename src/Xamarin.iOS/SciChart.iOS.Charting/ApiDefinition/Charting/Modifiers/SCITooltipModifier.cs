using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCITooltipModifier : SCIGestureModifier <SCIThemeableProtocol>
    [BaseType(typeof(SCIGestureModifier))]
    interface SCITooltipModifier : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCITooltipModifierStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCITooltipModifierStyle Style { get; set; }

        // @property (nonatomic) double hitTestRadius;
        [Export("hitTestRadius")]
        double HitTestRadius { get; set; }

        // -(SCIHitTestInfo)hitTestWithProvider:(id<SCIHitTestProviderProtocol>)provider Location:(CGPoint)location Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data hitTestMode:(SCIHitTestMode)hitTestMode;
        [Export("hitTestWithProvider:Location:Radius:onData:hitTestMode:")]
        SCIHitTestInfo HitTestWithProvider(ISCIHitTestProviderProtocol provider, CGPoint location, double radius, ISCIRenderPassDataProtocol data, SCIHitTestMode hitTestMode);
    }
}