//
//  SCIModifierStyleBase.h
//  SciChart
//
//  Created by Yaroslav Pelyukh on 7/17/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import <UIKit/UIKit.h>
#import "SCIHitTestProvider.h"
#import "SCIStyleProtocol.h"

@class SCITextFormattingStyle;
@protocol SCIPointMarkerProtocol;

@class SCITooltipView;

/**
 * @abstract block which is used for additional tooltip view setup
 * @discussion this block will be called after all other style options applied
 * @param view SCITooltipView which displays modifier data
 */
typedef void (^SCITooltipViewSetupBlock) (SCITooltipView * view);

/**
 * @typedef SCITooltipTargetOffsetMode
 * @abstract Enum of hit test point offset modes
 * @discussion Possible values:
 * @discussion - SCITooltipTargetOffset_None hit test point will be directly at touch location
 * @discussion - SCITooltipTargetOffset_Up hit test point will be above touch location
 * @discussion - SCITooltipTargetOffset_Down hit test point will be below touch location
 * @discussion - SCITooltipTargetOffset_Left hit test point will be to the left from touch location
 * @discussion - SCITooltipTargetOffset_Right hit test point will be to the right from touch location
 * @discussion - SCITooltipTargetOffset_UpLeft hit test point will be to the up-left from touch location
 * @discussion - SCITooltipTargetOffset_UpRight hit test point will be to the up-right from touch location
 * @discussion - SCITooltipTargetOffset_DownLeft hit test point will be to the down-left from touch location
 * @discussion - SCITooltipTargetOffset_DownRight hit test point will be to the down-right from touch location
 */
typedef NS_ENUM(NSUInteger, SCITooltipTargetOffsetMode) {
    /** hit test point will be directly at touch location */
    SCITooltipTargetOffset_None,
    /** hit test point will be above touch location */
    SCITooltipTargetOffset_Up,
    /** hit test point will be below touch location */
    SCITooltipTargetOffset_Down,
    /** hit test point will be to the left from touch location */
    SCITooltipTargetOffset_Left,
    /** hit test point will be to the right from touch location */
    SCITooltipTargetOffset_Right,
    /** hit test point will be to the up-left from touch location */
    SCITooltipTargetOffset_UpLeft,
    /** hit test point will be to the up-right from touch location */
    SCITooltipTargetOffset_UpRight,
    /** hit test point will be to the down-left from touch location */
    SCITooltipTargetOffset_DownLeft,
    /** hit test point will be to the down-right from touch location */
    SCITooltipTargetOffset_DownRight
};

/**
 * @typedef SCITooltipViewAlignmentMode
 * @abstract Enum of tooltip view alignment modes.
 * @discussion View is aligned related to hit test point
 * @discussion Possible values:
 * @discussion - SCITooltipViewAlignment_TopRight view will be displayed to up-right from hit test point
 * @discussion - SCITooltipViewAlignment_TopLeft view will be displayed to up-left from hit test point
 * @discussion - SCITooltipViewAlignment_BottomRight view will be displayed to down-right from hit test point
 * @discussion - SCITooltipViewAlignment_BottomLeft view will be displayed to down-left from hit test point
 */
typedef NS_ENUM(NSUInteger, SCITooltipViewAlignmentMode) {
    /** view will be displayed to up-right from hit test point */
    SCITooltipViewAlignment_TopRight,
    /** view will be displayed to up-left from hit test point */
    SCITooltipViewAlignment_TopLeft,
    /** view will be displayed to down-right from hit test point */
    SCITooltipViewAlignment_BottomRight,
    /** view will be displayed to down-left from hit test point */
    SCITooltipViewAlignment_BottomLeft,
};

/**
 * @typedef SCITooltipColorMode
 * @abstract Enum of tooltip view coloring modes.
 * @discussion Possible values:
 * @discussion - SCITooltipColorMode_Default view color will be defined by other color properties in style
 * @discussion - SCITooltipColorMode_SeriesColor view background will be colored according to renderable series color
 * @discussion - SCITooltipColorMode_SeriesColorToDataView renderable series color will be passed to data views, and by default applied to data series name text
 */
typedef NS_ENUM(NSUInteger, SCITooltipColorMode) {
    /** view color will be defined by other color properties in style */
    SCITooltipColorMode_Default,
    /** view background will be colored according to renderable series color */
    SCITooltipColorMode_SeriesColor,
    /** renderable series color will be passed to data views, and by default applied to data series name text */
    SCITooltipColorMode_SeriesColorToDataView
};

/**
 * @brief SCITooltipModifierStyleBase protocol
 * @discussion Provides common properties for styling tooltip modifiers
 @extends SCIStyleProtocol
 @extends NSCopying
 */
@protocol SCITooltipModifierStyleProtocol ///
<SCIStyleProtocol, NSCopying>
/** @{ @} */

/**
 * Changes style of head text in toolTipView.
 * Head text by default displays data series name
 * @see SCITextFormattingStyle
 */
@property (nonatomic, copy) SCITextFormattingStyle * headLineStyle;
/**
 * Changes style of data text in toolTipView.
 * @discussion By default data text is hit test results
 * @see SCITextFormattingStyle
 */
@property (nonatomic, copy) SCITextFormattingStyle * dataStyle;
/**
 * Changes number formatter for values. Default is nil.
 */
@property (nonatomic) NSNumberFormatter *numberFormatter;

/**
 * Changes date formatter for values. Default is nil.
 */
@property (nonatomic) NSDateFormatter *dateTimeFormatter;

/**
 * @abstract This block is used for additional customization of toltip view
 * @discussion Type: typedef void (^SCITooltipViewSetupBlock) (SCITooltipView * view);
 * @see SCITooltipViewSetupBlock
 */
@property (nonatomic, copy) SCITooltipViewSetupBlock tooltipViewSetup;
/**
 * Changes limit of size of toolTipView.
 * @discussion Default is CGSizeMake(NaN, NaN) which means size is unlimited and will be based on content
 */
@property (nonatomic) CGSize tooltipSize;
/**
 * Defines distance in pixels from tooltip view border to internal content view (in fact distance from border to text inside tooltip view)
 */
@property (nonatomic) float contentPadding;
/**
 * Changes aligment mode of toolTipView.
 * @discussion Tooltip alignment defines where tooltip view will be placed relative to hit test point
 * @see SCITooltipViewAlignmentMode
 */
@property (nonatomic) SCITooltipViewAlignmentMode tooltipAlignment;
/**
 * Changes distance between targetMarker and toolTipView. Default is 5.0.
 */
@property (nonatomic) float alignmentMargin; // TODO: rename to tooltipAlignmentPadding

/**
 * Changes colour mode of hit test. Default is SCITooltipColorMode_SeriesColorToDataView.
 * @see SCITooltipColorMode
 */
@property (nonatomic) SCITooltipColorMode colorMode; // TODO: rename to tooltipViewColorMode
/**
 * Changes background colour of toolTipView. Default is darkGrayColor.
 * @discussion If property colorMode = SCITooltipColorMode_SeriesColor this color will be ovewtitten by series color
 * @see SCITooltipColorMode
 */
@property (nonatomic, strong) UIColor * tooltipColor;
/**
 * Changes border colour of toolTipView. Default is lightGrayColor.
 * @discussion If property colorMode = SCITooltipColorMode_SeriesColor this color will be ovewtitten by series color
 * @see SCITooltipColorMode
 */
@property (nonatomic, strong) UIColor * tooltipBorderColor;
/**
 * Changes border width of toolTipView. Default is 2.0f.
 */
@property (nonatomic) float tooltipBorderWidth;
/**
 * Changes corner radius of toolTipView. Default is 0.0f.
 */
@property (nonatomic) float tooltipCornerRadius;
/**
 * Changes opacity of toolTipView. Default is 0.7f.
 */
@property (nonatomic) float tooltipOpacity;

/**
 * Changes shadow offset of toolTipView. Default is CGSizeMake(-5, 10).
 */
@property (nonatomic) CGSize tooltipShadowOffset;
/**
 * Changes shadow radius of toolTipView. Default is 3.0f.
 */
@property (nonatomic) float tooltipShadowRadius;
/**
 * Changes shadow opacity of toolTipView. Default is 0.7f.
 */
@property (nonatomic) float tooltipShadowOpacity;

/**
 * Changes mode of hitTest. Default is SCIHitTest_Default.
 * With this property you can make tooltip to make hit test on all series at specific X coordinate or at specific point, with interpolation or without
 * @see SCIHitTestMode
 */
@property (nonatomic) SCIHitTestMode hitTestMode;

/**
 * Defines is modifier tooltip is visible. Default is true
 */
@property (nonatomic) bool showTooltip;

@end

/** @}*/
