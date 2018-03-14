//
//  SCIPieTooltipModifier.h
//  SciChart
//
//  Created by Admin on 25/09/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"

/** \addtogroup ChartModifiers
 *  @{
 */

@class SCITooltipModifierStyle;
@class SCITooltipView;

/**
 @brief The SCITooltipModifier class.
 @discussion Pop up view on pan gesture with information about segment
 */
@interface SCIPieTooltipModifier : SCIGestureModifier {
@protected
    SCITooltipView * _view;
    BOOL _gestureLocked;
    CGPoint _location;
}

/**
 @brief Method creates pop up view instance
 @discussion Called internally on init.
 @see SCITooltipView
 */
-(SCITooltipView*) createTooltipView;

/**
 @brief The SCITooltipModifier class' property.
 @discussion Gets or sets the ToolTip Style property.
 @see SCITooltipModifierStyle
 */
@property (nonatomic, copy) SCITooltipModifierStyle * style;

@end

/** @}*/
