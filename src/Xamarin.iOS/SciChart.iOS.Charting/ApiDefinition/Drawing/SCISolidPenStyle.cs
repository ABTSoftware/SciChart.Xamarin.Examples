using System;
using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCISolidPenStyle : SCIPenStyle
    [BaseType(typeof(SCIPenStyle))]
    interface SCISolidPenStyle
    {
        // -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color withThickness:(float)thickness andStrokeDash:(NSArray<NSNumber *> * _Nonnull)strokeDashArray;
        [Export("initWithColor:withThickness:andStrokeDash:")]
        IntPtr Constructor(UIColor color, float thickness, NSNumber[] strokeDashArray);

        // -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color withThickness:(float)thickness;
        [Export("initWithColor:withThickness:")]
        IntPtr Constructor(UIColor color, float thickness);

        // -(instancetype _Nonnull)initWithColorCode:(unsigned int)colorCode withThickness:(float)thickness;
        [Export("initWithColorCode:withThickness:")]
        IntPtr Constructor(uint colorCode, float thickness);

        // -(instancetype _Nonnull)initWithColorCode:(unsigned int)colorCode withThickness:(float)thickness andStrokeDash:(NSArray<NSNumber *> * _Nonnull)strokeDashArray;
        [Export("initWithColorCode:withThickness:andStrokeDash:")]
        IntPtr Constructor(uint colorCode, float thickness, NSNumber[] strokeDashArray);
    }
}