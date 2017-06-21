using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIErrorBarsSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIErrorBarsSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeHighStyle;
        [Export("strokeHighStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeHighStyle { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeLowStyle;
        [Export("strokeLowStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeLowStyle { get; set; }
    }
}