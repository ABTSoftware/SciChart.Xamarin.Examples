using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

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

        //@property(nonatomic) double errorHigh;
        [Export("errorHigh", ArgumentSemantic.Copy)]
        double ErrorHigh { get; set; }

        //@property(nonatomic) double errorLow;
        [Export("errorLow", ArgumentSemantic.Copy)]
        double ErrorLow { get; set; }

        //@property(nonatomic) double dataPointWidth;
        [Export("dataPointWidth", ArgumentSemantic.Copy)]
        double DataPointWidth { get; set; }

        //@property(nonatomic) SCIErrorBarType errorType;
        [Export("errorType", ArgumentSemantic.Copy)]
        SCIErrorBarType ErrorType { get; set; }

        //@property(nonatomic) SCIErrorBarDirection errorDirection;
        [Export("errorDirection", ArgumentSemantic.Copy)]
        SCIErrorBarDirection ErrorDirection { get; set; }

        //@property(nonatomic) SCIErrorBarMode errorMode;
        [Export("errorMode", ArgumentSemantic.Copy)]
        SCIErrorBarMode ErrorMode { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeHighStyle;
        [Export("strokeHighStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeHighStyle { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeLowStyle;
        [Export("strokeLowStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeLowStyle { get; set; }
    }
}