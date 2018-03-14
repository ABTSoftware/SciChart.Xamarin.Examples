using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIXAxisDragModifier : SCIAxisDragModifierBase
    [BaseType(typeof(SCIAxisDragModifierBase))]
    interface SCIXAxisDragModifier
    {
        // @property (nonatomic) SCIClipMode clipModeX;
        [Export("clipModeX", ArgumentSemantic.Assign)]
        SCIClipMode ClipModeX { get; set; }
    }
}