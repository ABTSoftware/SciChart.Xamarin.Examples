//
//  SCIDataSeries+SCIDataSeriesXColumnEvents.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 9/13/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import "SCIDataSeries.h"

@interface SCIDataSeries (XColumnEvents)

- (void)onUpdateXColumnAtIndex:(int)atIndex;
- (void)onAppendXColumnWithPreviousCount:(int)previousCount;
- (void)onInsertXColumnWithPreviousCount:(int)previousCount atIndex:(int)atIndex;


@end

/** @}*/