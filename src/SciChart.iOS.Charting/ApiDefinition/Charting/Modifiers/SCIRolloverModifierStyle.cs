using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIRolloverModifierStyle : NSObject <SCITooltipModifierStyleProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIRolloverModifierStyle : SCITooltipModifierStyleProtocol
    {
        // @property (copy, nonatomic) SCITextFormattingStyle * axisTextStyle;
        [Export("axisTextStyle", ArgumentSemantic.Copy)]
        SCITextFormattingStyle AxisTextStyle { get; set; }

        // @property (copy, nonatomic) SCITooltipViewSetupBlock axisTooltipSetup;
        [Export("axisTooltipSetup", ArgumentSemantic.Copy)]
        SCITooltipViewSetupBlock AxisTooltipSetup { get; set; }

        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker;
        [Export("pointMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol PointMarker { get; set; }

        // @property (nonatomic) float alignmentMargin;
        [Export("alignmentMargin")]
        float AlignmentMargin { get; set; }

        // @property (nonatomic) SCITooltipColorMode colorMode;
        [Export("colorMode", ArgumentSemantic.Assign)]
        SCITooltipColorMode ColorMode { get; set; }

        // @property (nonatomic, strong) UIColor * axisTooltipColor;
        [Export("axisTooltipColor", ArgumentSemantic.Strong)]
        UIColor AxisTooltipColor { get; set; }

        // @property (nonatomic, strong) UIColor * axisTooltipBorderColor;
        [Export("axisTooltipBorderColor", ArgumentSemantic.Strong)]
        UIColor AxisTooltipBorderColor { get; set; }

        // @property (nonatomic) float axisTooltipBorderWidth;
        [Export("axisTooltipBorderWidth")]
        float AxisTooltipBorderWidth { get; set; }

        // @property (nonatomic) float axisTooltipCornerRadius;
        [Export("axisTooltipCornerRadius")]
        float AxisTooltipCornerRadius { get; set; }

        // @property (nonatomic) float axisTooltipOpacity;
        [Export("axisTooltipOpacity")]
        float AxisTooltipOpacity { get; set; }

        // @property (nonatomic) BOOL useSeriesColorForMarker;
        [Export("useSeriesColorForMarker")]
        bool UseSeriesColorForMarker { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> rolloverPen;
        [Export("rolloverPen", ArgumentSemantic.Strong)]
        SCIPenStyle RolloverPen { get; set; }

        // @property (nonatomic) NSNumberFormatter * numberFormatter;
        [Export("numberFormatter", ArgumentSemantic.Assign)]
        NSNumberFormatter NumberFormatter { get; set; }

        // @property (nonatomic) NSDateFormatter * dateTimeFormatter;
        [Export("dateTimeFormatter", ArgumentSemantic.Assign)]
        NSDateFormatter DateTimeFormatter { get; set; }
    }
}