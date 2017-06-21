//
//  SCIRolloverModifierStyle.h
//  SciChart
//
//  Created by Admin on 17.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCITooltipModifierStyleBase.h"

@class SCIPenStyle;

/**
 * @brief SCIRolloverModifierStyle class
 * @discussion Provides properties for styling the text and appearence of the rollover modifier
 * @see SCIRolloverModifier
 * @see SCITooltipModifierStyleProtocol
 * @see SCIStyle
 */
@interface SCIRolloverModifierStyle : NSObject <SCITooltipModifierStyleProtocol>

/**
 * Changes style of text for axis tooltip
 * @see SCITextFormattingStyle
 */
@property (nonatomic, copy) SCITextFormattingStyle * axisTextStyle;
/**
 * @abstract This block is used for additional customization of axis toltip view
 * @discussion Type: typedef void (^SCITooltipViewSetupBlock) (SCITooltipView * view);
 * @see SCITooltipViewSetupBlock
 */
@property (nonatomic, copy) SCITooltipViewSetupBlock axisTooltipSetup;

/**
 * Changes line color and width for rollover cursor line
 * @code
 * style.rolloverPen = SCIPenSolid(colorCode: 0xFF00A0FF, width: 1)
 * @encode
 * @see SCIPen2DProtocol
 */
@property (nonatomic, strong) SCIPenStyle *rolloverPen;

/**
 * Changes appearance of point markers on renderable series
 * <p>You can change style of point marker. Ensure that instance implements SCIPointMarker protocol!</p>
 * @code
 * let marker = SCIEllipsePointMarker()
 * marker.drawBorder = false
 * marker.fillBrush = SCIBrushSolid(color: UIColor.redColor())
 * modifier.style.pointMarker = marker
 * @endcode
 * @see SCIPointMarkerProtocol
 */
@property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker;

/**
 * if set to true, color from renderable series will be passed to point marker fill color
 */
@property (nonatomic) BOOL useSeriesColorForMarker;

/**
 * Changes background colour of axis toolTipView. Default is orange.
 */
@property (nonatomic, strong) UIColor * axisTooltipColor;
/**
 * Changes border colour of axis toolTipView. Default is orrange.
 */
@property (nonatomic, strong) UIColor * axisTooltipBorderColor;
/**
 * Changes border width of axis toolTipView. Default is 0.0f.
 */
@property (nonatomic) float axisTooltipBorderWidth;
/**
 * Changes corner radius of axis toolTipView. Default is 5.0f.
 */
@property (nonatomic) float axisTooltipCornerRadius;
/**
 * Changes opacity of axis toolTipView. Default is 0.9f.
 */
@property (nonatomic) float axisTooltipOpacity;

/**
 * Defines is axis labels are visible. Default is true
 */
@property (nonatomic) bool showAxisLabels;

@end


/** @}*/
