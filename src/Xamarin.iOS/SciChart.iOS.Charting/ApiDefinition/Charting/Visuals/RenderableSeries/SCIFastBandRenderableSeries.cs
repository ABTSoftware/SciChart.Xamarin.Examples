using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastBandRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastBandRenderableSeries : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCIBandSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIBandSeriesStyle Style { get; set; }

        //TODO should be SelectedSeriesStyle on obj-c side as well
        // @property (copy, nonatomic) SCIBandSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIBandSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeStyle;
        [Export("strokeStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeStyle { get; set; }

        // @property (nonatomic, strong) SCIPenStyle * strokeY1Style;
        [Export("strokeY1Style", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeY1Style { get; set; }

        // @property (nonatomic, strong) SCIBrushStyle * fillBrushStyle;
        [Export("fillBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillBrushStyle { get; set; }

        // @property (nonatomic, strong) SCIBrushStyle * fillY1BrushStyle;
        [Export("fillY1BrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle FillY1BrushStyle { get; set; }

        // @property (nonatomic) BOOL isDigitalLine;
        [Export("isDigitalLine")]
        bool IsDigitalLine { get; set; }

        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker1;
        [Export("pointMarker1", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol PointMarker1 { get; set; }

        // @required - (void)addAnimation:(id<SCIBandRenderableSeriesAnimationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCIBandRenderableSeriesAnimationProtocol animation);
    }
}