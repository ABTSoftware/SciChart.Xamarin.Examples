using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIMountainSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIMountainSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCIBrushStyle * areaStyle;
        [Export("areaStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle AreaStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker;
        [Export("pointMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol PointMarker { get; set; }

        // @property (nonatomic) BOOL isDigitalLine;
        [Export("isDigitalLine")]
        bool IsDigitalLine { get; set; }
    }
}