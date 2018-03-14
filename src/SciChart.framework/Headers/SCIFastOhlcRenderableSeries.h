//
//  FastOhlcRenderableSeries.h
//  SciChart
//
//  Created by Admin on 25.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"
#import "SCIThemeableProtocol.h"
#import "SCIOhlcRenderableSeriesAnimationProtocol.h"

@class SCIOhlcSeriesStyle;

/**
 * @brief The SCIFastOhlcRenderableSeries class.
 * @discussion Provides Open-High-Low-Close series rendering where each data point displayed as vertical line from high to low value with marks at open and close values.
 * @discussion OHLC series has two color schemes for Up and Down mode. If open value is higher than close, data point is drawn in Down mode, else in Up mode
 * @remark Designed to work with SCIOhlcDataSeries as data container
 * @remark For styling provide or customize SCIOhlcSeriesStyle
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIOhlcDataSeries
 * @see SCIOhlcSeriesStyle
 */
@interface SCIFastOhlcRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>

/**
 * @brief Get or set style for visual customization
 * @see SCIOhlcSeriesStyle
 */
@property(nonatomic, copy) SCIOhlcSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCIOhlcSeriesStyle *selectedStyle;

@property(nonatomic) SCIPenStyle *strokeUpStyle;

@property(nonatomic) SCIPenStyle *strokeDownStyle;

@property(nonatomic) double dataPointWidth;

/**
 Make the series animatable. After adding animation and then change data series of the renderable series make new data appear with animation.
 It is not thread safe method. It should be called only from main thread.
 @code
 renderableSeries.addAnimation(SCIScaleRenderableSeriesAnimation(duration: 5, curveAnimation: SCIAnimationCurveEaseOut))
 renderableSeries.dataSeries = newDataSeries
 @endcode
 @param animation some base animation object which implements SCIOhlcRenderableSeriesAnimationProtocol.
 */
- (void)addAnimation:(id<SCIOhlcRenderableSeriesAnimationProtocol>)animation;

@end

/** @}*/
