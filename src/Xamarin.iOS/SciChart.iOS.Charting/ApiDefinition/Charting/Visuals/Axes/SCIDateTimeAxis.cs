using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIDateTimeAxis : SCITimeSpanAxisBase
    [BaseType(typeof(SCITimeSpanAxisBase))]
    interface SCIDateTimeAxis
    {
        // @property (copy, nonatomic) NSString * subDayTextFormatting;
        [Export("subDayTextFormatting")]
        string SubDayTextFormatting { get; set; }

        // @property (copy, nonatomic) NSString * subYearTextFormatting;
        [Export("subYearTextFormatting")]
        string SubYearTextFormatting { get; set; }

        // @property (copy, nonatomic) NSString * decadesTextFormatting;
        [Export("decadesTextFormatting")]
        string DecadesTextFormatting { get; set; }
    }
}