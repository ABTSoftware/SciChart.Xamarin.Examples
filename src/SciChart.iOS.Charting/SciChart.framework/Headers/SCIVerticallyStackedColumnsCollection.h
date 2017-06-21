//
//  SCIVerticallyStackedColumnsCollection.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 10/26/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */
#import "SCIStackedSeriesCollectionBase.h"
#import "SCIStackedRenderableSeries.h"

@interface SCIVerticallyStackedColumnsCollection : SCIStackedSeriesCollectionBase

@end

@interface SCIVerticallyStackedColumnsCollection (HorizontalShifts) <SCIStackedRenderableSeriesProtocol>

@end
/** @}*/
