using System;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
	// @interface SCICustomAnnotation : SCIAnnotationBase
	[BaseType(typeof(SCIAnnotationBase))]
	interface SCICustomAnnotation
	{
        [NullAllowed,Export("contentView")]
		UIView ContentView { get; set; }

		// @property (copy, nonatomic) SCICustomAnnotationStyle * style;
		[Export("style", ArgumentSemantic.Copy)]
		SCICustomAnnotationStyle Style { get; set; }
	}
}