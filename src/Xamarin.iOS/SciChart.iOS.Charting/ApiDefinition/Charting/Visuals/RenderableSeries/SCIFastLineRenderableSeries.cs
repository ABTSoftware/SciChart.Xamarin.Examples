using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastLineRenderableSeries
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastLineRenderableSeries
    {
        // @property (copy, nonatomic) SCILineSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCILineSeriesStyle Style { get; set; }

        // @property (nonatomic, copy) SCILineSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCILineSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) BOOL isDigitalLine;
        [Export("isDigitalLine")]
        bool IsDigitalLine { get; set; }
    }
}