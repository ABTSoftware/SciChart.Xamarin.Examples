using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIColumnSeriesStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIColumnSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> fillBrushStyle;
        [Export("fillBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillBrushStyle { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }
    }
}