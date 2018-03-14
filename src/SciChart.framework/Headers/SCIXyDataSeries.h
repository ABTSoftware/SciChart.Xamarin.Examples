//
//  XYDataSeries.h
//  SciChart
//
//  Created by Admin on 07.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIDataSeries.h"
#import "SCIGenericType.h"

#pragma mark - SCIXyDataSeries protocol

/**
 * Inteface for all dataSeries which has at least x and y columns.
 @extends SCIDataSeriesProtocol
 */
@protocol SCIXyDataSeriesProtocol ///
<SCIDataSeriesProtocol>
/** @{ @} */

/**
 * Add array of values. You can create SCIGenerirType instance with C array and pass it through input parameters. Also you should pass size of array into parameter count.
 */
-(void) appendRangeX:(SCIGenericType)x Y:(SCIGenericType)y Count:(int)count;
    
/**
 * Add array of values. Input parameteres can be array of any object which implements method "doubleValue"(e.g. NSNumber, NSString). Also ensure that arrays are equal or you will have exception with text "DataSeries can operate only on arrays with equal size"
 * @code
 * // Swift 3 Example
 * let dataSeriesXy = SCIXyDataSeries(xType: .double, yType: .double)
 * let xArray = [2, 3, 5, 6, 7];
 * let yArray = [3, 6, 9, 1, 2];
 * dataSeriesXy?.appendRangeX(xArray, y: yArray)
 * @endcode
 */
-(void) appendRangeX:(nonnull NSArray*)x Y:(nonnull NSArray*)y;
    
/**
 * Add new value for existing data.
 * @see SCIGenericType
 * @code
 * // Swift 3 Example
 * let dataSeriesXy = SCIXyDataSeries(xType: .double, yType: .double)
 * dataSeriesXy?.appendX(SCIGeneric(2.0), y: SCIGeneric(3.0))
 * @endcode
 */
-(void) appendX:(SCIGenericType)x Y:(SCIGenericType)y;
    
/**
 * Update y Value and x Value at index. For example if our dataSeries looks like this
 * [(1, 3), (3, 6), (5, 12)]
 *
 * @code
 *
 * let dataSeriesXy = SCIXyDataSeries(xType: .int16, yType: .int16)
 * dataSeriesXy?.update(at: 1, xValue: SCIGeneric(0), yValue: SCIGeneric(Double.nan))
 *
 * @endcode
 *
 * After this code DataSeries looks like this.
 * [(1, 3), (0, NaN), (5, 12)]
 */
-(void) updateAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y;

/**
 * Update x Value at index
 */
-(void) updateAt:(int)index X:(SCIGenericType)x;

/**
 * Update y Value at index
 */
-(void) updateAt:(int)index Y:(SCIGenericType)y;
    
-(void) updateRange:(int)index xValues:(SCIGenericType)xValues yValues:(SCIGenericType)yValues count:(int)count;
-(void) updateRange:(int)index yValues:(SCIGenericType)yValues count:(int)count;
-(void) updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;

/**
 * Insert y Value and x Value at index. For example if our dataSeries looks like this
 * [(1, 3), (3, 6), (5, 12)]
 *
 * @code
 *
 * let dataSeriesXy = SCIXyDataSeries(xType: .int16, yType: .int16)
 * dataSeriesXy?.insert(at: 1, x: SCIGeneric(3), y: SCIGeneric(Double.nan))
 *
 * @endcode
 *
 * After this code DataSeries looks like this.
 * [(1, 3), (0, NaN), (3, 6), (5, 12)]
 */
-(void) insertAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y;

/**
 * Update y Value and x Value at index. For example if our dataSeries looks like this
 * [(1, 3), (3, 6), (5, 12)]
 *
 * @code
 * let dataSeriesXy = SCIXyDataSeries(xType: .int16, yType: .int16)
 * let xArray = UnsafeMutablePointer<Int16>.allocate(capacity: 2)
 * xArray[0] = 12
 * xArray[1] = 4
 *
 * let yArray = UnsafeMutablePointer<Int16>.allocate(capacity: 2)
 * yArray[0] = 19
 * yArray[1] = 14
 *
 * dataSeriesXy?.insertRange(at:2, x:SCIGeneric(xArray), y: SCIGeneric(yArray), count: 2)
 * @endcode
 *
 * After this code DataSeries looks like this.
 * [(1, 3), (12, 19), (4, 14), (3, 6), (5, 12)]
 */
-(void) insertRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Count:(int)count;

@end

#pragma mark - SCIXyDataSeries default implementation

/**
 * Simpliest implementation of x y dataSeries.
 */
@interface SCIXyDataSeries : SCIDataSeries <SCIXyDataSeriesProtocol>

@end

/** @}*/
