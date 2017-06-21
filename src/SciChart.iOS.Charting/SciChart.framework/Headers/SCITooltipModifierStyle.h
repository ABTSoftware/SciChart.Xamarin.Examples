//
//  SCITooltipModifierStyle.h
//  SciChart
//
//  Created by Admin on 15.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "SCITooltipModifierStyleBase.h"

/**
 * @brief SCITooltipModifierStyle class.
 * @discussion Provides properties for styling the text and appearence of the TooltipMidifier.
 * @see SCITooltipModifierStyleProtocol
 * @see SCITooltipModifier
 * @see SCIStyleProtocol
 */
@interface SCITooltipModifierStyle : NSObject <SCITooltipModifierStyleProtocol>

/**
 * Changes appearance of targetMarker on the SCITooltipModifier.
 * <p>You can change style of point marker. Ensure that instance implements SCIPointMarker protocol!</p>
 * @code
 * let marker = SCIEllipsePointMarker()
 * marker.drawBorder = false
 * marker.fillBrush = SCIBrushSolid(color: UIColor.redColor())
 * tooltipModifier.style.targetMarker = marker
 * @endcode
 * @see SCIPointMarkerProtocol
 */
@property (nonatomic, strong) id<SCIPointMarkerProtocol> targetMarker;

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

@end


/** @}*/
