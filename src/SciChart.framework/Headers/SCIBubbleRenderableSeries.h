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

@end

/** @}*/
