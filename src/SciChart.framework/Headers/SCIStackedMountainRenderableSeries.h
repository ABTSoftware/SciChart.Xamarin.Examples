//
//  StackedMountainRenderableSeries.h
//  SciChart
//
//  Created by Admin on 19.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import "SCIBaseMountainRenderableSeries.h"
#import "SCIStackedRenderableSeries.h"
#import "SCIThemeableProtocol.h"

@class SCIMountainSeriesStyle;

/**
 * @brief The SCIStackedMountainRenderableSeries class.
 * @discussion This renderable series displays data points band starting at zero line or from previous stacked renderable series band
 * @discussion Stacked mountains stacks data vertically. That means that current Y value is summ of Y value and values at the same X of all other stacked mountain series in stacked group that are lower in order
 * @remark Should be used as sub series of SCIStackedGroupSeries
 * @remark Designed to work with SCIXyDataSeries as data container
 * @remark For styling provide or customize SCIMountainSeriesStyle
 * @see SCIStackedRenderableSeriesProtocol
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIXyDataSeriesProtocol
 * @see SCIMountainSeriesStyle
 */
@interface SCIStackedMountainRenderableSeries : SCIBaseMountainRenderableSeries <SCIStackedRenderableSeriesProtocol>

@end

/** @}*/