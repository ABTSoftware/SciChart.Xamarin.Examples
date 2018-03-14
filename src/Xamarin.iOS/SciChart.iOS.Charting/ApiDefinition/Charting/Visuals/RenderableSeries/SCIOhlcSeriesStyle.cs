using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIOhlcSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIOhlcSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCIPenStyle * strokeUpStyle;
        [Export("strokeUpStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeUpStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeDownStyle;
        [Export("strokeDownStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeDownStyle { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }
    }
}