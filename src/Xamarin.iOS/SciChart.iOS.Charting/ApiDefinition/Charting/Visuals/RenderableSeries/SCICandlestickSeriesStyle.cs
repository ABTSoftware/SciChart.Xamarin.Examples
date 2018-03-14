using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCICandlestickSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCICandlestickSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCIPenStyle * strokeUpStyle;
        [Export("strokeUpStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeUpStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeDownStyle;
        [Export("strokeDownStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeDownStyle { get; set; }

        // @property (nonatomic, strong) SCIBrushStyle * fillUpBrushStyle;
        [Export("fillUpBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillUpBrushStyle { get; set; }

        // @property (nonatomic, strong) SCIBrushStyle * fillDownBrushStyle;
        [Export("fillDownBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillDownBrushStyle { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }
    }
}