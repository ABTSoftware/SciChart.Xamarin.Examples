using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIBubbleRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIBubbleRenderableSeries
    {
        // @property (copy, nonatomic) SCIBubbleSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIBubbleSeriesStyle Style { get; set; }

        //TODO should be SelectedSeriesStyle on obj-c side as well
        // @property (copy, nonatomic) SCIBubbleSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIBubbleSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) double zScaleFactor;
        [Export("zScaleFactor")]
        double ZScaleFactor { get; set; }

        // @property (nonatomic) BOOL autoZRange;
        [Export("autoZRange")]
        bool AutoZRange { get; set; }

        // @property (nonatomic) SCIBrushStyle * bubbleBrushStyle;
        [Export("bubbleBrushStyle", ArgumentSemantic.Assign)]
        SCIBrushStyle BubbleBrushStyle { get; set; }

        // @required - (void)addAnimation:(id<SCIBubbleRenderableSeriesAnimationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCIBubbleRenderableSeriesAnimationProtocol animation);
    }
}