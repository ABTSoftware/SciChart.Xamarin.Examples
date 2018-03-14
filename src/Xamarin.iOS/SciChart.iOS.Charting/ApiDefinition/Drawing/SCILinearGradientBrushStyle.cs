using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCILinearGradientBrushStyle : SCIBrushStyle
    [BaseType(typeof(SCIBrushStyle))]
    interface SCILinearGradientBrushStyle
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

        // -(instancetype _Nonnull)initWithColorStart:(UIColor * _Nonnull)colorStart finish:(UIColor * _Nonnull)colorFinish direction:(SCILinearGradientDirection)direction;
        [Export("initWithColorStart:finish:direction:")]
        IntPtr Constructor(UIColor colorStart, UIColor colorFinish, SCILinearGradientDirection direction);

        // -(instancetype _Nonnull)initWithColorCodeStart:(uint)colorStart finish:(uint)colorFinish direction:(SCILinearGradientDirection)direction;
        [Export("initWithColorCodeStart:finish:direction:")]
        IntPtr Constructor(uint colorStart, uint colorFinish, SCILinearGradientDirection direction);

        // TODO discuss unsafe code with iOS team
        //// -(instancetype _Nonnull)initWithGradientStops:(float * _Nonnull)stops colors:(uint * _Nonnull)colors count:(int)count direction:(SCILinearGradientDirection)direction;
        //[Export("initWithGradientStops:colors:count:direction:")]
        //unsafe IntPtr Constructor(float* stops, uint* colors, int count, SCILinearGradientDirection direction);
    }
}