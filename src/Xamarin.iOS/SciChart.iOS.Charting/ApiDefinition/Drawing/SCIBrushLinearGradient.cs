using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIBrushLinearGradient : NSObject <SCIBrush2DProtocol, SCILinearGradientBrushProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIBrushLinearGradient : SCIBrush2DProtocol, SCILinearGradientBrushProtocol
    {
        // -(id)initWithColorStart:(UIColor *)startColor Finish:(UIColor *)finishColor Direction:(SCILinearGradientDirection)gradientDirection;
        [Export("initWithColorStart:Finish:Direction:")]
        IntPtr Constructor(UIColor startColor, UIColor finishColor, SCILinearGradientDirection gradientDirection);

        // -(id)initWithColorCodeStart:(uint)startColor Finish:(uint)finishColor Direction:(SCILinearGradientDirection)gradientDirection;
        [Export("initWithColorCodeStart:Finish:Direction:")]
        IntPtr Constructor(uint startColor, uint finishColor, SCILinearGradientDirection gradientDirection);

        // TODO CHeck unsage ctor
        //// -(instancetype)initWithGradientCoords:(float *)coords Colors:(uint *)colors Count:(int)count Direction:(SCILinearGradientDirection)direction;
        //[Export("initWithGradientCoords:Colors:Count:Direction:")]
        //unsafe IntPtr Constructor(float* coords, uint* colors, int count, SCILinearGradientDirection direction);
    }
}