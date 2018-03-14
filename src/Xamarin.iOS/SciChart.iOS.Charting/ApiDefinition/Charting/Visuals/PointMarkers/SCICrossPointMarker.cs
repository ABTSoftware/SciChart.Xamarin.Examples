using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCICrossPointMarker : SCIPointMarkerBase
    [BaseType(typeof(SCIPointMarkerBase))]
    interface SCICrossPointMarker
    {
        // @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic) BOOL drawRotated;
        [Export("drawRotated")]
        bool DrawRotated { get; set; }
    }
}