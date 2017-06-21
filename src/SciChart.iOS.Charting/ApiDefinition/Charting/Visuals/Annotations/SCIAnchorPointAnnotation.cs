using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
	// @interface SCIAnchorPointAnnotation : SCIAnnotationBase
	[BaseType(typeof(SCIAnnotationBase))]
	interface SCIAnchorPointAnnotation
	{
		[Export("horizontalAnchorPoint")]
		SCIHorizontalAnchorPoint HorizontalAnchorPoint { get; set; }

		[Export("verticalAnchorPoint")]
		SCIVerticalAnchorPoint VerticalAnchorPoint { get; set; }
	}
}
