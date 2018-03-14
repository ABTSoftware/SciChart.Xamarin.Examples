//
//  SCIErrorBarsRenderableSeries.h
//  SciChart
//
//  Created by Yaroslav Pelyukh on 3/20/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIErrorBarsSeriesStyle.h"
#import "SCIFastFixedErrorBarsRenderableSeries.h"
#import "SCIRenderableSeriesBase.h"

typedef void(^IterationPassHlcDataHandler)(double xValue, double xCoordinate, double yValue, double yCoordinate, double highValue, double lowValue, int index);

@class SCIErrorBarsSeriesStyle;
@protocol SCIErrorBarsRenderableSeriesAnimationProtocol;
/**
 * @brief SCIFastErrorBarsRenderableSeries class.
 * @discussion Provides properties for setting the parameters of the ErrorBars.
 */
@interface SCIFastErrorBarsRenderableSeries : SCIRenderableSeriesBase

/**
 * @brief The SCIFastErrorBarsRenderableSeries class' property.
 * @discussion Gets or sets the SCIFastErrorBarsRenderableSeries Style property.
 * @see SCIErrorBarsSeriesStyle
 */
@property(nonatomic, copy) SCIErrorBarsSeriesStyle *style;

/**
 * @brief The SCIFastErrorBarsRenderableSeries class' property.
 * @discussion Gets or sets the SCIFastErrorBarsRenderableSeries selected style property.
 * @discussion If set to nil selected style is default series style
 * @see SCIErrorBarsSeriesStyle
 */
@property(nonatomic, copy) SCIErrorBarsSeriesStyle *selectedStyle;

/**
 * Width of line limit of errors
 */
@property(nonatomic) double dataPointWidth;

/**
 * Error type of erros bars. For more description see SCIErrorBarType enum.
 * @see SCIErrorBarType
 */
@property(nonatomic) SCIErrorBarType errorType;

/**
 * Error direction of erros bars. For more description see SCIErrorBarDirection enum.
 * @see SCIErrorBarDirection
 */
@property(nonatomic) SCIErrorBarDirection errorDirection;

/**
 * Error mode of erros bars. For more description see SCIErrorBarMode enum.
 * @see SCIErrorBarMode
 */
@property(nonatomic) SCIErrorBarMode errorMode;

@property(nonatomic) SCIPenStyle *strokeHighStyle;

@property(nonatomic) SCIPenStyle *strokeLowStyle;

/**
 Make the series animatable. After adding animation and then change data series of the renderable series make new data appear with animation.
 It is not thread safe method. It should be called only from main thread.
 @code
 renderableSeries.addAnimation(SCIScaleRenderableSeriesAnimation(duration: 5, curveAnimation: SCIAnimationCurveEaseOut))
 renderableSeries.dataSeries = newDataSeries
 @endcode
 @param animation some base animation object which implements SCIErrorBarsRenderableSeriesAnimationProtocol.
 */
- (void)addAnimation:(id<SCIErrorBarsRenderableSeriesAnimationProtocol>)animation;

@end
/** @}*/
