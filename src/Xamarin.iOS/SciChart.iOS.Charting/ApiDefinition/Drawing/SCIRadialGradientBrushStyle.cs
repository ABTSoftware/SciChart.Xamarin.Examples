using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace SciChart.iOS.Charting
{
    //@interface SCIRadialGradientBrushStyle : SCIBrushStyle
    [BaseType(typeof(SCIBrushStyle))]
    interface SCIRadialGradientBrushStyle
    {
        // @property (nonatomic) NSArray<UIColor *> * _Nonnull colors;
        [Export("colors")]
        UIColor[] Colors { get; set; }

        // @property (nonatomic) NSArray<NSNumber *> * _Nonnull stops;
        [Export("stops")]
        NSNumber[] Stops { get; set; }

        //@property(nonatomic) CGPoint center;
        [Export("center")]
        CGPoint Center { get; set; }

        // @property (readonly, nonatomic) UIColor * _Nonnull color;
        [Export("color")]
        UIColor Color { get; }

        // @property (readonly, nonatomic) unsigned int colorCode;
        [Export("colorCode")]
        uint ColorCode { get; }

        // -(instancetype _Nonnull)initWithColorStart:(UIColor * _Nonnull)colorStart finish:(UIColor * _Nonnull)colorFinish direction:(SCILinearGradientDirection)direction;
        [Export("initWithColorStart:finish:")]
        IntPtr Constructor(UIColor colorStart, UIColor colorFinish);

        // -(instancetype _Nonnull)initWithColorCodeStart:(uint)colorStart finish:(uint)colorFinish direction:(SCILinearGradientDirection)direction;
        [Export("initWithColorCodeStart:finish:")]
        IntPtr Constructor(uint colorStart, uint colorFinish);

        //- (nonnull instancetype) initWithCenter:(CGPoint) center colorStart:(nonnull UIColor *)colorStart finish:(nonnull UIColor *)colorFinish;
        [Export("initWithCenter:colorStart:finish:")]
        IntPtr Constructor(CGPoint center, UIColor colorStart, UIColor colorFinish);

        //- (nonnull instancetype) initWithCenter:(CGPoint) center colorCodeStart:(uint) colorStart finish:(uint) colorFinish;
        [Export("initWithCenter:colorCodeStart:finish:")]
        IntPtr Constructor(CGPoint center, uint colorStart, uint colorFinish);
    }
}
