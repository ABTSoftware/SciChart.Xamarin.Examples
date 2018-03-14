using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIBaseColumnRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIBaseColumnRenderableSeries : SCIThemeableProtocol
    {
        // @property (copy, nonatomic) SCIColumnSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIColumnSeriesStyle Style { get; set; }

        //TODO should be SelectedSeriesStyle on obj-c side as well
        // @property (copy, nonatomic) SCIColumnSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIColumnSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) SCIBrushStyle * fillBrushStyle;
        [Export("fillBrushStyle", ArgumentSemantic.Assign)]
        SCIBrushStyle FillBrushStyle { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }

        // @required - (void)addAnimation:(id<SCIColumnRenderableSeriesAnimationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCIColumnRenderableSeriesAnimationProtocol animation);
    }
}