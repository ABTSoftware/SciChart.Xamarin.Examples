//
//  SCIRenderableSeriesCollection.h
//  SciChart
//
//  Created by Admin on 17/01/17.
//  Copyright © 2017 SciChart. All rights reserved.
//


/** \addtogroup RenderableSeries
 *  @{
 */
#import <Foundation/Foundation.h>
#import "SCIObservableCollection.h"

@class SCIChartSurface;
@protocol SCIRenderableSeriesProtocol;

/**
 * @brief Container for renderable series
 */
@interface SCIRenderableSeriesCollection : SCIObservableCollection

- (instancetype)initWithParent:(SCIChartSurface *)parent;

- (instancetype)initWithParent:(SCIChartSurface *)parent SeriesCollection:(NSArray<id <SCIRenderableSeriesProtocol>> *)series;

@property(nonatomic, weak) SCIChartSurface *parent;

/**
 * Appends series to the collection
 * @param item Item to insert into collection
 * @see SCIRenderableSeriesProtocol
 */
- (void)add:(id <SCIRenderableSeriesProtocol>)item;

/**
 * Removes the series instance from this collection.
 *
 * @param item RenderableSeries instance to be deleted from the collection, if present in it.
 * @return Return YES If item is removed, otherwise NO
 */
- (BOOL)remove:(id <SCIRenderableSeriesProtocol>)item;

/**
 * Gets series by index from the collection
 * @param index Index used when retrieving for renderable series
 * @see SCIRenderableSeriesProtocol
 */
- (id <SCIRenderableSeriesProtocol>)itemAt:(unsigned int)index;

/**
 * Inserts series into the collection at specified position
 * @param item Item to insert into collection
 * @param index Position where series will be placed
 * @see SCIRenderableSeriesProtocol
 */
- (void)insert:(id <SCIRenderableSeriesProtocol>)item At:(int)index;

/**
 * Return first object from this instance of SCIRenderableSeriesCollection
 */
- (id <SCIRenderableSeriesProtocol>)firstObject;

/**
 * Checks whether series collection contains the series or not
 * @param item Item to check in collection
 * @see SCIRenderableSeriesProtocol
 */
- (BOOL)contains:(id <SCIRenderableSeriesProtocol>)item;

/**
 * Returns the index of the first occurrence of the specified renderable series in this collection.
 *
 * @return Returns the index of the first occurrence, otherwise returns -1.
 */
- (int)indexOf:(id <SCIRenderableSeriesProtocol>)item;

/**
 * Replaces the renderableSeries at the specified position in this collection with the specified element.
 *
 * @param series renderableSeries to be stored at the specified position
 * @param index index of the element to replace
 */
- (void)setSeries:(id <SCIRenderableSeriesProtocol>)series atIndex:(unsigned int)index;

@end

@interface SCIRenderableSeriesCollection (Indexing)

- (id <SCIRenderableSeriesProtocol>)objectAtIndexedSubscript:(unsigned int)idx;

- (void)setObject:(id <SCIRenderableSeriesProtocol>)obj atIndexedSubscript:(unsigned int)idx;

@end
/** @}*/
