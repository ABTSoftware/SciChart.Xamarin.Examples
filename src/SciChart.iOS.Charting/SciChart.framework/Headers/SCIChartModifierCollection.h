//
//  SCIModifierGroup.h
//  SciChart
//
//  Created by Admin on 05.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIObservableCollection.h"

@protocol SCIChartModifierProtocol;

@interface SCIChartModifierCollection : SCIObservableCollection

/**
 * @brief Provides default initialization of the current modifier group with an array of modifiers
 * @code
 let modifiers = SCIChartModifierCollection(childmodifiers: [modifier])
 
 chartSurface.chartModifiers = modifierCollection
 * @endcode
 */
- (nonnull instancetype)initWithChildModifiers:(NSArray<id <SCIChartModifierProtocol>> *_Nonnull)childModifiers;

/**
 * @brief Returns SCIChartModifierCollection from the current modifier group by modifier name
 */
- (id <SCIChartModifierProtocol> _Nullable)itemByName:(NSString *_Nonnull)name;

/**
 * @brief Adds modifier into the current modifier group
 * @code
 chartModifierCollection.add(modifier)
 * @endcode
 */
- (void)add:(id <SCIChartModifierProtocol> _Nonnull)item;

/**
 * Removes the modifier instance from this collection.
 *
 * @param item Modifier instance to be deleted from the collection, if present in it.
 * @return Return YES If item is removed, otherwise NO
*/
- (BOOL)remove:(id <SCIChartModifierProtocol> _Nonnull)item;

/**
 * @brief Returns SCIChartModifierProtocol from the current modifier group by modifier index in group
 */
- (id <SCIChartModifierProtocol> _Nullable)itemAt:(int)index;

/** 
 * Insert modifier into SCIChartModifierCollection at Index.
 */
- (void)insert:(id <SCIChartModifierProtocol> _Nonnull)item At:(int)index;

/** 
 * Return first object from SCIChartModifierCollection
 */
- (id <SCIChartModifierProtocol> _Nullable)firstObject;

/** 
 * Return YES If item is in collection.
 */
- (BOOL)contains:(id <SCIChartModifierProtocol> _Nonnull)item;

/**
 * Returns the index of the first occurrence of the specified modifier in this collection.
 *
 * @return Returns the index of the first occurrence, otherwise returns -1.
 */
- (int)indexOf:(id <SCIChartModifierProtocol> _Nonnull)item;

/**
 * Replaces the modifier at the specified position in this collection with the specified element.
 *
 * @param modifier axis to be stored at the specified position
 * @param index index of the element to replace
 */
- (void)setModifier:(id <SCIChartModifierProtocol> _Nonnull)modifier atIndex:(unsigned int)index;

/**
 * @brief if set to true gesture is handled only by one modifier.
 * @discussion Gesture considered handled if modifier returns true from onTapGesture:At: onPanGetsure:At: and oher handler methods from SCIGestureEventsHandler
 * @see SCIGestureEventsHandler
 */
@property(nonatomic) BOOL handleGestureFirstOnly;

@end

@interface SCIChartModifierCollection (Indexing)

- (id <SCIChartModifierProtocol> _Nullable)objectAtIndexedSubscript:(unsigned int)idx;

- (void)setObject:(id <SCIChartModifierProtocol> _Nonnull)obj atIndexedSubscript:(unsigned int)idx;

@end

/** @}*/
