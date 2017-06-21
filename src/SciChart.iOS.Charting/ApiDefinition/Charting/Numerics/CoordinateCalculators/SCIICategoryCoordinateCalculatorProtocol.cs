using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCICategoryCoordinateCalculatorProtocol : INSObjectProtocol, ISCICoordinateCalculatorProtocol { }

    // @protocol SCICategoryCoordinateCalculatorProtocol <NSObject, SCICoordinateCalculatorProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCICategoryCoordinateCalculatorProtocol
    {
        // @required -(int)transformDataToIndex:(NSNumber *)dataValue;
        [Abstract]
        [Export("transformDataToIndex:")]
        int TransformDataToIndex(NSNumber dataValue);
    }
}