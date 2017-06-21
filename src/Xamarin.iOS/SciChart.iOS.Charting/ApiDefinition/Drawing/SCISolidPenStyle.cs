using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{

    [BaseType(typeof(SCIPenStyle))]
    interface SCISolidPenStyle : SCIPenStyle
    {
		// - (nonnull instancetype)initWithColor:(nonnull UIColor*)color withThickness:(float) thickness;
		[Export("initWithColor:withThickness:")]
		IntPtr Constructor(UIColor color, float thickness);

		// - (nonnull instancetype)initWithColor:(nonnull UIColor*)color withThickness:(float) thickness andStrokeDash:(nonnull NSArray<NSNumber*>*)strokeDashArray;
		[Export("initWithColor:withThickness:andStrokeDash:")]
        IntPtr Constructor(UIColor color, float thickness, NSNumber[] strokeDashArray);

		// - (nonnull instancetype)initWithColorCode:(unsigned int)colorCode withThickness:(float) thickness;
        [Export("initWithColorCode:withThickness:")]
        IntPtr Constructor(uint color, float thickness);

		// - (nonnull instancetype)initWithColorCode:(unsigned int)colorCode withThickness:(float) thickness andStrokeDash:(nonnull NSArray<NSNumber*>*)strokeDashArray;
		[Export("initWithColorCode:withThickness:andStrokeDash:")]
		IntPtr Constructor(uint color, float thickness, NSNumber[] strokeDashArray);
    }
}