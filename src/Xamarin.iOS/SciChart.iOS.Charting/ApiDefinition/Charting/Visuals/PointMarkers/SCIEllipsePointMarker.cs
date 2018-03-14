using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIEllipsePointMarker : SCIPointMarkerBase
    [BaseType(typeof(SCIPointMarkerBase))]
    interface SCIEllipsePointMarker
    {
        // @property (nonatomic, strong) SCIBrushStyle * fillStyle;
        [Export("fillStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic) int detalization;
        [Export("detalization")]
        int Detalization { get; set; }
    }
}