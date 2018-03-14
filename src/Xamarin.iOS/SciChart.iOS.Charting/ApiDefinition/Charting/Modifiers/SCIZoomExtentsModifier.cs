using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIZoomExtentsModifier : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCIZoomExtentsModifier
    {
        // @property (nonatomic) BOOL isAnimated;
        [Export("isAnimated")]
        bool IsAnimated { get; set; }

        // @property (nonatomic) SCIDirection2D direction;
        [Export("direction", ArgumentSemantic.Assign)]
        SCIDirection2D Direction { get; set; }
    }
}