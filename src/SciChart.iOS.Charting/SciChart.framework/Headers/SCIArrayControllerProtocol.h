//
//  SCIArrayControllerProtocol.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 9/13/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGenericType.h"
#import "SCIDataType.h"
#import "SCIEnumerationConstants.h"

/**
 * Interface of wrapper for c arrays.
 */
@protocol SCIArrayControllerProtocol ///
<NSObject>
/** @{ @} */

/**
 * Initializer which set default type of array.
 * @see SCIDataType
 */
-(id) initWithType:(SCIDataType)type;

/**
 * Initializer which set default type of array and size.
 * @see SCIDataType
 */
-(id) initWithType:(SCIDataType)type Size:(int)size;

/**
 * Returns current type of array. The type of values which are in array.
 */
-(SCIDataType) type;

/**
 * Count of values in array.
 */
-(int) count;

/**
 * Set size for current array.
 */
-(void) setCount:(int)count;

/**
 * Size of data type of the array.
 */
-(int) dataTypeSize;

/**
 * Return pointer on array with undfined type. And example how to cast it below
 * @code
 * let dataArray = arrayController?.data()
 * let castedArray = dataArray?.bindMemory(to: Double.self, capacity: (arrayController?.count())!)
 * let value = castedArray?[3]
 * // And here value = 3.6
 * @endcode
 */
-(void *) data;

/**
 * Return pointer on array with undfined type. If type of input parameter is not equal with type of SCIArrayController it returns nil. And example how to cast it below
 * @code
 * let dataArray = arrayController?.data()
 * let castedArray = dataArray?.bindMemory(to: Double.self, capacity: (arrayController?.count())!)
 * let value = castedArray?[3]
 * // And here value = 3.6
 * @endcode
 */
-(void *) dataOfType:(SCIDataType)type;

/**
 * Return pointer on array with float type.
 */
-(float *) floatData;

/**
 * Return pointer on array with double type.
 */
-(double *) doubleData;

/**
 * Return pointer on array with short int type.
 */
-(short *) int16Data;

/**
 * Return pointer on array with int type.
 */
-(int *) int32Data;

/**
 * Return pointer on array with int64 type.
 */
-(long long *) int64Data;

/**
 * Return pointer on array with char type.
 */
-(char *) byteData;

/**
 * Return pointer on array with double type values but it can be converted into NSDate.
 */
-(double *) dateTimeData;

/**
 * Return instance of SCIGenericType which has pointer on array of types such like those: void, char, int, double, float.
 */
-(SCIGenericType)genericData;

/**
 * Return value at index.
 * @see SCIGenericType
 */
-(SCIGenericType) valueAt:(int)index;

/**
 * Return min value and max value in array.
 * @code
 * let arrayController = SCIArrayController(type: .double)
 * arrayController?.append(SCIGeneric(1.0))
 * arrayController?.append(SCIGeneric(2.0))
 * arrayController?.append(SCIGeneric(3.0))
 * arrayController?.append(SCIGeneric(3.5))
 *
 * var minValue = Double.nan
 * var maxValue = Double.nan
 * arrayController?.getRangeMin(&minValue, max: &maxValue)
 *
 * // minValue = 1.0 and maxValue = 3.5
 * @endcode
 */
-(void) getRangeMin:(double*)outMin max:(double*)outMax;

/**
 * Removing value at index.
 */
-(void) removeAt:(int)index;

/**
 * Remove exact value from array.
 */
-(void) removeValue:(SCIGenericType)value;

/**
 * Remove range values at index and count.
 */
-(void) removeRangeFrom:(int)index Count:(int)count;

/**
 * Update value at index.
 */
- (void) setValue:(SCIGenericType)value At:(int)index;

- (void)setValueArray:(SCIGenericType)array atIndex:(int)index andCount:(int)count;

/**
 * Insert value at index.
 */
-(void) insertValue:(SCIGenericType)value At:(int)index;

/**
 * Insert values at particular index with SCIGenericType which has pointer on array of types such like those: void, char, int, double, float.
 */
-(void) insertRange:(SCIGenericType)array At:(int)index Count:(int)count;

/**
 * Return index of value in array.
 */
-(int) indexOf:(SCIGenericType)value IsSorted:(BOOL)isSorted SearchMode:(SCIArraySearchMode)searchMode;

/**
 * Return YES if array is empty.
 */
-(BOOL) isEmpty;

/**
 * Adds new value
 * @code
 dataSeries.appendX(SCIGeneric(x), y: SCIGeneric(y))
 * @endcode
 */
-(void) append:(SCIGenericType)value;

/**
 * Remove all values in array. But indeed only count is set into 0. And new value are appeded insetead of old values. And size value is stayed old. It is very fast way to clear array.
 */
-(void) clear;

/**
 * The method completely clear array and set Size into 0;
 */
-(void) purge;

/**
 * Retun max size of array.
 */
-(int) currentMaxSize;

/**
 * Append array of values.
 * @code
 * let arrayController = SCIArrayController(type: .double)
 * arrayController?.appendRange([1.0, 2.0, 2.5, 3.6])
 * @endcode
 */
-(void) appendRange:(NSArray*)array;

/**
 * Append values with SCIGenericType instance which has pointer on array of types such like those: void, char, int, double, float.
 */
-(void) appendRange:(SCIGenericType)array Count:(int)count;

/**
 * Copy data from current array to another array. 
 * @code
 * let copyOfArray = UnsafeMutablePointer<UnsafeMutableRawPointer?>.allocate(capacity: (arrayController?.count())!)
 * var count : Int = 0
 * arrayController?.copy(toArray: copyOfArray, count: &count, type: .double)
 * let castedArray = copyOfArray.pointee?.bindMemory(to: Double.self, capacity: count)
 * let value = castedArray?[2]
 * // And here value = 2.5
 * @endcode
 */
-(void) copyToArray:(void**)data Count:(int*)count Type:(SCIDataType)type;

/**
 * Reorder array in reverse order.
 */
-(void)reverse;

@end

/** @}*/
