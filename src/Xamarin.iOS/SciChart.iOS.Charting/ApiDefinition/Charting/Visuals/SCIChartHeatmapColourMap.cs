using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIChartHeatmapColourMap : UIView <SCIThemeableProtocol>
    [BaseType(typeof(UIView))]
    interface SCIChartHeatmapColourMap : SCIThemeableProtocol
    {
        // @property (nonatomic) UIFont * _Nonnull font;
        [Export("font", ArgumentSemantic.Assign)]
        UIFont Font { get; set; }

        // @property (nonatomic) UIColor * _Nonnull textColor;
        [Export("textColor", ArgumentSemantic.Assign)]
        UIColor TextColor { get; set; }

        // @property (nonatomic) NSFormatter * _Nonnull textFormat;
        [Export("textFormat", ArgumentSemantic.Assign)]
        NSFormatter TextFormat { get; set; }

        // @property (nonatomic) double maximum;
        [Export("maximum")]
        double Maximum { get; set; }

        // @property (nonatomic) double minimum;
        [Export("minimum")]
        double Minimum { get; set; }

        // @property (nonatomic) SCIOrientation orientation;
        [Export("orientation", ArgumentSemantic.Assign)]
        SCIOrientation Orientation { get; set; }

        // @property (nonatomic) SCITextureOpenGL * _Nullable colourMap;
        [NullAllowed, Export("colourMap", ArgumentSemantic.Assign)]
        SCITextureOpenGL ColourMap { get; set; }
    }
}