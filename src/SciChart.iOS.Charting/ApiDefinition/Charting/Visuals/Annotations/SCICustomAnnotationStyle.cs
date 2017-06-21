using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIBoxAnnotationStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCICustomAnnotationStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> resizeMarker;
        [Export("resizeMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol ResizeMarker { get; set; }

        // @property (nonatomic) double selectRadius;
        [Export("selectRadius")]
        double SelectRadius { get; set; }

        // @property (nonatomic) double resizeRadius;
        [Export("resizeRadius")]
        double ResizeRadius { get; set; }
    }
}
