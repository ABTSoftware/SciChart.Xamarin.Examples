using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIFastUniformHeatmapRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCIFastUniformHeatmapRenderableSeries
    {
        // @property (copy, nonatomic) SCIUniformHeatmapSeriesStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIUniformHeatmapSeriesStyle Style { get; set; }

        // @property (copy, nonatomic) SCIUniformHeatmapSeriesStyle * selectedStyle;
        [Export("selectedStyle", ArgumentSemantic.Copy)]
        SCIUniformHeatmapSeriesStyle SelectedStyle { get; set; }

        // @property (nonatomic) double minimum;
        [Export("minimum")]
        double Minimum { get; set; }

        // @property (nonatomic) double maximum;
        [Export("maximum")]
        double Maximum { get; set; }

        // @property (nonatomic) SCITextureOpenGL * colorMap;
        [Export("colorMap", ArgumentSemantic.Assign)]
        SCITextureOpenGL ColorMap { get; set; }
    }
}