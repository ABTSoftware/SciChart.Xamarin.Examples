//
//  SCISelectionModifier.h
//  SciChart
//
//  Created by Admin on 03/01/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"
#import "SCIHitTestProvider.h"

typedef NS_ENUM(NSUInteger, SCISelectionModifierSelectionMode) {
    SCISelectionModifierSelectionMode_SingleSelectDeselectOnMiss,
    SCISelectionModifierSelectionMode_SingleSelectDeselectOnDoubleTap,
    SCISelectionModifierSelectionMode_MultiSelectDeselectOnMiss,
    SCISelectionModifierSelectionMode_MultiSelectDeselectOnDoubleTap
};

@interface SCISeriesSelectionModifier : SCIGestureModifier

@property (nonatomic) SCISelectionModifierSelectionMode selectionMode;
@property (nonatomic) SCIHitTestMode hitTestMode;
@property (nonatomic) double hitTestRadius;

@end

/** @}*/
