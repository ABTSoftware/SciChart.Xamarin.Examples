using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCITooltipModifierStyleProtocol { }

    // @protocol SCITooltipModifierStyleProtocol <SCIStyleProtocol, NSCopying>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCITooltipModifierStyleProtocol : SCIStyleProtocol, INSCopying
    {
        // @required @property (copy, nonatomic) SCITextFormattingStyle * headLineStyle;
        [Abstract]
        [Export("headLineStyle", ArgumentSemantic.Copy)]
        SCITextFormattingStyle HeadLineStyle { get; set; }

        // @required @property (copy, nonatomic) SCITextFormattingStyle * dataStyle;
        [Abstract]
        [Export("dataStyle", ArgumentSemantic.Copy)]
        SCITextFormattingStyle DataStyle { get; set; }

        // @required @property (copy, nonatomic) SCITooltipViewSetupBlock tooltipViewSetup;
        [Abstract]
        [Export("tooltipViewSetup", ArgumentSemantic.Copy)]
        SCITooltipViewSetupBlock TooltipViewSetup { get; set; }

        // @required @property (nonatomic) CGSize tooltipSize;
        [Abstract]
        [Export("tooltipSize", ArgumentSemantic.Assign)]
        CGSize TooltipSize { get; set; }

        // @required @property (nonatomic) float contentPadding;
        [Abstract]
        [Export("contentPadding")]
        float ContentPadding { get; set; }

        // @required @property (nonatomic) SCITooltipViewAlignmentMode tooltipAlignment;
        [Abstract]
        [Export("tooltipAlignment", ArgumentSemantic.Assign)]
        SCITooltipViewAlignmentMode TooltipAlignment { get; set; }

        // @required @property (nonatomic, strong) UIColor * tooltipColor;
        [Abstract]
        [Export("tooltipColor", ArgumentSemantic.Strong)]
        UIColor TooltipColor { get; set; }

        // @required @property (nonatomic, strong) UIColor * tooltipBorderColor;
        [Abstract]
        [Export("tooltipBorderColor", ArgumentSemantic.Strong)]
        UIColor TooltipBorderColor { get; set; }

        // @required @property (nonatomic) float tooltipBorderWidth;
        [Abstract]
        [Export("tooltipBorderWidth")]
        float TooltipBorderWidth { get; set; }

        // @required @property (nonatomic) float tooltipCornerRadius;
        [Abstract]
        [Export("tooltipCornerRadius")]
        float TooltipCornerRadius { get; set; }

        // @required @property (nonatomic) float tooltipOpacity;
        [Abstract]
        [Export("tooltipOpacity")]
        float TooltipOpacity { get; set; }

        // @required @property (nonatomic) CGSize tooltipShadowOffset;
        [Abstract]
        [Export("tooltipShadowOffset", ArgumentSemantic.Assign)]
        CGSize TooltipShadowOffset { get; set; }

        // @required @property (nonatomic) float tooltipShadowRadius;
        [Abstract]
        [Export("tooltipShadowRadius")]
        float TooltipShadowRadius { get; set; }

        // @required @property (nonatomic) float tooltipShadowOpacity;
        [Abstract]
        [Export("tooltipShadowOpacity")]
        float TooltipShadowOpacity { get; set; }

        // @required @property (nonatomic) int hitTestMode;
        [Abstract]
        [Export("hitTestMode")]
        int HitTestMode { get; set; }
    }
}