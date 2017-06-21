using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIDeltaCalculatorProtocol { }

    // @protocol SCIDeltaCalculatorProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIDeltaCalculatorProtocol
    {
        // @required -(id<SCIAxisDeltaProtocol>)getDeltaFromRangeMin:(id)min Max:(id)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;
        [Abstract]
        [Export("getDeltaFromRangeMin:Max:MinorsPerMajor:MaxTicks:")]
        ISCIAxisDeltaProtocol GetDeltaFromRange(NSObject min, NSObject max, int minorsPerMajor, uint maxTicks);
    }
}