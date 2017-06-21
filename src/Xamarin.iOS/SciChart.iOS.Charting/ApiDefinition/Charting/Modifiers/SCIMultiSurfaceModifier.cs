using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using SciChart;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIMultiSurfaceModifier : NSObject <SCIChartModifierProtocol, SCIGestureEventsHandlerProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIMultiSurfaceModifier : SCIChartModifierProtocol, SCIGestureEventsHandlerProtocol
    {
        // @property (nonatomic) BOOL autoPassAreaCheck;
        [Export("autoPassAreaCheck")]
        bool AutoPassAreaCheck { get; set; }

        // -(instancetype)initWithModifierType:(Class<SCIChartModifierProtocol,SCIGestureEventsHandlerProtocol>)modifier;
        [Export("initWithModifierType:")]
        IntPtr Constructor(Class modifier);

        // -(id<SCIChartModifierProtocol,SCIGestureEventsHandlerProtocol>)modifierForSurface:(id<SCIChartSurfaceProtocol>)surface;
        [Export("modifierForSurface:")]
        ISCIChartModifierProtocol ModifierForSurface(ISCIChartSurfaceProtocol surface);

        // -(void)disconnectSurface:(id<SCIChartSurfaceProtocol>)surface;
        [Export("disconnectSurface:")]
        void DisconnectSurface(ISCIChartSurfaceProtocol surface);

        // -(void)disconnectSurfaces;
        [Export("disconnectSurfaces")]
        void DisconnectSurfaces();
    }
}