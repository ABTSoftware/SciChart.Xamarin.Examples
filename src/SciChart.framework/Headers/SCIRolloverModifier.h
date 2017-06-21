//
//  SCIRolloverModiifer.h
//  SciChart
//
//  Created by Admin on 14.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"
#import "SCIHitTestProvider.h"
#import "SCIThemeableProtocol.h"

@class SCIRolloverModifierStyle;

/**
 @brief The SCIRolloverModifier class.
 @discussion Provides a touch gesture hit-test to a chart.
 */
@interface SCIRolloverModifier : SCIGestureModifier <SCIThemeableProtocol>

/**
 @brief The SCIRolloverModifier class' property.
 @discussion Gets or sets the RolloverModifier Style property.
 */
@property (nonatomic, copy) SCIRolloverModifierStyle * style;

/**
 @brief The SCIRolloverModifier class' property.
 @discussion A radius used in the method for interpolation.
 */
@property (nonatomic) double hitTestRadius;


-(SCIHitTestInfo) hitTestWithProvider:(__unsafe_unretained id<SCIHitTestProviderProtocol>)provider
                            Location:(CGPoint)location Radius:(double)radius
                              onData:(id<SCIRenderPassDataProtocol>)data
                         hitTestMode:(SCIHitTestMode) hitTestMode;

@end

/** @}*/

