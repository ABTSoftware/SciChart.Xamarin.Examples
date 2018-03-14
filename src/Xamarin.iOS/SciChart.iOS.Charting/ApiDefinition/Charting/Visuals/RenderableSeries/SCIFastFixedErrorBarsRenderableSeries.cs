using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastFixedErrorBarsRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastFixedErrorBarsRenderableSeries
    {
        // @property (copy, nonatomic) SCIErrorBarsSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIErrorBarsSeriesStyle Style { get; set; }

        // @property (copy, nonatomic) SCIErrorBarsSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIErrorBarsSeriesStyle SelectedStyle { get; set; }

        // @property (nonatomic) double errorHigh;
        [Export("errorHigh")]
        double ErrorHigh { get; set; }

        // @property (nonatomic) double errorLow;
        [Export("errorLow")]
        double ErrorLow { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }

        // @property (nonatomic) SCIErrorBarType errorType;
        [Export("errorType", ArgumentSemantic.Assign)]
        SCIErrorBarType ErrorType { get; set; }

        // @property (nonatomic) SCIErrorBarDirection errorDirection;
        [Export("errorDirection", ArgumentSemantic.Assign)]
        SCIErrorBarDirection ErrorDirection { get; set; }

        // @property (nonatomic) SCIErrorBarMode errorMode;
        [Export("errorMode", ArgumentSemantic.Assign)]
        SCIErrorBarMode ErrorMode { get; set; }

        // @property (nonatomic) SCIPenStyle * strokeHighStyle;
        [Export("strokeHighStyle", ArgumentSemantic.Assign)]
        SCIPenStyle StrokeHighStyle { get; set; }

        // @property (nonatomic) SCIPenStyle * strokeLowStyle;
        [Export("strokeLowStyle", ArgumentSemantic.Assign)]
        SCIPenStyle StrokeLowStyle { get; set; }

        // @required - (void)addAnimation:(id<SCIFixedErrorBarsRenderableSeriesAnimationProtocol>)animation;
        [Export("addAnimation:")]
        void AddAnimation(ISCIFixedErrorBarsRenderableSeriesAnimationProtocol animation);
    }
}