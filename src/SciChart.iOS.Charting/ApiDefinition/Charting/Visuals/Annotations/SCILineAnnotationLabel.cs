using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILineAnnotationLabel : UILabel
    [BaseType(typeof(UILabel))]
    interface SCILineAnnotationLabel
    {
        // @property(nonatomic, copy) SCIAnnotationLabelStyle* style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIAnnotationLabelStyle Style { get; set; }

        // -(void) applyStyle;
        [Export("applyStyle")]
        void ApplyStyle();
    }
}