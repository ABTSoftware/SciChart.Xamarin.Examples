using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCILogarithmicDoubleCoordinateCalculator : SCICoordinateCalculatorBase <SCILogarithmicCoordinateCalculatorProtocol>
    [BaseType(typeof(SCICoordinateCalculatorBase))]
    interface SCILogarithmicDoubleCoordinateCalculator : SCILogarithmicCoordinateCalculatorProtocol
    {
        // -(id)initWithDimension:(double)viewportDimension Min:(double)min Max:(double)max LogBase:(double)logBase Direction:(SCIDirection2D)direction FlipCoordinates:(BOOL)flipCoordinates;
        [Export("initWithDimension:Min:Max:LogBase:Direction:FlipCoordinates:")]
        IntPtr Constructor(double viewportDimension, double min, double max, double logBase, SCIDirection2D direction, bool flipCoordinates);

        // -(id)initWithDimension:(double)viewportDimension Min:(double)min Max:(double)max LogBase:(double)logBase IsXAxis:(BOOL)isXAxis IsHorizontal:(BOOL)isHorizintal FlipCoordinates:(BOOL)flipCoordinates;
        [Export("initWithDimension:Min:Max:LogBase:IsXAxis:IsHorizontal:FlipCoordinates:")]
        IntPtr Constructor(double viewportDimension, double min, double max, double logBase, bool isXAxis, bool isHorizintal, bool flipCoordinates);
    }
}