using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastUniformHeatmapRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastUniformHeatmapRenderableSeries
    {
        // @property (nonatomic, strong) SCIHeatMapSeriesStyle * style;
        [Export("style", ArgumentSemantic.Strong)]
        SCIUniformHeatmapSeriesStyle Style { get; set; }

        // @property (nonatomic, copy) SCIUniformHeatmapSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIUniformHeatmapSeriesStyle SelectedSeriesStyle { get; set; }

        // @property (nonatomic) double minimum;
        [Export("minimum")]
        double Minimum { get; set; }

        // @property (nonatomic) double maximum;
        [Export("maximum")]
        double Maximum { get; set; }

        // @property (nonatomic, strong) SCITextureOpenGL * colorMap;
        [Export("colorMap")]
        SCITextureOpenGL ColorMap { get; set; }
    }
}