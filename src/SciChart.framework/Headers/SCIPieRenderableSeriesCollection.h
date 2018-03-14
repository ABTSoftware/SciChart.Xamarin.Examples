//
//  SCIPieRenderableSeriesCollection.h
//  SciChart
//
//  Created by Admin on 16/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIObservableCollection.h"

/** \addtogroup RenderableSeries
 *  @{
 */

@class SCIPieChartSurface;
@protocol SCIPieRenderableSeriesProtocol;

/**
 * @brief Container for pie renderable series
 */
@interface SCIPieRenderableSeriesCollection : SCIObservableCollection

- (instancetype)initWithParent:(SCIPieChartSurface *)parent;

- (instancetype)initWithParent:(SCIPieChartSurface *)parent SeriesCollection:(NSArray<id <SCIPieRenderableSeriesProtocol>> *)series;

@property(nonatomic, weak) SCIPieChartSurface *parent;

/**
 * Appends series to the collection
 * @param item Item to insert into collection
 * @see SCIPieRenderableSeriesProtocol
 */
- (void)add:(id <SCIPieRenderableSeriesProtocol>)item;

/**
 * Removes the series instance from this collection.
 *
 * @param item RenderableSeries instance to be deleted from the collection, if present in it.
 * @return Return YES If item is removed, otherwise NO
 */
- (BOOL)remove:(id <SCIPieRenderableSeriesProtocol>)item;

/**
 * Gets series by index from the collection
 * @param index Index used when retrieving for renderable series
 * @see SCIPieRenderableSeriesProtocol
 */
- (id <SCIPieRenderableSeriesProtocol>)itemAt:(unsigned int)index;

/**
 * Inserts series into the collection at specified position
 * @param item Item to insert into collection
 * @param index Position where series will be placed
 * @see SCIPieRenderableSeriesProtocol
 */
- (void)insert:(id <SCIPieRenderableSeriesProtocol>)item At:(int)index;

/**
 * Return first object from this instance of SCIRenderableSeriesCollection
 */
- (id <SCIPieRenderableSeriesProtocol>)firstObject;

/**
 * Checks whether series collection contains the series or not
 * @param item Item to check in collection
 * @see SCIPieRenderableSeriesProtocol
 */
- (BOOL)contains:(id <SCIPieRenderableSeriesProtocol>)item;

/**
 * Returns the index of the first occurrence of the specified renderable series in this collection.
 *
 * @return Returns the index of the first occurrence, otherwise returns -1.
 */
- (int)indexOf:(id <SCIPieRenderableSeriesProtocol>)item;

/**
 * Replaces the renderableSeries at the specified position in this collection with the specified element.
 *
 * @param series renderableSeries to be stored at the specified position
 * @param index index of the element to replace
 */
- (void)setSeries:(id <SCIPieRenderableSeriesProtocol>)series atIndex:(unsigned int)index;

@end

@interface SCIPieRenderableSeriesCollection (Indexing)

- (id <SCIPieRenderableSeriesProtocol>)objectAtIndexedSubscript:(unsigned int)idx;

- (void)setObject:(id <SCIPieRenderableSeriesProtocol>)obj atIndexedSubscript:(unsigned int)idx;

@end
/** @}*/
