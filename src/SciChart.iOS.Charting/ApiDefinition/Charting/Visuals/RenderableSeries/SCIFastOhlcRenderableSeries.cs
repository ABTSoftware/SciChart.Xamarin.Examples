using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastOhlcRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastOhlcRenderableSeries
    {
        // @property (nonatomic, copy) SCIOhlcSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIOhlcSeriesStyle Style { get; set; }

        // @property (nonatomic, copy) SCIOhlcSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIOhlcSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeUpStyle;
        [Export("strokeUpStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeUpStyle { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> strokeDownStyle;
        [Export("strokeDownStyle", ArgumentSemantic.Strong)]
        SCIPenStyle StrokeDownStyle { get; set; }

        // @property (nonatomic) double dataPointWidth;
        [Export("dataPointWidth")]
        double DataPointWidth { get; set; }
    }
}