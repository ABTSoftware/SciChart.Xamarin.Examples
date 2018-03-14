using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIOhlcSeriesInfo : SCISeriesInfo
    [BaseType(typeof(SCISeriesInfo))]
    interface SCIOhlcSeriesInfo
    {
        // -(SCIGenericType)openValue;
        [Export("openValue")]
        SCIGenericType OpenValue { get; }

        // -(SCIGenericType)highValue;
        [Export("highValue")]
        SCIGenericType HighValue { get; }

        // -(SCIGenericType)lowValue;
        [Export("lowValue")]
        SCIGenericType LowValue { get; }

        // -(SCIGenericType)closeValue;
        [Export("closeValue")]
        SCIGenericType CloseValue { get; }
    }
}