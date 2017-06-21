//
//  SCICursorModifier.h
//  SciChart
//
//  Created by Admin on 07.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"
#import "SCIHitTestProvider.h"
#import "SCIThemeableProtocol.h"

@class SCICursorModifierStyle;

/**
 @brief The SCICursorModifier class.
 @discussion Provides a cross-hairs (curosr) plus tooltip with X,Y data values under the touch gestures.
 */
@interface SCICursorModifier : SCIGestureModifier <SCIThemeableProtocol>

/**
 @brief The SCICursorModifier class' property.
 @discussion Gets or sets the CursorModifier Style property.
 */
@property (nonatomic, copy) SCICursorModifierStyle * style;

/**
 @brief The SCICursorModifier class' property.
 @discussion A radius used in the method for interpolation.
 */
@property (nonatomic) double hitTestRadius;

-(SCIHitTestInfo) hitTestWithProvider:(__unsafe_unretained id<SCIHitTestProviderProtocol>)provider
                            Location:(CGPoint)location Radius:(double)radius
                              onData:(id<SCIRenderPassDataProtocol>)data
                         hitTestMode:(SCIHitTestMode) hitTestMode;

@end

/** @}*/
