using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCILogarithmicCoordinateCalculatorProtocol : ISCICoordinateCalculatorProtocol { }

    interface ISCILogarithmicCoordinateCalculator : ISCILogarithmicCoordinateCalculatorProtocol { }
    
    // @protocol SCILogarithmicCoordinateCalculatorProtocol <SCICoordinateCalculatorProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCILogarithmicCoordinateCalculatorProtocol : SCICoordinateCalculatorProtocol
    {
        // @required -(double)logarithmicBase;
        [Abstract]
        [Export("logarithmicBase")]
        double LogarithmicBase { get; }
    }
}