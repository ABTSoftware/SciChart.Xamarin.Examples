using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastImpulseRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastImpulseRenderableSeries : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCIImpulseSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIImpulseSeriesStyle Style { get; set; }

        // @property (copy, nonatomic) SCIImpulseSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIImpulseSeriesStyle SelectedStyle { get; set; }
    }
}