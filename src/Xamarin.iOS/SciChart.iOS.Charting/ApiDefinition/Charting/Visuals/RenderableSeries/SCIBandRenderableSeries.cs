using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIBandRenderableSeries
    [BaseType(typeof(SCIRenderableSeriesBase))]
interface SCIFastBandRenderableSeries
    {
        // @property (copy, nonatomic) SCIBandSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIBandSeriesStyle Style { get; set; }

        // @property (nonatomic, copy) SCIBandSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIBandSeriesStyle SelectedSeriesStyle { get; set; }
    }
}