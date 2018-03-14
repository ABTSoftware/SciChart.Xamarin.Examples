using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCILogarithmicNumericTickProvider : SCINumericTickProvider
    [BaseType(typeof(SCINumericTickProvider))]
    interface SCILogarithmicNumericTickProvider
    {
        // @property (nonatomic) double logarithmicBase;
        [Export("logarithmicBase")]
        double LogarithmicBase { get; set; }
    }
}