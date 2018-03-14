using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIMultiSurfaceModifier : NSObject <SCIChartModifierProtocol, SCIGestureEventsHandlerProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIMultiSurfaceModifier : SCIChartModifierProtocol, SCIGestureEventsHandlerProtocol
    {
        // -(instancetype _Nonnull)initWithModifierType:(Class<SCIChartModifierProtocol,SCIGestureEventsHandlerProtocol> _Nonnull)modifier;
        [Export("initWithModifierType:")]
        IntPtr Constructor(Class modifier);

        // -(id<SCIChartModifierProtocol,SCIGestureEventsHandlerProtocol> _Nullable)modifierForSurface:(id<SCIChartSurfaceProtocol> _Nullable)surface;
        [Export("modifierForSurface:")]
        ISCIChartModifierProtocol ModifierForSurface(ISCIChartSurfaceProtocol surface);

        // -(void)disconnectSurface:(id<SCIChartSurfaceProtocol> _Nonnull)surface;
        [Export("disconnectSurface:")]
        void DisconnectSurface(ISCIChartSurfaceProtocol surface);

        // -(void)disconnectSurfaces;
        [Export("disconnectSurfaces")]
        void DisconnectSurfaces();
    }
}