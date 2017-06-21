using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisInteractivityHelper : NSObject <SCIAxisInteractivityHelperProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIAxisInteractivityHelper : SCIAxisInteractivityHelperProtocol
    {
        // - (id)initWithCoordinateCalculator:(id <SCICoordinateCalculatorProtocol>)coordCalculator;
        [Export("initWithCoordinateCalculator:")]
        IntPtr Constructor(ISCICoordinateCalculatorProtocol coordCalculator);
    }
}