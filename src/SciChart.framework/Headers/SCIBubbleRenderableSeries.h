//
//  BubbleRenderableSeries.h
//  SciChart
//
//  Created by Admin on 18.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import "SCIRenderableSeriesBase.h"

@class SCIBubbleSeriesStyle;
@class SCIBrushStyle;
@protocol SCIBubbleRenderableSeriesAnimationProtocol;

static const float max_bubble_size_in_pixel = 100.f; //Using for autoZRange property.

/**
 * @brief The SCIBubbleRenderableSeries class.
 * @discussion Every data point in this renderable series has XYZ data and displayed as buble with position at XY and radius defined by Z value
 * @remark Designed to work with SCIXyzDataSeriesProtocol as data container
 * @remark For styling provide or customize SCIBubbleSeriesStyle
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIXyzDataSeriesProtocol
 * @see SCIBubbleSeriesStyle
 */
@interface SCIBubbleRenderableSeries : SCIRenderableSeriesBase

/**
 * @brief Get or set style for visual customization
 * @see SCIBubbleSeriesStyle
 */
@property(nonatomic, copy) SCIBubbleSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCIBubbleSeriesStyle *selectedStyle;

/**
 * @brief Get or set bubble scale
 * @discussion If autoZrange is NO, Z value multiplied by zScale is bubble radius in pixels
 */
@property(nonatomic) double zScaleFactor;

/**
 * @brief Get or Set auto range for Z. Default is NO. If value is YES Max Z value uses max_bubble_size_in_pixel for defining size of radius.
 */
@property(nonatomic) BOOL autoZRange;

@property(nonatomic) SCIBrushStyle *bubbleBrushStyle;

/**
 Make the series animatable. After adding animation and then change data series of the renderable series make new data appear with animation.
 It is not thread safe method. It should be called only from main thread.
 @code
 renderableSeries.addAnimation(SCIScaleRenderableSeriesAnimation(duration: 5, curveAnimation: SCIAnimationCurveEaseOut))
 renderableSeries.dataSeries = newDataSeries
 @endcode
 @param animation some base animation object which implements SCIBubbleRenderableSeriesAnimationProtocol.
 */
- (void)addAnimation:(id<SCIBubbleRenderableSeriesAnimationProtocol>)animation;

@end

/** @}*/
