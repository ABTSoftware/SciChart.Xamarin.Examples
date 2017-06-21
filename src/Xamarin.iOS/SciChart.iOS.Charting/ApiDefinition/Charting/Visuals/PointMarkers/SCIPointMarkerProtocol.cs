using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @protocol SCIPointMarkerProtocol <NSObject, NSCopying>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIPointMarkerProtocol : INSCopying
    {
        // @required @property (nonatomic) float width;
        [Abstract]
        [Export("width")]
        float Width { get; set; }

        // @required @property (nonatomic) float height;
        [Abstract]
        [Export("height")]
        float Height { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> fillBrush;
        [Abstract]
        [Export("fillStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillStyle { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> borderPen;
        [Abstract]
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @required -(void)drawToContext:(id<ISCIRenderContext2DProtocol>)context AtX:(float)x Y:(float)y;
        [Abstract]
        [Export("drawToContext:AtX:Y:")]
        void AtX(ISCIRenderContext2DProtocol context, float x, float y);

        // @required -(UIColor *)pointMarkerColor;
        // @required -(void)setPointMarkerColor:(UIColor *)color;
        [Abstract]
        [Export("pointMarkerColor")]
        UIColor Color { get; set; }
    }
}