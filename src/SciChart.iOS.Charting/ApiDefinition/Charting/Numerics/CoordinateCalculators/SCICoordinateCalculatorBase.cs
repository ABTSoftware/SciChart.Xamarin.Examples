using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCICoordinateCalculatorBase : NSObject <SCICoordinateCalculatorProtocol>
    [BaseType(typeof(NSObject))]
    interface SCICoordinateCalculatorBase : SCICoordinateCalculatorProtocol
    {
        // +(double)flip:(BOOL)flipCoords Coords:(double)coord WithViewPortDimension:(double)viewportDimension;
        [Static]
        [Export("flip:Coords:WithViewPortDimension:")]
        double Flip(bool flipCoords, double coord, double viewportDimension);

        // -(void)setCoordinatesOffset:(double)value;
        [Export("setCoordinatesOffset:")]
        void SetCoordinatesOffset(double value);
    }
}