using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCITimeSpanAxisBase : SCIAxisBase
    [BaseType(typeof(SCIAxisBase))]
    interface SCITimeSpanAxisBase
    {
        // -(id<SCIRangeProtocol>)toVisibleRangeMin:(SCIGenericType)min Max:(SCIGenericType)max;
        [Export("toVisibleRangeMin:Max:")]
        ISCIRangeProtocol ToVisibleRangeMin(SCIGenericType min, SCIGenericType max);
    }
}