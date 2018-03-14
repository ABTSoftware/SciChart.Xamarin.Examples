//
//  SCIPieSelectionModifier.h
//  SciChart
//
//  Created by Admin on 22/09/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"

/** \addtogroup ChartModifiers
 *  @{
 */

/**
 * @typedef SCIPieSelectionModifierSelectionMode
 * @brief Enum of SCIPieSelectionModifier selection modes
 */
typedef NS_ENUM(NSUInteger, SCIPieSelectionModifierSelectionMode) {
    /** Can be selected only one sector at time. Sector will be deselected on miss */
    SCIPieSelectionModifierSelectionMode_SingleSelectDeselectOnMiss,
    /** Can be selected only one sector at time. Sector will be deselected on double tap */
    SCIPieSelectionModifierSelectionMode_SingleSelectDeselectOnDoubleTap,
    /** Can be selected multiple sectors. Sectors will be deselected on miss */
    SCIPieSelectionModifierSelectionMode_MultiSelectDeselectOnMiss,
    /** Can be selected multiple sectors. Sectors will be deselected on double tap */
    SCIPieSelectionModifierSelectionMode_MultiSelectDeselectOnDoubleTap
};

/**
 * Selection modifier for SCIPieRenderableSeries and SCIDonutRednerableSeries
 */
@interface SCIPieSelectionModifier : SCIGestureModifier

/**
 * Changes selection mode for modifier
 * @see SCIPieSelectionModifierSelectionMode
 */
@property (nonatomic) SCIPieSelectionModifierSelectionMode selectionMode;

@end

/** @}*/
