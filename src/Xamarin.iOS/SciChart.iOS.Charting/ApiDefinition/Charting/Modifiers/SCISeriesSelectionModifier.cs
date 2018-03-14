using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCISeriesSelectionModifier : SCIGestureModifier
    [BaseType(typeof(SCIGestureModifier))]
    interface SCISeriesSelectionModifier
    {
        // @property (nonatomic) SCISelectionModifierSelectionMode selectionMode;
        [Export("selectionMode", ArgumentSemantic.Assign)]
        SCISelectionModifierSelectionMode SelectionMode { get; set; }

        // @property (nonatomic) SCIHitTestMode hitTestMode;
        [Export("hitTestMode", ArgumentSemantic.Assign)]
        SCIHitTestMode HitTestMode { get; set; }

        // @property (nonatomic) double hitTestRadius;
        [Export("hitTestRadius")]
        double HitTestRadius { get; set; }
    }
}