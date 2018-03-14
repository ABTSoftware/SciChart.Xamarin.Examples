//
//  SCIFastFixedErrorBarsRenderableSeries.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 9/17/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIErrorBarsSeriesStyle.h"
#import "SCIRenderableSeriesBase.h"

/**
 * Possible variants how errorHigh and errorLow is calculated in error bars series.
 */
typedef enum : NSUInteger {
    /**
     * It means that errorHigh is added to value. And errorLow deducted from value.
     */
    SCIErrorBarTypeAbsolute,

    /**
     * It means that errorHighValue = value + ABS(value * self.errorHigh). And errorLowValue = value - ABS(value * self.errorLow)
     */
    SCIErrorBarTypeRelative,
} SCIErrorBarType;

/**
 * Defines direction of errors.
 */
typedef enum : NSUInteger {
    /**
     * In that case errorHigh is added to xValue and yValue is deducted from xValue.
     */
    SCIErrorBarDirectionHorizontal,

    /**
     * In that case errorHigh is added to yValue and yValue is deducted from yValue.
     */
    SCIErrorBarDirectionVertical,
} SCIErrorBarDirection;


/**
 * Defines which limits erros is shown.
 */
typedef enum : NSUInteger {
    /**
     * Shows only high limit of errors
     */
    SCIErrorBarModeHigh,

    /**
     * Shows only low limit of errors
     */
    SCIErrorBarModeLow,

    /**
     * Shows only both limits of errors
     */
    SCIErrorBarModeBoth
} SCIErrorBarMode;

@class SCIErrorBarsSeriesStyle;
@protocol SCIFixedErrorBarsRenderableSeriesAnimationProtocol;

/**
 * @brief SCIFastFixedErrorBarsRenderableSeries class.
 * @discussion Provides properties for setting the parameters of the ErrorBars.
 */
@interface SCIFastFixedErrorBarsRenderableSeries : SCIRenderableSeriesBase

/**
 * @brief The SCIFastFixedErrorBarsRenderableSeries class' property.
 * @discussion Gets or sets the SCIFastImpulseRenderableSeries Style property.
 * @see SCIErrorBarsSeriesStyle
 */
@property(nonatomic, copy) SCIErrorBarsSeriesStyle *style;

/**
 * @brief The SCIFastFixedErrorBarsRenderableSeries class' property.
 * @discussion Gets or sets the SCIFastFixedErrorBarsRenderableSeries selected style property.
 * @discussion If set to nil selected style is default series style
 * @see SCIErrorBarsSeriesStyle
 */
@property(nonatomic, copy) SCIErrorBarsSeriesStyle *selectedStyle;

/**
 * Value is used for defining max limit of error bar. It's value can be relative or absolute, it depends on errorType.
 * @see SCIErrorBarType
 */
@property(nonatomic) double errorHigh;

/**
 * Value is used for defining min limit of error bar. It's value can be relative or absolute, it depends on errorType.
 * @see SCIErrorBarType
 */
@property(nonatomic) double errorLow;

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
 @param animation some base animation object which implements SCIFixedErrorBarsRenderableSeriesAnimationProtocol.
 */
- (void)addAnimation:(id<SCIFixedErrorBarsRenderableSeriesAnimationProtocol>)animation;

@end

/** @}*/
