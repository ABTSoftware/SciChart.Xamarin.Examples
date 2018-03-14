using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    interface ISCIPointMarkerProtocol { }

    // @protocol SCIPointMarkerProtocol <NSObject, NSCopying>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
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

        // @required -(void)drawToContext:(id<SCIRenderContext2DProtocol>)context AtX:(float)x Y:(float)y;
        [Abstract]
        [Export("drawToContext:AtX:Y:")]
        void AtX(ISCIRenderContext2DProtocol context, float x, float y);

        // @required -(UIColor *)pointMarkerColor;
        // @required -(void)setPointMarkerColor:(UIColor *)color;
        [Abstract]
        [Export("pointMarkerColor")]
        UIColor Color { get; set; }

        // @required @property (nonatomic, strong) SCIBrushStyle * fillStyle;
        [Abstract]
        [Export("fillStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillStyle { get; set; }

        // @required @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Abstract]
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }
    }
}