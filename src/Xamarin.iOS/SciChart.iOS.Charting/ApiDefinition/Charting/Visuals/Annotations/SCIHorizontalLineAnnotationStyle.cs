using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIHorizontalLineAnnotationStyle : SCILineAnnotationStyle
    [BaseType(typeof(SCILineAnnotationStyle))]
    interface SCIHorizontalLineAnnotationStyle
    {
        // @property (nonatomic) SCIHorizontalLineAnnotationAlignment horizontalAlignment;
        [Export("horizontalAlignment", ArgumentSemantic.Strong)]
        SCIHorizontalLineAnnotationAlignment HorizontalAlignment { get; set; }
    }
}