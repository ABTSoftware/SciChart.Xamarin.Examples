using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIBandSeriesStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIBandSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeY1Style;
        [Export("StrokeY1Style", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeY1Style { get; set; }

        // @property (nonatomic, strong) SCIBrushStyle * fillBrushStyle;
        [Export("fillBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillBrushStyle { get; set; }

        // @property (nonatomic, strong) SCIBrushStyle * fillY1BrushStyle;
        [Export("fillY1BrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillY1BrushStyle { get; set; }

        // @property (nonatomic) BOOL isDigitalLine;
        [Export("isDigitalLine")]
        bool IsDigitalLine { get; set; }

        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker;
        [Export("pointMarker1", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol PointMarker { get; set; }

        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker1;
        [Export("pointMarker2", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol PointMarker1 { get; set; }
    }
}