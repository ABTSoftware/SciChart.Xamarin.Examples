using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCINumericTickProvider : NSObject <SCITickProviderProtocol>
    [BaseType(typeof(NSObject))]
    interface SCINumericTickProvider : SCITickProviderProtocol
    {
        // -(SCIArrayController *)calculateMajorTicksWithRange:(id<SCIRangeProtocol>)tickRange Delta:(id<SCIAxisDeltaProtocol>)tickDelta;
        [Export("calculateMajorTicksWithRange:Delta:")]
        SCIArrayController CalculateMajorTicksWithRange(ISCIRangeProtocol tickRange, ISCIAxisDeltaProtocol tickDelta);

        // -(SCIArrayController *)calculateMinorTicksWithRange:(id<SCIRangeProtocol>)tickRange Delta:(id<SCIAxisDeltaProtocol>)tickDelta;
        [Export("calculateMinorTicksWithRange:Delta:")]
        SCIArrayController CalculateMinorTicksWithRange(ISCIRangeProtocol tickRange, ISCIAxisDeltaProtocol tickDelta);
    }
}