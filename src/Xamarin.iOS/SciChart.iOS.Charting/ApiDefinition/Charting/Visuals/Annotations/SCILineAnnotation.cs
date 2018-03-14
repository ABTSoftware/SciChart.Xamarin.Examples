using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCILineAnnotation : SCIAnnotationBase
    [BaseType(typeof(SCIAnnotationBase))]
    interface SCILineAnnotation
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

        // @property (copy, nonatomic) SCILineAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCILineAnnotationStyle Style { get; set; }
    }
}