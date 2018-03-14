using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIDateDeltaCalculatorProtocol { }

    // @protocol SCIDateDeltaCalculatorProtocol <SCIDeltaCalculatorProtocol>
    [Protocol, Model]
    interface SCIDateDeltaCalculatorProtocol : SCIDeltaCalculatorProtocol
    {
        // BTOUCH: Error BI1038: bgen: The selector GetDeltaFromRange on type SCITimeSpanDeltaCalculatorBase is found multiple times with different return types. 
        // Already declared in SCIDeltaCalculatorProtocol
        // @required -(SCITimeSpanDelta *)getDeltaFromRangeMin:(SCIGenericType)min Max:(SCIGenericType)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;
        //[Abstract]
        //[Export("getDeltaFromRangeMin:Max:MinorsPerMajor:MaxTicks:")]
        //SCITimeSpanDelta GetTimeSpanDeltaFromRange(SCIGenericType min, SCIGenericType max, int minorsPerMajor, uint maxTicks);
    }
}