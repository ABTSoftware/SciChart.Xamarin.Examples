using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyzSeriesInfo : SCISeriesInfo
    [BaseType(typeof(SCISeriesInfo))]
    interface SCIXyzSeriesInfo
    {
        // -(SCIGenericType)zValue;
        [Export("zValue")]
        SCIGenericType ZValue { get; }
    }
}