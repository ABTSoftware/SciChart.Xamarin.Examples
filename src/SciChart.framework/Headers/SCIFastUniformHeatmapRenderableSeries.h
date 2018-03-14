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

@class SCIUniformHeatmapSeriesStyle;
@class SCITextureOpenGL;

/**
 * @brief The SCIFastUniformHeatmapRenderableSeries class.
 * @discussion Displays 2D data as a heatmap
 * @remark Designed to work with SCIUniformHeatmapDataSeries as data container
 * @remark For styling provide or customize SCIUniformHeatmapSeriesStyle
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIUniformHeatmapDataSeries
 * @see SCIUniformHeatmapSeriesStyle
 */
@interface SCIFastUniformHeatmapRenderableSeries : SCIRenderableSeriesBase

/**
 * @brief Get or set style for visual customization
 * @see SCIUniformHeatmapSeriesStyle
 */
@property(nonatomic, copy) SCIUniformHeatmapSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCIUniformHeatmapSeriesStyle *selectedStyle;

@property(nonatomic) double minimum;

@property(nonatomic) double maximum;

@property(nonatomic) SCITextureOpenGL *colorMap;

@end

/** @}*/