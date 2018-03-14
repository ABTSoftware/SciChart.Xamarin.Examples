//
//  XyzDataSeries.h
//  SciChart
//
//  Created by Admin on 18.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIDataSeries.h"

#pragma mark - SCIXyzDataSeries protocol

/**
 * @brief Protocol for data series that for every X value has Y and Z value
 * @see SCIBubbleRenderableSeries
 @extends SCIDataSeriesProtocol
 */
@protocol SCIXyzDataSeriesProtocol ///
<SCIDataSeriesProtocol>
/** @{ @} */

/**
 * Return type of values in z Column;
 * @see SCIDataType
 */
-(SCIDataType) zType;

/**
 * Return an instance of SCIArrayController of x values.
 * @see SCIArrayControllerProtocol
 */
-(nonnull id<SCIArrayControllerProtocol>) zValues;

/**
 * @code
 * let xyzDataSeries = SCIXyzDataSeries(xType: .int16, yType: .int16, zType: .int16)
 * xyzDataSeries?.appendX(SCIGeneric(1), y: SCIGeneric(2), z: SCIGeneric(3))
 * @endcode
 */
-(void) appendX:(SCIGenericType)x
              Y:(SCIGenericType)y
              Z:(SCIGenericType)z;

/**
 * Add new x Values, y Values and z Values;
 * @code
 * let xyzDataSeries = SCIXyzDataSeries(xType: .int16, yType: .int16, zType: .int16)
 *
 * let xValues = [1, 2, 3, 4]
 * let yValues = [1, 2, 3, 4]
 * let zValues = [1, 2, 3, 4]
 *
 * xyzDataSeries?.appendRangeX(xValues, y: yValues, z: zValues)
 * @endcode
 */
-(void) appendRangeX:(nonnull NSArray*)x
                   Y:(nonnull NSArray*)y
                   Z:(nonnull NSArray*)z;

/**
 * Add new values with SCIGenericType which has pointer on array of types such like those: void, char, int, double, float.
 */
-(void) appendRangeX:(SCIGenericType)x
                   Y:(SCIGenericType)y
                   Z:(SCIGenericType)z
               Count:(int)count;

/**
 *  * Update x Value y Value and z Value at index.
 * @code
 * let xyzDataSeries = SCIXyzDataSeries(xType: .int16, yType: .int16, zType: .int16)
 * xyzDataSeries?.appendX(SCIGeneric(1), y: SCIGeneric(2), z: SCIGeneric(3))
 * xyzDataSeries?.update(at: 0, y: SCIGeneric(3), z: SCIGeneric(4))
 * @endcode
 */
-(void) updateAt:(int)index X:(SCIGenericType)x Y:(SCIGenericType)y Z:(SCIGenericType)z;

/**
 *  * Update x Value at index.
 */
-(void) updateAt:(int)index X:(SCIGenericType)x;
/**
 *  * Update y Value at index.
 */
-(void) updateAt:(int)index Y:(SCIGenericType)y;
/**
 *  * Update z Value at index.
 */
-(void) updateAt:(int)index Z:(SCIGenericType)z;

- (void)updateRange:(int)index xValues:(SCIGenericType)xValues yValues:(SCIGenericType)yValues zValues:(SCIGenericType)zValues count:(int)count;
- (void)updateRange:(int)index xValues:(SCIGenericType)xValues count:(int)count;
- (void)updateRange:(int)index yValues:(SCIGenericType)yValues count:(int)count;
- (void)updateRange:(int)index zValues:(SCIGenericType)zValues count:(int)count;

/**
 * Insert new x Value, y Value and z Value at particular index.
 * @code
 * let xyzDataSeries = SCIXyzDataSeries(xType: .int16, yType: .int16, zType: .int16)
 * xyzDataSeries?.appendX(SCIGeneric(1), y: SCIGeneric(2), z: SCIGeneric(3))
 * xyzDataSeries?.insert(at: 0, x: SCIGeneric(0), y: SCIGeneric(5), z: SCIGeneric(7))
 * @endcode
 */
-(void) insertAt:(int)index
               X:(SCIGenericType)x
               Y:(SCIGenericType)y
               Z:(SCIGenericType)z;

/**
 * Insert new values with SCIGenericType which has pointer on array of types such like those: void, char, int, double, float.
 */
-(void) insertRangeAt:(int)index
                    X:(SCIGenericType)x
                    Y:(SCIGenericType)y
                    Z:(SCIGenericType)z
                Count:(int)count;

@end

#pragma mark - SCIXyzDataSeries default implementation

/**
 * DataSeries which is used in SCIBubbleRenderableSeries.
 * @see SCIBubbleRenderableSeries
 */
@interface SCIXyzDataSeries : SCIDataSeries <SCIXyzDataSeriesProtocol>

/**
 * An instance of SCIArrayController of z values.
 */
@property (nonatomic, strong, nonnull) id<SCIArrayControllerProtocol> zColumn;

/**
 * Initializers which set types for x column, y column z column.
 */
-(nonnull instancetype)initWithXType:(SCIDataType)xType YType:(SCIDataType)yType ZType:(SCIDataType)zType;

/**
 * The initializer creates data series instance with xColumn, yColumn and zColumn of SCIArrayControllerFIFO. And also sets type for them.
 */
-(nonnull instancetype)initFifoWithXType:(SCIDataType)xType YType:(SCIDataType)yType ZType:(SCIDataType)zType FifoSize:(int)size;

@end

/** @}*/
