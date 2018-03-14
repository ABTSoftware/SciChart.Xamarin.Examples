using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisAreaSizeSynchronization : NSObject
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