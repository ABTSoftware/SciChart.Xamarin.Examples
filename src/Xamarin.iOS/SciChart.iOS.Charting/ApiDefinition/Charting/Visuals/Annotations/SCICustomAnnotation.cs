using UIKit;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCICustomAnnotation : SCIAnnotationBase
    [BaseType(typeof(SCIAnnotationBase))]
    interface SCICustomAnnotation
    {
        // @property (nonatomic) SCIGenericType x1;
        [Export("x1", ArgumentSemantic.Assign)]
        SCIGenericType X1 { get; set; }

        // @property (nonatomic) SCIGenericType y1;
        [Export("y1", ArgumentSemantic.Assign)]
        SCIGenericType Y1 { get; set; }

        // @property (nonatomic) SCIGenericType x2;
        [Export("x2", ArgumentSemantic.Assign)]
        SCIGenericType X2 { get; set; }

        // @property (nonatomic) SCIGenericType y2;
        [Export("y2", ArgumentSemantic.Assign)]
        SCIGenericType Y2 { get; set; }

        // @property (nonatomic) UIView * customView;
        [Export("customView")]
        UIView CustomView { get; set; }

        // @property (copy, nonatomic) SCICustomAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCICustomAnnotationStyle Style { get; set; }
    }
}