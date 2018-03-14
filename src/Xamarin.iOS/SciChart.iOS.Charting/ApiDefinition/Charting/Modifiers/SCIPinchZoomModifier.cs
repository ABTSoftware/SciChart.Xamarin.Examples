using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIPinchZoomModifier : SCIRelativeZoomModifierBase
    [BaseType(typeof(SCIRelativeZoomModifierBase))]
    interface SCIPinchZoomModifier
    {
        // @property (readonly, nonatomic) BOOL gestureLocked;
        [Export("gestureLocked")]
        bool GestureLocked { get; }
    }
}