using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisStyle : NSObject <ISCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCIAxisStyle : SCIStyleProtocol, INSCopying
    {
        // @property (nonatomic) BOOL drawMinorTicks;
        [Export("drawMinorTicks")]
        bool DrawMinorTicks { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> minorTickBrush;
        [Export("minorTickBrush", ArgumentSemantic.Strong)]
        SCIPenStyle MinorTickBrush { get; set; }

        // @property (nonatomic) float minorTickSize;
        [Export("minorTickSize")]
        float MinorTickSize { get; set; }

        // @property (nonatomic) BOOL drawMajorTicks;
        [Export("drawMajorTicks")]
        bool DrawMajorTicks { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> majorTickBrush;
        [Export("majorTickBrush", ArgumentSemantic.Strong)]
        SCIPenStyle MajorTickBrush { get; set; }

        // @property (nonatomic) float majorTickSize;
        [Export("majorTickSize")]
        float MajorTickSize { get; set; }

        // @property (nonatomic) BOOL drawMinorGridLines;
        [Export("drawMinorGridLines")]
        bool DrawMinorGridLines { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> minorGridLineBrush;
        [Export("minorGridLineBrush", ArgumentSemantic.Strong)]
        SCIPenStyle MinorGridLineBrush { get; set; }

        // @property (nonatomic) BOOL drawMajorGridLines;
        [Export("drawMajorGridLines")]
        bool DrawMajorGridLines { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> majorGridLineBrush;
        [Export("majorGridLineBrush", ArgumentSemantic.Strong)]
        SCIPenStyle MajorGridLineBrush { get; set; }

        // @property (nonatomic) BOOL drawMajorBands;
        [Export("drawMajorBands")]
        bool DrawMajorBands { get; set; }

        // @property (nonatomic, strong) id<SCIBrush2DProtocol> gridBandBrush;
        [Export("gridBandBrush", ArgumentSemantic.Strong)]
        SCIBrushStyle GridBandBrush { get; set; }

        // @property (nonatomic) BOOL drawLabels;
        [Export("drawLabels")]
        bool DrawLabels { get; set; }

        // @property (nonatomic, strong) SCITextFormattingStyle * labelStyle;
        [Export("labelStyle", ArgumentSemantic.Strong)]
        SCITextFormattingStyle LabelStyle { get; set; }

        // @property (nonatomic, strong) SCITextFormattingStyle * axisTitleLabelStyle;
        [Export("axisTitleLabelStyle", ArgumentSemantic.Strong)]
        SCITextFormattingStyle AxisTitleLabelStyle { get; set; }

        // @property (nonatomic) SCIAxisLabelClippingMode labelClipping;
        [Export("labelClipping", ArgumentSemantic.Assign)]
        SCIAxisLabelClippingMode LabelClipping { get; set; }

        // @property (nonatomic) BOOL moveLabelsToClippingArea;
        [Export("moveLabelsToClippingArea")]
        bool MoveLabelsToClippingArea { get; set; }

        // @property (nonatomic) float labelSpacing;
        [Export("labelSpacing")]
        float LabelSpacing { get; set; }

        // @property (nonatomic) float recommendedSize;
        [Export("recommendedSize")]
        float RecommendedSize { get; set; }
    }
}