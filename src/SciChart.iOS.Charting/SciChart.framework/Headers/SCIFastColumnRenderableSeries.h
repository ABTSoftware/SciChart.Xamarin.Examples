//
//  FastColumnRenderableSeries.h
//  SciChart
//
//  Created by Admin on 01.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import "SCIBaseColumnRenderableSeries.h"

/**
 * @brief The SCIFastColumnRenderableSeries class.
 * @discussion This renderable series displays data points as columns from zero line to data point coordinates
 * @remark Designed to work with SCIXyDataSeries as data container
 * @remark For styling provide or customize SCIColumnSeriesStyle
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIXyDataSeries
 * @see SCIColumnSeriesStyle
 */
@interface SCIFastColumnRenderableSeries : SCIBaseColumnRenderableSeries

@end

/** @}*/