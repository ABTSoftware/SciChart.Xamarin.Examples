using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIDateTimeLabelProvider : SCILabelProviderBase
    [BaseType(typeof(SCILabelProviderBase))]
    interface SCIDateTimeLabelProvider
    {
		// @property (nonatomic, nullable) NSTimeZone *timeZone;
		[Export("timeZone")]
		NSTimeZone TimeZone { get; set; }
    }
}