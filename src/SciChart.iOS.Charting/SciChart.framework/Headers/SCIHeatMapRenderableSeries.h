//
//  HeatMapRenderableSeries.h
//  SciChart
//
//  Created by Admin on 04.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"

@class SCIHeatMapSeriesStyle;

/**
 @brief The SCIHeatMapRenderableSeries class.
 @discussion Displays 2D data as a heatmap
 @remark Designed to work with SCIHeatMapDataSeries as data container
 @remark For styling provide or customize SCIHeatMapSeriesStyle
 @see SCIRenderableSeriesProtocol
 @see SCIRenderableSeriesBase
 @see SCIHeatMapDataSeries
 @see SCIHeatMapSeriesStyle
 */
@interface SCIHeatMapRenderableSeries : SCIRenderableSeriesBase

/**
 @brief Get or set style for visual customization
 @see SCIHeatMapSeriesStyle
 */
@property (nonatomic, copy) SCIHeatMapSeriesStyle * style;

/**
 @brief Gets or sets selected series style
 @discussion If set to nil selected style is default series style
 */
@property (nonatomic, copy) SCIHeatMapSeriesStyle * selectedStyle;

@end

/** @}*/
