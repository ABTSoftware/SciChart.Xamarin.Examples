using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILogarithmicDoubleCoordinateCalculator : SCICoordinateCalculatorBase <SCILogarithmicCoordinateCalculatorProtocol>
    [BaseType(typeof(SCICoordinateCalculatorBase))]
    interface SCILogarithmicDoubleCoordinateCalculator : SCILogarithmicCoordinateCalculatorProtocol
    {
        // -(id)initWithDimension:(double)viewportDimension Min:(double)min Max:(double)max LogBase:(double)logBase Direction:(SCIXYDirection)direction FlipCoordinates:(BOOL)flipCoordinates;
        [Export("initWithDimension:Min:Max:LogBase:Direction:FlipCoordinates:")]
        IntPtr Constructor(double viewportDimension, double min, double max, double logBase, SCIXYDirection direction, bool flipCoordinates);

        // -(id)initWithDimension:(double)viewportDimension Min:(double)min Max:(double)max LogBase:(double)logBase IsXAxis:(BOOL)isXAxis IsHorizontal:(BOOL)isHorizintal FlipCoordinates:(BOOL)flipCoordinates;
        [Export("initWithDimension:Min:Max:LogBase:IsXAxis:IsHorizontal:FlipCoordinates:")]
        IntPtr Constructor(double viewportDimension, double min, double max, double logBase, bool isXAxis, bool isHorizintal, bool flipCoordinates);
    }
}