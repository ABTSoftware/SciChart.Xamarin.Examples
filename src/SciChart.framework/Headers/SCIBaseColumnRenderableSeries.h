//
//  SCIBaseColumnRenderableSeries.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 5/4/17.
//  Copyright © 2017 SciChart. All rights reserved.
//


/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"
#import "SCIThemeableProtocol.h"

@protocol SCIColumnRenderableSeriesAnimationProtocol;
@class SCIColumnSeriesStyle;
@class SCIBrushStyle;

@interface SCIBaseColumnRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>

/**
 * @brief Get or set style for visual customization
 * @see SCIColumnSeriesStyle
 */
@property(nonatomic, copy) SCIColumnSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCIColumnSeriesStyle *selectedStyle;

@property(nonatomic) SCIBrushStyle *fillBrushStyle;

@property(nonatomic) double dataPointWidth;

/**
 Make the series animatable. After adding animation and then change data series of the renderable series make new data appear with animation.
 It is not thread safe method. It should be called only from main thread.
 @code
 renderableSeries.addAnimation(SCIScaleRenderableSeriesAnimation(duration: 5, curveAnimation: SCIAnimationCurveEaseOut))
 renderableSeries.dataSeries = newDataSeries
 @endcode
 @param animation some base animation object which implements SCIColumnRenderableSeriesAnimationProtocol.
 */
- (void)addAnimation:(id<SCIColumnRenderableSeriesAnimationProtocol>)animation;

@end
/** @}*/
