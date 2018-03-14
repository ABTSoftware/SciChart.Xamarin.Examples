//
//  FastCandlestickRenderableSeries.h
//  SciChart
//
//  Created by Admin on 24.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"
#import "SCIThemeableProtocol.h"

@class SCICandlestickSeriesStyle;
@protocol SCICandleStickRenderableSeriesAnimationProtocol;

/**
 @brief The SCIFastCandlestickRenderableSeries class.
 @discussion Provides Candlestick series rendering where each data point displayed as candle with rectangular body and line from min to max value.
 @discussion Candlestick series has two color schemes for Up and Down mode. If open value is higher than close, data point is drawn in Down mode, else in Up mode
 @remark Designed to work with SCIOhlcDataSeries as data container
 @remark For styling provide or customize SCICandlestickSeriesStyle
 @see SCIRenderableSeriesProtocol
 @see SCIRenderableSeriesBase
 @see SCIOhlcDataSeries
 @see SCICandlestickSeriesStyle
 */
@interface SCIFastCandlestickRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>

/**
 * @brief Get or set style for visual customization
 * @see SCICandlestickSeriesStyle
 */
@property(nonatomic, copy) SCICandlestickSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCICandlestickSeriesStyle *selectedStyle;

@property(nonatomic) SCIPenStyle *strokeUpStyle;

@property(nonatomic) SCIPenStyle *strokeDownStyle;

/**
 * @brief defines body fill for chart Up mode (open < close)
 * @code
 * rSeries.upBodyBrush = SCIBrushSolid(colorCode: 0xFF00FF00)
 * @encode
 * @see SCIBrushStyle
 */
@property(nonatomic, strong) SCIBrushStyle *fillUpBrushStyle;

/**
 * @brief defines body fill for chart Down mode (open > close)
 * @code
 * rSeries.downBodyBrush = SCIBrushSolid(colorCode: 0xFF0000FF)
 * @encode
 * @see SCIBrushStyle
 */
@property(nonatomic, strong) SCIBrushStyle *fillDownBrushStyle;

@property(nonatomic) double dataPointWidth;

/**
 Make the series animatable. After adding animation and then change data series of the renderable series make new data appear with animation.
 It is not thread safe method. It should be called only from main thread.
 @code
 renderableSeries.addAnimation(SCIScaleRenderableSeriesAnimation(duration: 5, curveAnimation: SCIAnimationCurveEaseOut))
 renderableSeries.dataSeries = newDataSeries
 @endcode
 @param animation some base animation object which implements SCICandleStickRenderableSeriesAnimationProtocol.
 */
- (void)addAnimation:(id<SCICandleStickRenderableSeriesAnimationProtocol>)animation;

@end

/** @}*/
