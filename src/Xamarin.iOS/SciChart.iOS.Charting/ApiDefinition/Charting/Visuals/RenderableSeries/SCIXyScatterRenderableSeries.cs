using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyScatterRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIXyScatterRenderableSeries
    {
        // @property (copy, nonatomic) SCIScatterSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIScatterSeriesStyle Style { get; set; }

        //TODO should be SelectedSeriesStyle on obj-c side as well
        // @property (copy, nonatomic) SCIScatterSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIScatterSeriesStyle SelectedSeriesStyle { get; set; }

        // @required - (void)addAnimation:(id<SCIScatterRenderableSeriesAnimationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCIScatterRenderableSeriesAnimationProtocol animation);
    }
}