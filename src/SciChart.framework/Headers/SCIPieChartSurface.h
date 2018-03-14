//
//  SCIPieChartSurface.h
//  SciChart
//
//  Created by Admin on 08/09/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SCIInvalidatableElement.h"
#include "SCIRenderSurface.h"

@class SCIGestureController;
@class SCIChartModifierCollection;
@class SCIAnnotationCollection;
@class SCIPieLayoutManager;
@class SCIPieRenderableSeriesCollection;
@protocol SCIPieRenderableSeriesProtocol;

/** \addtogroup Visuals
 *  @{
 */

/**
 *  Surface for pie and donut series. Renders series using CoreGraphics
 */
@interface SCIPieChartSurface : UIView <SCIInvalidatableElementProtocol>

@property (nonatomic, weak, nullable) id<SCIRenderSurfaceProtocol> renderSurface;

/**
 *  Collection of renderable series. Can contain pie or donut series.
 *
 * @see SCIPieRenderableSeriesCollection
 */
@property (nonatomic, strong, nonnull) SCIPieRenderableSeriesCollection * renderableSeries;

/**
 * Instance of gesture handler
 * @see SCIGestureController
 */
@property (nonatomic, strong, nonnull) SCIGestureController * gestureController;

/**
 *  Collection of chart modifiers. SCIPieChartSurface works only with Pie modifiers
 *
 * @see SCIChartModifierCollection
 * @see SCIChartModifierProtocol
 */
@property (nonatomic, strong, nonnull) SCIChartModifierCollection *chartModifiers;
@property (nonatomic, strong, nonnull) SCIAnnotationCollection *annotations; // TODO: hide

/**
 * Manager that calculates size for pie and donut series
 * @see SCIPieLayoutManager
 */
@property (nonatomic, strong, nullable) SCIPieLayoutManager * layoutManager;

/**
 * return frame of SciChart surface
 */
-(CGRect)frame;
/**
 * return frame of charts area
 */
-(CGRect)chartFrame;

/**
 * Gets or sets size of hole for first donut series. Hole size in points
 */
@property (nonatomic) float holeRadius;
/**
 * Gets or sets space between pie series in points
 */
@property (nonatomic) float seriesSpacing;
/**
 * Gets or sets distance from chart area border to pie charts in points
 */
@property (nonatomic) float margin;
/**
 * Gets or sets minimum series height which is used if autolayout failed to calculate size
 */
@property (nonatomic) float seriesMinimumHeight;

@end

/** @}*/

