using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIErrorBarsSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIErrorBarsSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeHighStyle;
        [Export("strokeHighStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeHighStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeLowStyle;
        [Export("strokeLowStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeLowStyle { get; set; }
    }
}