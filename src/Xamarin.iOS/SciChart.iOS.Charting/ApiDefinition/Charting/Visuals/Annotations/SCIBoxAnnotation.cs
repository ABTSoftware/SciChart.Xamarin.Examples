using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIBoxAnnotation : SCIAnnotationBase
    [BaseType(typeof(SCIAnnotationBase))]
    interface SCIBoxAnnotation
    {
        // @property (copy, nonatomic) SCIBoxAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIBoxAnnotationStyle Style { get; set; }
    }
}