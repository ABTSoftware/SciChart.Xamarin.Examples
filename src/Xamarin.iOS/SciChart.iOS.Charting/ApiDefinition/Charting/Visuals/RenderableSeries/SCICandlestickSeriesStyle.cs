using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCICandlestickSeriesStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCICandlestickSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCIPenStyle *strokeUpStyle;
        [Export("strokeUpStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeUpStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle *strokeDownStyle;
        [Export("strokeDownStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeDownStyle { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> upBodyBrush;
        [Export("fillUpBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillUpBrushStyle { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> downBodyBrush;
        [Export("fillDownBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillDownBrushStyle { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }
    }
}