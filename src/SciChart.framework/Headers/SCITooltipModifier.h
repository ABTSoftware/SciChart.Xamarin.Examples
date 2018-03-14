//
//  SCITooltipModifier.h
//  SciChart
//
//  Created by Admin on 08.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"
#import "SCIHitTestProvider.h"
#import "SCIThemeableProtocol.h"

@class SCITooltipModifierStyle;

/**
 @brief The SCITooltipModifier class.
 @discussion Provides a touch tooltip to a chart, outputting a single SeriesIfo.
 */
@interface SCITooltipModifier : SCIGestureModifier <SCIThemeableProtocol>

/**
 @brief The SCITooltipModifier class' property.
 @discussion Gets or sets the ToolTip Style property.
 */
@property (nonatomic, copy) SCITooltipModifierStyle * style;

/**
 @brief The SCITooltipModifier class' property.
 @discussion A radius used in the method for interpolation.
 */
@property (nonatomic) double hitTestRadius;

-(SCIHitTestInfo) hitTestWithProvider:(__unsafe_unretained id<SCIHitTestProviderProtocol>)provider
                            Location:(CGPoint)location Radius:(double)radius
                              onData:(id<SCIRenderPassDataProtocol>)data
                         hitTestMode:(SCIHitTestMode) hitTestMode;

@end

/** @}*/
