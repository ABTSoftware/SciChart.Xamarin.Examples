using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIScatterSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIScatterSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker;
        [Export("pointMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol PointMarker { get; set; }

        // @property (nonatomic, strong) SCIPointMarkerClusterizer * cluster;
        [Export("cluster", ArgumentSemantic.Strong)]
        SCIPointMarkerClusterizer Cluster { get; set; }

        // @property (nonatomic) float clusterSpacing;
        [Export("clusterSpacing")]
        float ClusterSpacing { get; set; }
    }
}