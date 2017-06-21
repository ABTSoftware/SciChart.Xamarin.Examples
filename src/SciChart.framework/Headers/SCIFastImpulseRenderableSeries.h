//
//  SCIFastImpulseRenderableSeries.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 9/15/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"
#import "SCIThemeableProtocol.h"

@class SCIImpulseSeriesStyle;

@interface SCIFastImpulseRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>

/**
 * @brief The SCIFastImpulseRenderableSeries class' property.
 * @discussion Gets or sets the SCIFastImpulseRenderableSeries Style property.
 */
@property(nonatomic, copy) SCIImpulseSeriesStyle *style;

/**
 * @brief The SCIFastImpulseRenderableSeries class' property.
 * @discussion Gets or sets the SCIFastImpulseRenderableSeries Selected style property.
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCIImpulseSeriesStyle *selectedStyle;

@end

/** @}*/