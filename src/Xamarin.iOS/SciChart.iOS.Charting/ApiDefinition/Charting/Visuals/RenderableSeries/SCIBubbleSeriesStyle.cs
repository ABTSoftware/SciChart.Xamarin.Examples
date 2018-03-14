using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIBubbleSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIBubbleSeriesStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic, strong) SCIBrushStyle * bubbleBrushStyle;
        [Export("bubbleBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle BubbleBrushStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic) int detalization;
        [Export("detalization")]
        int Detalization { get; set; }
    }
}