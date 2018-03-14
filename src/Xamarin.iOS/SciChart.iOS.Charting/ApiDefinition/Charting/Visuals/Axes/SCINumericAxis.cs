using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCINumericAxis : SCIAxisBase
    [BaseType(typeof(SCIAxisBase))]
    interface SCINumericAxis
    {
        // @property (nonatomic) NSNumberFormatter * numberFormatter;
        [Export("numberFormatter", ArgumentSemantic.Assign)]
        NSNumberFormatter NumberFormatter { get; set; }
    }
}