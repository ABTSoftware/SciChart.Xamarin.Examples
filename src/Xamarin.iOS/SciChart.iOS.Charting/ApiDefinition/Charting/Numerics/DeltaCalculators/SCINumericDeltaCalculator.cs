using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCINumericDeltaCalculator : SCINumericDeltaCalculatorBase
    [BaseType(typeof(SCINumericDeltaCalculatorBase))]
    interface SCINumericDeltaCalculator
    {
        // +(SCINumericDeltaCalculatorBase *)instance;
        [Static]
        [Export("instance")]
        SCINumericDeltaCalculatorBase Instance { get; }
    }
}