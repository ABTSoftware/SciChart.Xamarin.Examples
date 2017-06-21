using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
	// @interface SCITextAnnotation : SCIAnchorPointAnnotation
	[BaseType(typeof(SCIAnchorPointAnnotation))]
    interface SCITextAnnotation
    {
        // @property (copy, nonatomic) NSString * text;
        [Export("text")]
        string Text { get; set; }

        // @property (copy, nonatomic) SCITextAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCITextAnnotationStyle Style { get; set; }
    }
}