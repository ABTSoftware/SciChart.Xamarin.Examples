using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIPenLinearGradient : NSObject <SCIPen2DProtocol, SCILinearGradientBrushProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIPenLinearGradient : SCIPen2DProtocol, SCILinearGradientBrushProtocol
    {
        // -(id)initWithColorStart:(UIColor *)colorStart Finish:(UIColor *)colorFinish Direction:(SCILinearGradientDirection)direction Width:(float)width;
        [Export("initWithColorStart:Finish:Direction:Width:")]
        IntPtr Constructor(UIColor colorStart, UIColor colorFinish, SCILinearGradientDirection direction, float width);

        // -(id)initWithColorCodeStart:(unsigned int)colorStart Finish:(unsigned int)colorFinish Direction:(SCILinearGradientDirection)direction Width:(float)width;
        [Export("initWithColorCodeStart:Finish:Direction:Width:")]
        IntPtr Constructor(uint colorStart, uint colorFinish, SCILinearGradientDirection direction, float width);

        //TODO discuss unsafe code with iOS Team
        //// -(instancetype)initWithGradientCoords:(float *)coords Colors:(uint *)colors Count:(int)count Direction:(SCILinearGradientDirection)direction Width:(float)width;
        //[Export("initWithGradientCoords:Colors:Count:Direction:Width:")]
        //unsafe IntPtr Constructor(float* coords, uint* colors, int count, SCILinearGradientDirection direction, float width);
    }
}