using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIScatterSeriesStyle : NSObject <ISCIStyleProtocol, NSCopying>
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