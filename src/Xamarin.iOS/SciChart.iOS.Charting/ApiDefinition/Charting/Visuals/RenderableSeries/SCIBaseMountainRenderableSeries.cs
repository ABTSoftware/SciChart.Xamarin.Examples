using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIBaseMountainRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIBaseMountainRenderableSeries : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCIMountainSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIMountainSeriesStyle Style { get; set; }

        //TODO should be SelectedSeriesStyle on obj-c side as well
        // @property (copy, nonatomic) SCIMountainSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIMountainSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) BOOL isDigitalLine;
        [Export("isDigitalLine")]
        bool IsDigitalLine { get; set; }

        // @property (nonatomic, strong) id<SCIBrushStyleProtocol> areaStyle;
        [Export("areaStyle", ArgumentSemantic.Strong)]
        ISCIBrushStyleProtocol AreaStyle { get; set; }

        // @required - (void)addAnimation:(id<SCIMountainRenderableSeriesAnimationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCIMountainRenderableSeriesAnimationProtocol animation);
    }
}