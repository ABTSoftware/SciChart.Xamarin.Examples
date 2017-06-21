//
//  AxisCollection.h
//  SciChart
//
//  Created by Admin on 15.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIObservableCollection.h"

@protocol SCIAxis2DProtocol;
@class SCIChartSurface;

/**
 * @brief Provides functionality for AxisCollection class
 */
@interface SCIAxisCollection : SCIObservableCollection

- (id)initWithAxisCollection:(NSArray<id <SCIAxis2DProtocol>> *)axes Parent:(SCIChartSurface *)parent IsXAxisCollection:(BOOL)isXAxisCollection;

- (id)initWithParent:(SCIChartSurface *)parent IsXAxisCollection:(BOOL)isXAxisCollection;

@property(nonatomic, weak) SCIChartSurface *parent;

/**
 * Gets axis by Id from the AxisCollection
 * @param axisId AxisId used when searching for an axis
 * @code
 let axis = self.chartSurface.xAxes.getAxisById("xAxis")
 * @endcode
 * @see SCIAxis2D
 */
- (id <SCIAxis2DProtocol>)getAxisById:(NSString *)axisId;

- (id <SCIAxis2DProtocol>)getAxisById:(NSString *)axisId AssertAxisExist:(BOOL)assert;

/**
 * Checks whether the current AxisCollection has a primary axis - the main one in axis collection.
 * This is the axis which is responsible for drawing grid lines on the chart view
 * @discussion By default this is the first axis in the collection
 */
- (BOOL)hasPrimaryAxis;

/**
 * Gets current PrimaryAxis - the main one in axis collection.
 * This is the axis which is responsible for drawing grid lines on the chart view
 * @discussion By default this is the first axis in the collection
 */
- (id <SCIAxis2DProtocol>)primaryAxis;

/**
 * Gets the default Axis from the AxisCollection
 */
- (id <SCIAxis2DProtocol>)defaultAxis;

/** Inserts axis into the AxisCollection
 * @param item Item to insert into AxisCollection
 * @code
 self.chartSurface.xAxes.addItem(axis)
 * @endcode
 * @see SCIAxis2DProtocol
 */
- (void)add:(id <SCIAxis2DProtocol>)item;

/**
 * Removes the axis instance from this collection.
 *
 * @param item Axis instance to be deleted from the collection, if present in it.
 * @return Return YES If item is removed, otherwise NO
 */
- (BOOL)remove:(id <SCIAxis2DProtocol>)item;

/**
 * Gets axis by index from the AxisCollection
 * @param index Index used when retrieving for an axis
 * @code
 let axis = self.chartSurface.xAxes.itemAt(2)
 * @endcode
 * @see SCIAxis2DProtocol
 */
- (id <SCIAxis2DProtocol>)itemAt:(int)index;

/**
 * Inserts axis into the AxisCollection at specified position
 * @param item Item to insert into AxisCollection
 * @param index Position where axis will be placed
 * @code
 self.chartSurface.xAxes.insertItem(axis, at: 3)
 * @endcode
 * @see SCIAxis2DProtocol
 */
- (void)insert:(id <SCIAxis2DProtocol>)item At:(int)index;

/**
 * Checks whether axis collection contains the axis or not
 * @param item Item to check in AxisCollection
 * @code
 let exist = self.chartSurface.xAxes.conains(axis)
 * @endcode
 * @see SCIAxis2DProtocol
 */
- (BOOL)contains:(id <SCIAxis2DProtocol>)item;

/**
 * Returns the index of the first occurrence of the specified axis in this collection.
 *
 * @return Returns the index of the first occurrence, otherwise returns -1.
 */
- (int)indexOf:(id <SCIAxis2DProtocol>)item;

/**
 * Replaces the axis at the specified position in this collection with the specified element.
 *
 * @param axis axis to be stored at the specified position
 * @param index index of the element to replace
 */
- (void)setAxis:(id <SCIAxis2DProtocol>)axis atIndex:(unsigned int)index;

@end

@interface SCIAxisCollection (Indexing)

- (id <SCIAxis2DProtocol>)objectAtIndexedSubscript:(unsigned int)idx;

- (void)setObject:(id <SCIAxis2DProtocol>)obj atIndexedSubscript:(unsigned int)idx;

@end

/** @}*/
