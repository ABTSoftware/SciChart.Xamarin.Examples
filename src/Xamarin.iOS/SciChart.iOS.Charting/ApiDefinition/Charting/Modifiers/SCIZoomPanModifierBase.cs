using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIZoomPanModifierBase : SCIPanModifier
    [BaseType(typeof(SCIPanModifier))]
    interface SCIZoomPanModifierBase
    {
        // @property (nonatomic) SCIDirection2D direction;
        [Export("direction", ArgumentSemantic.Assign)]
        SCIDirection2D Direction { get; set; }

        // @property (nonatomic) SCIClipMode clipModeX;
        [Export("clipModeX", ArgumentSemantic.Assign)]
        SCIClipMode ClipModeX { get; set; }

        // @property (nonatomic) BOOL zoomExtentsY;
        [Export("zoomExtentsY")]
        bool ZoomExtentsY { get; set; }

        // @property (readonly, nonatomic) BOOL gestureLocked;
        [Export("gestureLocked")]
        bool GestureLocked { get; }
    }
}