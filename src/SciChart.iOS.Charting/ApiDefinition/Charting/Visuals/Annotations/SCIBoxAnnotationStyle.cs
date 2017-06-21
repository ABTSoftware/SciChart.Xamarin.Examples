using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIBoxAnnotationStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIBoxAnnotationStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> resizeMarker;
        [Export("resizeMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol ResizeMarker { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> borderPen;
        [Export("borderPen", ArgumentSemantic.Strong)]
        SCIPenStyle BorderPen { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> fillBrush;
        [Export("fillBrush", ArgumentSemantic.Strong)]
        SCIBrushStyle FillBrush { get; set; }

        // @property (nonatomic) double selectRadius;
        [Export("selectRadius")]
        double SelectRadius { get; set; }

        // @property (nonatomic) double resizeRadius;
        [Export("resizeRadius")]
        double ResizeRadius { get; set; }

        // @property (nonatomic) SCIAnnotationLayerMode layer;
        [Export("layer", ArgumentSemantic.Assign)]
        SCIAnnotationLayerMode Layer { get; set; }
    }
}