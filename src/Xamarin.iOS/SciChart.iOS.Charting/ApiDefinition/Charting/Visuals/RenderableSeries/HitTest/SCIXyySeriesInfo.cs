using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyySeriesInfo : SCISeriesInfo
    [BaseType(typeof(SCISeriesInfo))]
    interface SCIXyySeriesInfo
    {
        // -(SCIGenericType)y1Value;
        [Export("y1Value")]
        SCIGenericType Y1Value { get; }

        // -(SCIGenericType)y2Value;
        [Export("y2Value")]
        SCIGenericType Y2Value { get; }
    }
}