using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCILineAnnotationStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCILineAnnotationStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> resizeMarker;
        [Export("resizeMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol ResizeMarker { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * linePen;
        [Export("linePen", ArgumentSemantic.Strong)]
        SCIPenStyle LinePen { get; set; }

        // @property (nonatomic) double selectRadius;
        [Export("selectRadius")]
        double SelectRadius { get; set; }

        // @property (nonatomic) double resizeRadius;
        [Export("resizeRadius")]
        double ResizeRadius { get; set; }

        // @property (nonatomic) SCIAnnotationSurfaceEnum annotationSurface;
        [Export("annotationSurface", ArgumentSemantic.Assign)]
        SCIAnnotationSurfaceEnum AnnotationSurface { get; set; }
    }
}