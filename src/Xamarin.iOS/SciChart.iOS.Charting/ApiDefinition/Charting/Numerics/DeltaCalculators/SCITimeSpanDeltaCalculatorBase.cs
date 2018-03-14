using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCITimeSpanDeltaCalculatorBase : NSObject <SCIDateDeltaCalculatorProtocol>
    [BaseType(typeof(NSObject))]
    interface SCITimeSpanDeltaCalculatorBase : SCIDateDeltaCalculatorProtocol
    {
        // -(double)getTicks:(SCIGenericType)value;
        [Export("getTicks:")]
        double GetTicks(SCIGenericType value);
    }
}