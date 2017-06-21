//
//  SCIDataSeriesObserver.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 6/14/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"

@interface SCIDataSeriesObserver : NSObject

- (instancetype _Nonnull )initWithDataSeriesChangedBlock:(SCIActionBlock _Nonnull )block;

/**
 * Callback is called every time when somthing chages in data series (appending new values, removing, inserting).
 * @code
 *
 * let dataSeriesXy = SCIXyDataSeries(xType: .double, yType: .double)
 * dataSeriesXy?.onDataSeriesChanged = {() -> () in return
 *   print(dataSeriesXy?.count()) // Add some code here which will be run when data series is changed
 * }
 * dataSeriesXy?.appendX(SCIGeneric(2.0), y: SCIGeneric(3.0))
 *
 * @endcode
 */
@property (nonatomic, copy, nonnull) SCIActionBlock onDataSeriesChanged;

@end
