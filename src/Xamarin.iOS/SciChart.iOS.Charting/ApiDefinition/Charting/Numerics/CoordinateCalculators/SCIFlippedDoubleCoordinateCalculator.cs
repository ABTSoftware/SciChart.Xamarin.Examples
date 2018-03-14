using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIFlippedDoubleCoordinateCalculator : SCICoordinateCalculatorBase
    [BaseType(typeof(SCICoordinateCalculatorBase))]
    interface SCIFlippedDoubleCoordinateCalculator
    {
        // -(id)initWithDimension:(double)viewportDimension Min:(double)min Max:(double)max Direction:(SCIDirection2D)direction FlipCoordinates:(BOOL)flipCoordinates;
        [Export("initWithDimension:Min:Max:Direction:FlipCoordinates:")]
        IntPtr Constructor(double viewportDimension, double min, double max, SCIDirection2D direction, bool flipCoordinates);

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