//
//  ArrayController2D.h
//  SciChart
//
//  Created by Admin on 04.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGenericType.h"

/**
 * The class is 2D array implementation. Inside we use only one instance of SCIArrayController, xSize and ySize.  Instance of SCIArrayController has size wich is equal xSize*ySize.
 * @discussion The clas is used in HeatMap data series type.
 * @see SCIUniformHeatmapDataSeries
 */
@interface SCIArrayController2D : NSObject

/**
 * Initializer is used for creating instance of the class with particular type, x size and y size.
 */
-(nonnull instancetype) initWithType:(SCIDataType)type SizeX:(int)xSize Y:(int)ySize;

/**
 * Returns current type of array. The type of values which are in array.
 */
-(SCIDataType) type;

/**
 * Count of columns in 2D array
 */
-(int)xSize;

/**
 * Count of rows in 2D array
 */
-(int)ySize;

/**
 * Size of data type of the array.
 */
-(int) dataTypeSize;

/**
 * Return pointer on array with undfined type. And example how to cast it below
 * @code
 * let arrayController = SCIArrayController2D(type: .double, sizeX: 10, y: 10)
 * arrayController?.setValue(SCIGeneric(2), atX: 0, y: 0)
 * arrayController?.setValue(SCIGeneric(3), atX: 1, y: 0)
 * arrayController?.setValue(SCIGeneric(6), atX: 0, y: 1)
 * arrayController?.setValue(SCIGeneric(7), atX: 2, y: 0)
 * arrayController?.setValue(SCIGeneric(13), atX: 0, y: 2)
 * arrayController?.setValue(SCIGeneric(15), atX: 2, y: 1)
 * arrayController?.setValue(SCIGeneric(19), atX: 1, y: 2)
 * arrayController?.setValue(SCIGeneric(22), atX: 2, y: 2)
 * let dataArray = arrayController?.data()
 * let size = (arrayController?.ySize())!*(arrayController?.xSize())!
 * let castedArray = dataArray?.bindMemory(to: Double.self, capacity:Int(size))
 * let x = 1
 * let y = 2
 * let value = castedArray?[x+y*Int((arrayController?.xSize())!)]
 * // And here value = 19
 * @endcode
 */
-(void *_Nonnull) data;

/**
 * Return instance of SCIGenericType which has pointer on array of types such like those: void, char, int, double, float. 
 */
-(SCIGenericType)genericData;

/**
 * Return value at x index and y index.
 */
-(SCIGenericType) valueAtX:(int)x Y:(int)y;

/**
 * Update value at x index and y index.
 */
-(void) setValue:(SCIGenericType)value AtX:(int)x Y:(int)y;

- (void)setValueArray:(SCIGenericType)array AtX:(int)x Y:(int)y Count:(int)count;

@end

/** @}*/
