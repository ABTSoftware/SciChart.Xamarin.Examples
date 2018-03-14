using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastOhlcRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastOhlcRenderableSeries : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCIOhlcSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIOhlcSeriesStyle Style { get; set; }

        //TODO should be SelectedSeriesStyle on obj-c side as well
        // @property (copy, nonatomic) SCIOhlcSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIOhlcSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) SCIPenStyle * strokeUpStyle;
        [Export("strokeUpStyle", ArgumentSemantic.Assign)]
        SCIPenStyle StrokeUpStyle { get; set; }

        // @property (nonatomic) SCIPenStyle * strokeDownStyle;
        [Export("strokeDownStyle", ArgumentSemantic.Assign)]
        SCIPenStyle StrokeDownStyle { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }

        // @required - (void)addAnimation:(id<SCIOhlcRenderableSeriesAnimationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCIOhlcRenderableSeriesAnimationProtocol animation);
    }
}