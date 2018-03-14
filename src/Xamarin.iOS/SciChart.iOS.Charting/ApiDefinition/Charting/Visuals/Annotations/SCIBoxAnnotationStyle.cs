using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIBoxAnnotationStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIBoxAnnotationStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> resizeMarker;
        [Export("resizeMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol ResizeMarker { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * borderPen;
        [Export("borderPen", ArgumentSemantic.Strong)]
        SCIPenStyle BorderPen { get; set; }

        // @property (nonatomic, strong) SCIBrushStyle * fillBrush;
        [Export("fillBrush", ArgumentSemantic.Strong)]
        SCIBrushStyle FillBrush { get; set; }

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