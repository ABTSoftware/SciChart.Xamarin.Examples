using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastCandlestickRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastCandlestickRenderableSeries : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCICandlestickSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCICandlestickSeriesStyle Style { get; set; }

        //TODO should be SelectedSeriesStyle on obj-c side as well
        // @property (copy, nonatomic) SCICandlestickSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCICandlestickSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) SCIPenStyle * strokeUpStyle;
        [Export("strokeUpStyle", ArgumentSemantic.Assign)]
        SCIPenStyle StrokeUpStyle { get; set; }

        // @property (nonatomic) SCIPenStyle * strokeDownStyle;
        [Export("strokeDownStyle", ArgumentSemantic.Assign)]
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

        // @required - (void)addAnimation:(id<SCICandleStickRenderableSeriesAnimationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCICandleStickRenderableSeriesAnimationProtocol animation);
    }
}