using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastImpulseRenderableSeries : SCIRenderableSeriesBase <SCIThemebleProtocol>
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastImpulseRenderableSeries
    {
        // @property (copy, nonatomic) SCIImpulseSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIImpulseSeriesStyle Style { get; set; }

        // @property (copy, nonatomic) SCIImpulseSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIImpulseSeriesStyle SelectedStyle { get; set; }
    }
}