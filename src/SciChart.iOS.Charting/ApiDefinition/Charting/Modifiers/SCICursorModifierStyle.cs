using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCICursorModifierStyle : NSObject <SCITooltipModifierStyleProtocol>
    [BaseType(typeof(NSObject))]
    interface SCICursorModifierStyle : SCITooltipModifierStyleProtocol
    {
        // @property (copy, nonatomic) SCITextFormattingStyle * axisHorizontalTextStyle;
        [Export("axisHorizontalTextStyle", ArgumentSemantic.Copy)]
        SCITextFormattingStyle AxisHorizontalTextStyle { get; set; }

        // @property (copy, nonatomic) SCITextFormattingStyle * axisVerticalTextStyle;
        [Export("axisVerticalTextStyle", ArgumentSemantic.Copy)]
        SCITextFormattingStyle AxisVerticalTextStyle { get; set; }

        // @property (copy, nonatomic) SCITooltipViewSetupBlock axisHorizontalTooltipSetup;
        [Export("axisHorizontalTooltipSetup", ArgumentSemantic.Copy)]
        SCITooltipViewSetupBlock AxisHorizontalTooltipSetup { get; set; }

        // @property (copy, nonatomic) SCITooltipViewSetupBlock axisVerticalTooltipSetup;
        [Export("axisVerticalTooltipSetup", ArgumentSemantic.Copy)]
        SCITooltipViewSetupBlock AxisVerticalTooltipSetup { get; set; }

        // @property (nonatomic) float alignmentMargin;
        [Export("alignmentMargin")]
        float AlignmentMargin { get; set; }

        // @property (nonatomic) SCITooltipColorMode colorMode;
        [Export("colorMode", ArgumentSemantic.Assign)]
        SCITooltipColorMode ColorMode { get; set; }

        // @property (nonatomic, strong) id<SCIPen2DProtocol> cursorPen;
        [Export("cursorPen", ArgumentSemantic.Strong)]
        SCIPenStyle CursorPen { get; set; }

        // @property (nonatomic) SCITooltipTargetOffsetMode targetOffsetMode;
        [Export("targetOffsetMode", ArgumentSemantic.Assign)]
        SCITooltipTargetOffsetMode TargetOffsetMode { get; set; }

        // @property (nonatomic) float targetOffsetValue;
        [Export("targetOffsetValue")]
        float TargetOffsetValue { get; set; }

        // @property (nonatomic) CGPoint targetCustomOffset;
        [Export("targetCustomOffset", ArgumentSemantic.Assign)]
        CGPoint TargetCustomOffset { get; set; }

        // @property (nonatomic, strong) UIColor * axisHorizontalTooltipColor;
        [Export("axisHorizontalTooltipColor", ArgumentSemantic.Strong)]
        UIColor AxisHorizontalTooltipColor { get; set; }

        // @property (nonatomic, strong) UIColor * axisHorizontalTooltipBorderColor;
        [Export("axisHorizontalTooltipBorderColor", ArgumentSemantic.Strong)]
        UIColor AxisHorizontalTooltipBorderColor { get; set; }

        // @property (nonatomic) float axisHorizontalTooltipBorderWidth;
        [Export("axisHorizontalTooltipBorderWidth")]
        float AxisHorizontalTooltipBorderWidth { get; set; }

        // @property (nonatomic) float axisHorizontalTooltipCornerRadius;
        [Export("axisHorizontalTooltipCornerRadius")]
        float AxisHorizontalTooltipCornerRadius { get; set; }

        // @property (nonatomic, strong) UIColor * axisVerticalTooltipColor;
        [Export("axisVerticalTooltipColor", ArgumentSemantic.Strong)]
        UIColor AxisVerticalTooltipColor { get; set; }

        // @property (nonatomic, strong) UIColor * axisVerticalTooltipBorderColor;
        [Export("axisVerticalTooltipBorderColor", ArgumentSemantic.Strong)]
        UIColor AxisVerticalTooltipBorderColor { get; set; }

        // @property (nonatomic) float axisVerticalTooltipBorderWidth;
        [Export("axisVerticalTooltipBorderWidth")]
        float AxisVerticalTooltipBorderWidth { get; set; }

        // @property (nonatomic) float axisVerticalTooltipCornerRadius;
        [Export("axisVerticalTooltipCornerRadius")]
        float AxisVerticalTooltipCornerRadius { get; set; }

        // @property (nonatomic) float axisHorizontalTooltipOpacity;
        [Export("axisHorizontalTooltipOpacity")]
        float AxisHorizontalTooltipOpacity { get; set; }

        // @property (nonatomic) float axisVerticalTooltipOpacity;
        [Export("axisVerticalTooltipOpacity")]
        float AxisVerticalTooltipOpacity { get; set; }

        // @property (nonatomic) NSNumberFormatter * numberFormatter;
        [Export("numberFormatter", ArgumentSemantic.Assign)]
        NSNumberFormatter NumberFormatter { get; set; }

        // @property (nonatomic) NSDateFormatter * dateTimeFormatter;
        [Export("dateTimeFormatter", ArgumentSemantic.Assign)]
        NSDateFormatter DateTimeFormatter { get; set; }
    }
}