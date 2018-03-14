using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCILinearGradientPenStyle : SCIPenStyle
    [BaseType(typeof(SCIPenStyle))]
    interface SCILinearGradientPenStyle
    {
        // @property (nonatomic) NSArray<UIColor *> * _Nonnull colors;
        [Export("colors", ArgumentSemantic.Assign)]
        UIColor[] Colors { get; set; }

        // @property (nonatomic) NSArray<NSNumber *> * _Nonnull stops;
        [Export("stops", ArgumentSemantic.Assign)]
        NSNumber[] Stops { get; set; }

        // @property (nonatomic) SCILinearGradientDirection direction;
        [Export("direction", ArgumentSemantic.Assign)]
        SCILinearGradientDirection Direction { get; set; }

        // @property (readonly, nonatomic) UIColor * _Nonnull color;
        [Export("color")]
        UIColor Color { get; }

        // @property (readonly, nonatomic) unsigned int colorCode;
        [Export("colorCode")]
        uint ColorCode { get; }

        // -(instancetype _Nonnull)initWithColorStart:(UIColor * _Nonnull)colorStart finish:(UIColor * _Nonnull)colorFinish direction:(SCILinearGradientDirection)direction thickness:(float)thickness;
        [Export("initWithColorStart:finish:direction:thickness:")]
        IntPtr Constructor(UIColor colorStart, UIColor colorFinish, SCILinearGradientDirection direction, float thickness);

        // -(instancetype _Nonnull)initWithColorCodeStart:(unsigned int)colorStart finish:(unsigned int)colorFinish direction:(SCILinearGradientDirection)direction thickness:(float)thickness;
        [Export("initWithColorCodeStart:finish:direction:thickness:")]
        IntPtr Constructor(uint colorStart, uint colorFinish, SCILinearGradientDirection direction, float thickness);

        // Todo discuss unsafe code with iOS team
        //// -(instancetype _Nonnull)initWithGradientStops:(float * _Nonnull)stops colors:(uint * _Nonnull)colors count:(int)count direction:(SCILinearGradientDirection)direction thickness:(float)thickness;
        //[Export("initWithGradientStops:colors:count:direction:thickness:")]
        //unsafe IntPtr Constructor(float* stops, uint* colors, int count, SCILinearGradientDirection direction, float thickness);
    }
}