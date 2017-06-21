//
//  FastLineRenderableSeries.h
//  SciChart
//
//  Created by Admin on 28.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"
#import "SCIThemeableProtocol.h"

@class SCILineSeriesStyle;

/**
 * @brief The SCIFastLineRenderableSeries class.
 * @discussion This renderable series displays line connecting all data points and as option point markers at data points coordinates
 * @remark Designed to work with SCIXyDataSeries as data container
 * @remark For styling provide or customize SCILineSeriesStyle
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIXyDataSeries
 * @see SCILineSeriesStyle
 */
@interface SCIFastLineRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>

/**
 * @brief Get or set style for visual customization
 * @see SCILineSeriesStyle
 */
@property(nonatomic, copy) SCILineSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCILineSeriesStyle *selectedStyle;

@property(nonatomic) BOOL isDigitalLine;

@end

/** @}*/