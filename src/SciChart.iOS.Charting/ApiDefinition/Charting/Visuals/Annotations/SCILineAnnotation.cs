using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILineAnnotation : SCIAnnotationBase
    [BaseType(typeof(SCIAnnotationBase))]
    interface SCILineAnnotation
    {
        // @property (copy, nonatomic) SCILineAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCILineAnnotationStyle Style { get; set; }
    }
}