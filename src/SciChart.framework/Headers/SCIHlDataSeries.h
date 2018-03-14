//
//  SCIHlDataSeries.h
//  SciChart
//
//  Created by Yaroslav Pelyukh on 3/16/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SciChart.h"


/**
 * Inteface for all dataSeries which has at least x and y columns.
 @extends SCIDataSeriesProtocol
 */
@protocol SCIHlDataSeriesProtocol ///
<SCIDataSeriesProtocol>
/** @{ @} */

/**
 * Datasource for high column
 */
-(id<SCIArrayControllerProtocol>) highColumn;

/**
 * Datasource for low column
 */
-(id<SCIArrayControllerProtocol>) lowColumn;

/**
 * Returns type of high values
 */
-(SCIDataType) highType;

/**
 * Returns type of low values
 */
-(SCIDataType) lowType;

/**
 * Appends an Open, High, Low, Close point to the series.
 *
 */
-(void) appendX:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;

/**
 * Appends an Open, High, Low, Close range of points to the series.
 *
 */
-(void) appendRangeX:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low Count:(int)count;

/**
 * Updates an Y, High and Low point to the series at specified index
 */
-(void) updateAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;

/**
 * Updates an Y, High and Low point to the series at specified index
 */
-(void) updateAt:(int)index Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;

/**
 * Updates an Y, High and Low range of points to the series at specified index
 */
-(void) updateRangeAt:(int)index Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low Count:(int)count;

/**
 * Inserts X and Y, High and Low points to the series at specified index
 */
-(void) insertAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low;

/**
 * Inserts X and Y, High and Low range of points to the series at specified index
 */
-(void) insertRangeAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y High:(SCIGenericType)high Low:(SCIGenericType)low Count:(int)count;

@end

@interface SCIHlDataSeries : SCIDataSeries<SCIHlDataSeriesProtocol>
/**
 * Datasource for high column
 */
@property (nonatomic, strong) id<SCIArrayControllerProtocol> highColumn;

/**
 * Datasource for low column
 */
@property (nonatomic, strong) id<SCIArrayControllerProtocol> lowColumn;

@end

/** @}*/
