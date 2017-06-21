using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITooltipModifier : SCIGestureModifier <SCIThemeableProtocol>
    [BaseType(typeof(SCIGestureModifier))]
    interface SCITooltipModifier : ISCIThemeableProtocol
    {
    	// @property (copy, nonatomic) SCITooltipModifierStyle * style;
    	[Export("style", ArgumentSemantic.Copy)]
    	SCITooltipModifierStyle Style { get; set; }

    	// @property (nonatomic) double hitTestRadius;
    	[Export("hitTestRadius")]
    	double HitTestRadius { get; set; }

    	// -(SCIHitTestInfo)hitTestWithProvider:(id<SCIHitTestProviderProtocol>)provider Location:(CGPoint)location Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data hitTestMode:(SCIHitTestMode)hitTestMode;
    	[Export("hitTestWithProvider:Location:Radius:onData:hitTestMode:")]
    	SCIHitTestInfo HitTestWithProvider(SCIHitTestProviderProtocol provider, CGPoint location, double radius, SCIRenderPassDataProtocol data, SCIHitTestMode hitTestMode);
    }
}