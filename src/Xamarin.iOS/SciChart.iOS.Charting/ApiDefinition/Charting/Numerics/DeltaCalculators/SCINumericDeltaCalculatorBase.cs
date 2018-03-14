using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCINumericDeltaCalculatorBase : NSObject <SCIDeltaCalculatorProtocol>
    [BaseType(typeof(NSObject))]
    interface SCINumericDeltaCalculatorBase : SCIDeltaCalculatorProtocol
    {
        // -(id<SCINiceScaleProtocol>)getScaleWithMin:(double)min Max:(double)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;
        [Export("getScaleWithMin:Max:MinorsPerMajor:MaxTicks:")]
        ISCINiceScaleProtocol GetScaleWithMin(double min, double max, int minorsPerMajor, uint maxTicks);
    }
}