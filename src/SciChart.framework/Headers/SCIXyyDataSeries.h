//
//  XyyDataSeries.h
//  SciChart
//
//  Created by Admin on 16.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIDataSeries.h"
#import "SCIDataSeries.h"

#pragma mark - SCIXyyDataSeries protocol

/**
 * DataSeries for SCIBandRenderableSeries. It extends SCIDataSeriesProtocol. Here we have for each x value two y values. (y1Values and y2Values)
 * @see SCIBandRenderableSeries
 @extends SCIDataSeriesProtocol
 */
@protocol SCIXyyDataSeriesProtocol ///
<SCIDataSeriesProtocol>
/** @{ @} */

/**
 * First Column of y values.
 * @see SCIArrayControllerProtocol
 */
-(id<SCIArrayControllerProtocol>) y1Values;

/**
 * Second Column of y values.
 * @see SCIArrayControllerProtocol
 */
-(id<SCIArrayControllerProtocol>) y2Values;

/**
 * Type of first y column.
 * @see SCIDataType
 */
-(SCIDataType) y1Type;

/**
 * Type of second y column.
 * @see SCIDataType
 */
-(SCIDataType) y2Type;

/**
 * Add new x Value, y1 Value and y2Value;
 * @code
 * let xyyDataSeries = SCIXyyDataSeries(xType: .int16, yType: .int16)
 * xyyDataSeries?.appendX(SCIGeneric(1), y1: SCIGeneric(3), y2: SCIGeneric(1))
 * @endcode
 */
-(void) appendX:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;

/**
 * Add new x Values, y1 Values and y2Values;
 * @code
 * let xyyDataSeries = SCIXyyDataSeries(xType: .int16, yType: .int16)
 * let xValues = [1, 2, 3, 4]
 * let y1Values = [1, 2, 3, 4]
 * let y2Values = [1, 2, 3, 4]
 * xyyDataSeries?.appendRangeX(xValues, y1: y1Values, y2: y2Values)
 * @endcode
 */
-(void) appendRangeX:(NSArray*)x Y1:(NSArray*)y1 Y2:(NSArray*)y2;

/**
 * Add new values with SCIGenericType which has pointer on array of types such like those: void, char, int, double, float.
 */
-(void) appendRangeX:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2 Count:(int)count;

/**
 * Update x, y1 Value and y2 Value at index.
 * @code
 * let xyyDataSeries = SCIXyyDataSeries(xType: .int16, yType: .int16)
 * xyyDataSeries?.update(at: 0, y1: SCIGeneric(8), y2: SCIGeneric(2))
 * @endcode
 */
-(void) updateAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;
/**
 * Update x Value at index.
 */
-(void) updateAt:(int)index X:(SCIGenericType)x;
/**
 * Update y1 at index.
 */
-(void) updateAt:(int)index Y1:(SCIGenericType)y1;
/**
 * Update y2 Value at index.
 */
-(void) updateAt:(int)index Y2:(SCIGenericType)y2;
    
- (void)updateRange:(int)index xValues:(SCIGenericType)xValues y1Values:(SCIGenericType)y1Values y2Values:(SCIGenericType)y2Values count:(int)count;
- (void)updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;
- (void)updateRange:(int)index y1Values:(SCIGenericType)y1Values count:(int)count;
- (void)updateRange:(int)index y2Values:(SCIGenericType)y2Values count:(int)count;
    
/**
 * Insert new x Value, y1 Value and y2 Value at particular index.
 * @code
 * let xyyDataSeries = SCIXyyDataSeries(xType: .int16, yType: .int16)
 * xyyDataSeries?.insert(at: 0, x: SCIGeneric(2), y1: SCIGeneric(4), y2: SCIGeneric(2))
 * @endcode
 */
-(void) insertAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2;

/**
 * Insert new values with SCIGenericType which has pointer on array of types such like those: void, char, int, double, float.
 */
-(void) insertRangeAt:(int)index X:(SCIGenericType)x Y1:(SCIGenericType)y1 Y2:(SCIGenericType)y2 Count:(int)count;

@end

#pragma mark - SCIXyyDataSeries default implementation

/**
 * DataSeries for SCIBandRenderableSeries.
 * @see SCIBandRenderableSeries
 */
@interface SCIXyyDataSeries : SCIDataSeries <SCIXyyDataSeriesProtocol>

/**
 * An instance of SCIArrayController of y1 values.
 */
@property (nonatomic, strong) id<SCIArrayControllerProtocol> y1Column;

/**
 * An instance of SCIArrayController of y2 values.
 */
@property (nonatomic, strong) id<SCIArrayControllerProtocol> y2Column;

@end

/** @}*/
