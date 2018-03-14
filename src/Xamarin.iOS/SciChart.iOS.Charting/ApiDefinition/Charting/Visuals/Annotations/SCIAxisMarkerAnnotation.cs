using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisMarkerAnnotation : SCIAxisMarkerAnnotationBase
    [BaseType(typeof(SCIAxisMarkerAnnotationBase))]
    interface SCIAxisMarkerAnnotation
    {
        // @property (nonatomic) SCIGenericType position;
        [Export("position", ArgumentSemantic.Assign)]
        SCIGenericType Position_native { get; set; }
    }
}