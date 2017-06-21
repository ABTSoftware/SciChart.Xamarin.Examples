using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIXyScatterRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIXyScatterRenderableSeries
    {
        // @property (copy, nonatomic) SCIScatterSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIScatterSeriesStyle Style { get; set; }

        // @property (nonatomic, copy) SCIScatterSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIScatterSeriesStyle SelectedSeriesStyle { get; set; }
    }
}