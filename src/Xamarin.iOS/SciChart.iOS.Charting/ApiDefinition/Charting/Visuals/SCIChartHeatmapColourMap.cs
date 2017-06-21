using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    public class SCIChartHeatmapColourMap
    {
        // @property(nonatomic, nonnull) UIFont* font;
        [Export("font")]
        UIFont Font { get; set; }

        // @property(nonatomic, nonnull) UIColor* textColor;
        [Export("textColor")]
        UIColor TextColor { get; set; }

        // @property(nonatomic, nonnull) NSFormatter* textFormat;
        [Export("textFormat")]
        NSFormatter TextFormat { get; set; }

        // @property(nonatomic) double maximum;
        [Export("maximum")]
        double Maximum { get; set; }

        // @property(nonatomic) double minimum;
        [Export("minimum")]
        double Minimum { get; set; }

        // @property(nonatomic) SCIOrientation orientation;
        [Export("orientation")]
        SCIOrientation Orientation { get; set; }

        // @property(nonatomic, nullable) SCITextureOpenGL* colourMap;
        [Export("colourMap")]
        SCITextureOpenGL ColourMap { get; set; }
    }
}