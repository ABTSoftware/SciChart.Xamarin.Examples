using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITooltipModifierStyle : NSObject <SCITooltipModifierStyleProtocol>
    [BaseType(typeof(NSObject))]
    interface SCITooltipModifierStyle : SCITooltipModifierStyleProtocol
    {
        // @property (nonatomic, strong) id<SCIPointMarkerProtocol> targetMarker;
        [Export("targetMarker", ArgumentSemantic.Strong)]
        ISCIPointMarkerProtocol TargetMarker { get; set; }

        // @property (nonatomic) float alignmentMargin;
        [Export("alignmentMargin")]
        float AlignmentMargin { get; set; }

        // @property (nonatomic) SCITooltipTargetOffsetMode targetOffsetMode;
        [Export("targetOffsetMode", ArgumentSemantic.Assign)]
        SCITooltipTargetOffsetMode TargetOffsetMode { get; set; }

        // @property (nonatomic) float targetOffsetValue;
        [Export("targetOffsetValue")]
        float TargetOffsetValue { get; set; }

        // @property (nonatomic) CGPoint targetCustomOffset;
        [Export("targetCustomOffset", ArgumentSemantic.Assign)]
        CGPoint TargetCustomOffset { get; set; }

        // @property (nonatomic) SCITooltipColorMode colorMode;
        [Export("colorMode", ArgumentSemantic.Assign)]
        SCITooltipColorMode ColorMode { get; set; }

        // @property (nonatomic) NSNumberFormatter * numberFormatter;
        [Export("numberFormatter", ArgumentSemantic.Assign)]
        NSNumberFormatter NumberFormatter { get; set; }

        // @property (nonatomic) NSDateFormatter * dateTimeFormatter;
        [Export("dateTimeFormatter", ArgumentSemantic.Assign)]
        NSDateFormatter DateTimeFormatter { get; set; }
    }
}