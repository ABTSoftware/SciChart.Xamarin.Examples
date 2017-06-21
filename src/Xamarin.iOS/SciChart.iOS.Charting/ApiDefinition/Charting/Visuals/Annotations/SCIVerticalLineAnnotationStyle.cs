using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIVerticalLineAnnotationStyle : SCILineAnnotationStyle
    [BaseType(typeof(SCILineAnnotationStyle))]
    interface SCIVerticalLineAnnotationStyle
    {
        // @property (nonatomic) SCIVerticalLineAnnotationAlignment verticalAlignment;
        [Export("verticalAlignment", ArgumentSemantic.Strong)]
        SCIVerticalLineAnnotationAlignment VerticalAlignment { get; set; }
    }
}