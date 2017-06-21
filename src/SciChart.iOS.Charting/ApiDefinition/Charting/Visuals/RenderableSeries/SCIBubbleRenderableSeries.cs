using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIBubbleRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIBubbleRenderableSeries
    {
        // @property (copy, nonatomic) SCIBubbleSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIBubbleSeriesStyle Style { get; set; }

        // @property (nonatomic, copy) SCIBubbleSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIBubbleSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) double zScale;
        [Export("zScaleFactor")]
        double ZScaleFactor { get; set; }

        // @property (nonatomic) BOOL autoZRange;
        [Export("autoZRange")]
        bool AutoZRange { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> bubbleBrushStyle;
        [Export("bubbleBrushStyle", ArgumentSemantic.Strong)]
        SCIBrushStyle BubbleBrushStyle { get; set; }
    }
}