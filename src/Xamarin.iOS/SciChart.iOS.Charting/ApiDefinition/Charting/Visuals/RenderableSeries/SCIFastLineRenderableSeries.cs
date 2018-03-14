using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastLineRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastLineRenderableSeries
    {
        // @property (copy, nonatomic) SCILineSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCILineSeriesStyle Style { get; set; }

        //TODO should be SelectedSeriesStyle on obj-c side as well
        // @property (copy, nonatomic) SCILineSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCILineSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) BOOL isDigitalLine;
        [Export("isDigitalLine")]
        bool IsDigitalLine { get; set; }


    }
}