//
//  FastMountainRenderableSeries.h
//  SciChart
//
//  Created by Admin on 06.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import "SCIBaseMountainRenderableSeries.h"

/**
 * @brief The SCIFastMountainRenderableSeries class.
 * @discussion This renderable series displays filled area from zero line to data points with outline (connecting data points) as option
 * @remark Designed to work with SCIXyDataSeries as data container
 * @remark For styling provide or customize SCIMountainSeriesStyle
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIXyDataSeries
 * @see SCIMountainSeriesStyle
 */
@interface SCIFastMountainRenderableSeries : SCIBaseMountainRenderableSeries 

@end

/** @}*/
