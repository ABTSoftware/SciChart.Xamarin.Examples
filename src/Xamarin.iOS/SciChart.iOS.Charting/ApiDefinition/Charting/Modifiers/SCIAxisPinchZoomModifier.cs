using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisPinchZoomModifier : SCIRelativeZoomModifierBase
    [BaseType(typeof(SCIRelativeZoomModifierBase))]
    interface SCIAxisPinchZoomModifier
    {
        // @property (readonly, nonatomic) BOOL gestureLocked;
        [Export("gestureLocked")]
        bool GestureLocked { get; }

        // @property (copy, nonatomic) NSString * axisId;
        [Export("axisId")]
        string AxisId { get; set; }
    }
}