using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIDateTimeDeltaCalculator : SCITimeSpanDeltaCalculatorBase
    [BaseType(typeof(SCITimeSpanDeltaCalculatorBase))]
    interface SCIDateTimeDeltaCalculator
    {
        // +(SCIDateTimeDeltaCalculator *)instance;
        [Static]
        [Export("instance")]
        SCIDateTimeDeltaCalculator Instance { get; }
    }
}