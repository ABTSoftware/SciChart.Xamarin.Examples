using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIHitTestProviderProtocol { }

    // @protocol SCIHitTestProviderProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIHitTestProviderProtocol
    {
    	// @required @property (nonatomic) SCIHitTestMode hitTestMode;
    	[Abstract]
    	[Export("hitTestMode", ArgumentSemantic.Assign)]
    	SCIHitTestMode HitTestMode { get; set; }

    	// @required -(SCIHitTestInfo)hitTestAtX:(double)x Y:(double)y Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data;
    	[Abstract]
    	[Export("hitTestAtX:Y:Radius:onData:")]
    	SCIHitTestInfo HitTestAtX(double x, double y, double radius, SCIRenderPassDataProtocol data);

    	// @required -(SCIHitTestInfo)hitTestVerticalAtX:(double)x Y:(double)y Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data;
    	[Abstract]
    	[Export("hitTestVerticalAtX:Y:Radius:onData:")]
    	SCIHitTestInfo HitTestVerticalAtX(double x, double y, double radius, SCIRenderPassDataProtocol data);

    	// @required -(SCIHitTestInfo)hitTestAtX:(double)x Y:(double)y Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data Mode:(SCIHitTestMode)mode;
    	[Abstract]
    	[Export("hitTestAtX:Y:Radius:onData:Mode:")]
    	SCIHitTestInfo HitTestAtX(double x, double y, double radius, SCIRenderPassDataProtocol data, SCIHitTestMode mode);

    	// @required -(SCIHitTestInfo)hitTestPointModeAtX:(double)x Y:(double)y Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data;
    	[Abstract]
    	[Export("hitTestPointModeAtX:Y:Radius:onData:")]
    	SCIHitTestInfo HitTestPointModeAtX(double x, double y, double radius, SCIRenderPassDataProtocol data);

    	// @required -(SCIHitTestInfo)hitTestInterpolateModeAtX:(double)x Y:(double)y Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data;
    	[Abstract]
    	[Export("hitTestInterpolateModeAtX:Y:Radius:onData:")]
    	SCIHitTestInfo HitTestInterpolateModeAtX(double x, double y, double radius, SCIRenderPassDataProtocol data);

    	// @required -(SCIHitTestInfo)hitTestVerticalModeAtX:(double)x Y:(double)y Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data;
    	[Abstract]
    	[Export("hitTestVerticalModeAtX:Y:Radius:onData:")]
    	SCIHitTestInfo HitTestVerticalModeAtX(double x, double y, double radius, SCIRenderPassDataProtocol data);

    	// @required -(SCIHitTestInfo)hitTestVerticalInterpolateModeAtX:(double)x Y:(double)y Radius:(double)radius onData:(id<SCIRenderPassDataProtocol>)data;
    	[Abstract]
    	[Export("hitTestVerticalInterpolateModeAtX:Y:Radius:onData:")]
    	SCIHitTestInfo HitTestVerticalInterpolateModeAtX(double x, double y, double radius, SCIRenderPassDataProtocol data);
    }
}