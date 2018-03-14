using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIAnchorPointAnnotation : SCIAnnotationBase
    [BaseType(typeof(SCIAnnotationBase))]
    interface SCIAnchorPointAnnotation
    {
        // @property (nonatomic) SCIHorizontalAnchorPoint horizontalAnchorPoint;
        [Export("horizontalAnchorPoint", ArgumentSemantic.Assign)]
        SCIHorizontalAnchorPoint HorizontalAnchorPoint { get; set; }

        // @property (nonatomic) SCIVerticalAnchorPoint verticalAnchorPoint;
        [Export("verticalAnchorPoint", ArgumentSemantic.Assign)]
        SCIVerticalAnchorPoint VerticalAnchorPoint { get; set; }
    }
}