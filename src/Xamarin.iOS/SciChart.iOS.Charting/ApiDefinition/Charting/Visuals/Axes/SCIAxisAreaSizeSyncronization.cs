using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisAreaSizeSyncronization : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIAxisAreaSizeSynchronization
    {
        // -(void)attachSurface:(id<SCIChartSurfaceProtocol>)surface;
        [Export("attachSurface:")]
        void AttachSurface(ISCIChartSurfaceProtocol surface);

        // -(void)detachSurface:(id<SCIChartSurfaceProtocol>)surface;
        [Export("detachSurface:")]
        void DetachSurface(ISCIChartSurfaceProtocol surface);

        // @property (nonatomic) SCIAxisSizeSyncMode syncMode;
        [Export("syncMode", ArgumentSemantic.Assign)]
        SCIAxisSizeSyncMode SyncMode { get; set; }
    }
}