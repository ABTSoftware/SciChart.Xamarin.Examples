using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCITrianglePointMarker : SCIPointMarkerBase
    [BaseType(typeof(SCIPointMarkerBase))]
    interface SCITrianglePointMarker
    {
        // @property (nonatomic, strong) SCIBrushStyle * fillStyle;
        [Export("fillStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }
    }
}