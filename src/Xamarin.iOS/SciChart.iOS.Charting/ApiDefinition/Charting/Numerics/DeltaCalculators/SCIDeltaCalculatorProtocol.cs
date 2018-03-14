using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIDeltaCalculatorProtocol { }

    // @protocol SCIDeltaCalculatorProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIDeltaCalculatorProtocol
    {
        // @required -(id<SCIAxisDeltaProtocol>)getDeltaFromRangeMin:(SCIGenericType)min Max:(SCIGenericType)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;
        [Abstract]
        [Export("getDeltaFromRangeMin:Max:MinorsPerMajor:MaxTicks:")]
        ISCIAxisDeltaProtocol GetDeltaFromRange(SCIGenericType min, SCIGenericType max, int minorsPerMajor, uint maxTicks);
    }
}