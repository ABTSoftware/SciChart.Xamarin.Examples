using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCICoordinateCalculatorFactory : NSObject
    [BaseType(typeof(NSObject))]
    interface SCICoordinateCalculatorFactory
    {
        // +(id<SCICoordinateCalculatorProtocol>)getInstance:(SCIAxisParams *)arg;
        [Static]
        [Export("getInstance:")]
        ISCICoordinateCalculatorProtocol GetInstance(SCIAxisParams arg);
    }
}
