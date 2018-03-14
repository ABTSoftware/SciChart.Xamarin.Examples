//
//  XyScatterRenderableSeries.h
//  SciChart
//
//  Created by Admin on 27.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"

@protocol SCIPointMarkerProtocol, SCIScatterRenderableSeriesAnimationProtocol;
@class SCIScatterSeriesStyle;

/**
 * @brief The SCIXyScatterRenderableSeries class.
 * @discussion This renderable series displays data points as point markers at given cooordinates
 * @remark Designed to work with SCIXyDataSeries as data container
 * @remark For styling provide or customize SCIScatterSeriesStyle
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIXyDataSeries
 * @see SCIScatterSeriesStyle
 */
@interface SCIXyScatterRenderableSeries : SCIRenderableSeriesBase

/**
 * @brief Get or set style for visual customization
 * @see SCIScatterSeriesStyle
 */
@property(nonatomic, copy) SCIScatterSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCIScatterSeriesStyle *selectedStyle;

/**
 Make the series animatable. After adding animation and then change data series of the renderable series make new data appear with animation.
 It is not thread safe method. It should be called only from main thread.
 @code
 renderableSeries.addAnimation(SCIScaleRenderableSeriesAnimation(duration: 5, curveAnimation: SCIAnimationCurveEaseOut))
 renderableSeries.dataSeries = newDataSeries
 @endcode
 @param animation some base animation object which implements SCIScatterRenderableSeriesAnimationProtocol.
 */
- (void)addAnimation:(id<SCIScatterRenderableSeriesAnimationProtocol>)animation;

@end

/** @}*/
