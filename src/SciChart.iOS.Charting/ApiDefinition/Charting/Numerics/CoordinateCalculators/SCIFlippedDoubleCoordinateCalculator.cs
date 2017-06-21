using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIFlippedDoubleCoordinateCalculator : SCICoordinateCalculatorBase
    [BaseType(typeof(SCICoordinateCalculatorBase))]
    interface SCIFlippedDoubleCoordinateCalculator
    {
        // -(id)initWithDimension:(double)viewportDimension Min:(double)min Max:(double)max Direction:(SCIXYDirection)direction FlipCoordinates:(BOOL)flipCoordinates;
        [Export("initWithDimension:Min:Max:Direction:FlipCoordinates:")]
        IntPtr Constructor(double viewportDimension, double min, double max, SCIXYDirection direction, bool flipCoordinates);

        // -(id)initWithDimension:(double)viewportDimension Min:(double)min Max:(double)max IsXAxis:(BOOL)isXAxis IsHorizontal:(BOOL)isHorizintal FlipCoordinates:(BOOL)flipCoordinates;
        [Export("initWithDimension:Min:Max:IsXAxis:IsHorizontal:FlipCoordinates:")]
        IntPtr Constructor(double viewportDimension, double min, double max, bool isXAxis, bool isHorizintal, bool flipCoordinates);

        // @property (nonatomic) double coordinateConstant;
        [Export("coordinateConstant")]
        double CoordinateConstant { get; set; }

        // @property (nonatomic) double coordinatesOffset;
        [Export("coordinatesOffset")]
        double CoordinatesOffset { get; set; }
    }
}