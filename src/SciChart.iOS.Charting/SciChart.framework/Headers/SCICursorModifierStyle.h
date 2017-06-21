//
//  SCICursorModifierStyle.h
//  SciChart
//
//  Created by Admin on 07.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCITooltipModifierStyleBase.h"

@class SCIPenStyle;

/**
 * @brief SCICursorModifierStyle class
 * @discussion Provides properties for styling the text and appearence of the cursor modifier
 * @see SCICursorModifier
 * @see SCITooltipModifierStyleProtocol
 * @see SCIStyle
 */
@interface SCICursorModifierStyle : NSObject <SCITooltipModifierStyleProtocol>

/**
 * Changes line color and width for cursor
 * @code
 * style.cursorPen = SCIPenSolid(colorCode: 0xFF00A0FF, width: 1)
 * @encode
 * @see SCIPen2DProtocol
 */
@property (nonatomic, strong) SCIPenStyle *cursorPen;

/**
 * Changes style of text for horizontal axes tooltip
 * @see SCITextFormattingStyle
 */
@property (nonatomic, copy) SCITextFormattingStyle * axisHorizontalTextStyle;
/**
 * Changes style of text for vertical axes tooltip
 * @see SCITextFormattingStyle
 */
@property (nonatomic, copy) SCITextFormattingStyle * axisVerticalTextStyle;

/**
 * @abstract This block is used for additional customization of horizontal axis toltip view
 * @discussion Type: typedef void (^SCITooltipViewSetupBlock) (SCITooltipView * view);
 * @see SCITooltipViewSetupBlock
 */
@property (nonatomic, copy) SCITooltipViewSetupBlock axisHorizontalTooltipSetup;
/**
 * @abstract This block is used for additional customization of vertical axis toltip view
 * @discussion Type: typedef void (^SCITooltipViewSetupBlock) (SCITooltipView * view);
 * @see SCITooltipViewSetupBlock
 */
@property (nonatomic, copy) SCITooltipViewSetupBlock axisVerticalTooltipSetup;

/**
 * Changes target offset mode of hit test. Default is SCITooltipTargetOffset_Up.
 * By default hit test point is located above finger, you can change this bahaviour by changing this property
 * @see SCITooltipTargetOffsetMode
 */
@property (nonatomic) SCITooltipTargetOffsetMode targetOffsetMode;
/**
 * Changes target offset distance in pixels. By default it is 50.0
 * If you need to change target offset direction you can change <b>targetOffsetMode</b> property
 */
@property (nonatomic) float targetOffsetValue;
/**
 * defines starting offset of hit test point. By default it is (0;0)
 * If you need some custom offset, you can change this property and set targetOffsetMode to SCITooltipTargetOffset_None or targetOffsetValue to 0
 */
@property (nonatomic) CGPoint targetCustomOffset;

/**
 * Changes background colour of horizontal axis toolTipView. Default is orange.
 */
@property (nonatomic, strong) UIColor * axisHorizontalTooltipColor;
/**
 * Changes border colour of horizontal axis toolTipView. Default is orrange.
 */
@property (nonatomic, strong) UIColor * axisHorizontalTooltipBorderColor;
/**
 * Changes border width of horizontal axis toolTipView. Default is 0.0f.
 */
@property (nonatomic) float axisHorizontalTooltipBorderWidth;
/**
 * Changes corner radius of horizontal axis toolTipView. Default is 5.0f.
 */
@property (nonatomic) float axisHorizontalTooltipCornerRadius;

/**
 * Changes background colour of vertical axis toolTipView. Default is orange.
 */
@property (nonatomic, strong) UIColor * axisVerticalTooltipColor;
/**
 * Changes border colour of vertical axis toolTipView. Default is orange.
 */
@property (nonatomic, strong) UIColor * axisVerticalTooltipBorderColor;
/**
 * Changes corner radius of vertical axis toolTipView. Default is 0.0f.
 */
@property (nonatomic) float axisVerticalTooltipBorderWidth;
/**
 * Changes border width of vertical axis toolTipView. Default is 5.0f.
 */
@property (nonatomic) float axisVerticalTooltipCornerRadius;

/**
 * Changes opacity of vertical axis toolTipView. Default is 0.9f.
 */
@property (nonatomic) float axisHorizontalTooltipOpacity;
/**
 * Changes opacity of vertical axis toolTipView. Default is 0.9f.
 */
@property (nonatomic) float axisVerticalTooltipOpacity;

/**
 * Defines is axis labels are visible. Default is true
 */
@property (nonatomic) bool showAxisLabels;

@end


/** @}*/
