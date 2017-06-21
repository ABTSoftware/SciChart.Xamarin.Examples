//
//  SCIBaseColumnRenderableSeries.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 5/4/17.
//  Copyright © 2017 SciChart. All rights reserved.
//


/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"
#import "SCIThemeableProtocol.h"

@class SCIColumnSeriesStyle;
@class SCIBrushStyle;

@interface SCIBaseColumnRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>

/**
 * @brief Get or set style for visual customization
 * @see SCIColumnSeriesStyle
 */
@property(nonatomic, copy) SCIColumnSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCIColumnSeriesStyle *selectedStyle;

@property(nonatomic) SCIBrushStyle *fillBrushStyle;

@property(nonatomic) double dataPointWidth;

@end
/** @}*/
