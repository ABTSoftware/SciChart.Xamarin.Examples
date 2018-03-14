using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIPenDashed : NSObject <SCIPen2DProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIPenDashed : SCIPen2DProtocol
    {
        // -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color width:(float)width withStrokeDashArray:(NSArray<NSNumber *> * _Nonnull)dashArray;
        [Export("initWithColor:width:withStrokeDashArray:")]
        IntPtr Constructor(UIColor color, float width, NSNumber[] dashArray);

        // -(instancetype _Nonnull)initWithColorCode:(uint)color width:(float)width withStrokeDashArray:(NSArray<NSNumber *> * _Nonnull)dashArray;
        [Export("initWithColorCode:width:withStrokeDashArray:")]
        IntPtr Constructor(uint color, float width, NSNumber[] dashArray);

        // -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color width:(float)width withImageTexture:(UIImage * _Nonnull)textureImage;
        [Export("initWithColor:width:withImageTexture:")]
        IntPtr Constructor(UIColor color, float width, UIImage textureImage);
    }
}