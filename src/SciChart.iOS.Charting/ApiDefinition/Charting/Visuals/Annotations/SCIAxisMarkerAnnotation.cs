using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisMarkerAnnotation : SCIAnnotationBase
    [BaseType(typeof(SCIAnnotationBase))]
    interface SCIAxisMarkerAnnotation
    {
        // @property (copy, nonatomic) SCIAxisMarkerAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIAxisMarkerAnnotationStyle Style { get; set; }

        // @property (copy, nonatomic) NSString * formattedValue;
        [Export("formattedValue")]
        string FormattedValue { get; set; }

        // Bounded in Extras
        // -(NSString *) formatValue:(SCIGenericType)value; 
    }
}