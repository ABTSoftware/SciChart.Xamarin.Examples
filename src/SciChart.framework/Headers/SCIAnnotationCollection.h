//
//  SCIAnnotationGroup.h
//  SciChart
//
//  Created by Admin on 29.03.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Annotations
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIObservableCollection.h"
#import "SCIAnnotationProtocol.h"

/**
 * @brief Provides a class for annotation group to be rendered over the chart
 * @discussion Is used when there is a need to have multiple annotations
 */
@interface SCIAnnotationCollection : SCIObservableCollection

/**
 * @brief Provides default initialization of the current annotation group with an array of annotations
 * @code
 let annotationGroup = SCIAnnotationGroup(childAnnotations: [boxBlue, boxRed, lineAnnotationRelative, xMarker, yMarker])
 
 chartSurface.annotation = annotationGroup
 * @endcode
 */
- (id)initWithChildAnnotations:(NSArray<id <SCIAnnotationProtocol>> *)childAnnotations;

/**
 * @brief Returns SCIAnnotation from the current annotation group by annotation name
 */
- (id <SCIAnnotationProtocol>)itemByName:(NSString *)name;

/**
 * @brief Adds annotation into the current annotation group
 * @code
 annotationGroup.addItem(textAnnotation)
 * @endcode
 */
- (void)add:(id <SCIAnnotationProtocol>)item;

/**
 * Removes the annotation instance from this collection.
 *
 * @param item Annotation instance to be deleted from the collection, if present in it.
 * @return Return YES If item is removed, otherwise NO
 */
- (BOOL)remove:(id <SCIAnnotationProtocol>)item;

/**
 * @brief Returns SCIAnnotation from the current annotation group by annotation index in group
 */
- (id <SCIAnnotationProtocol>)itemAt:(int)index;

/**
 * Insert annotation into SCIAnnotationCollection at Index.
 */
- (void)insert:(id <SCIAnnotationProtocol>)item At:(int)index;

/**
 * Return first object from SCIAnnotationCollection
 */
- (id <SCIAnnotationProtocol>)firstObject;

/**
 * Return YES If item is in collection.
 */
- (BOOL)contains:(id <SCIAnnotationProtocol>)item;

/**
 * Returns the index of the first occurrence of the specified annotation in this collection.
 *
 * @return Returns the index of the first occurrence, otherwise returns -1.
 */
- (int)indexOf:(id <SCIAnnotationProtocol>)item;

/**
 * Replaces the annotation at the specified position in this collection with the specified element.
 *
 * @param annotation annotation to be stored at the specified position
 * @param index index of the element to replace
 */
- (void)setAnnotation:(id <SCIAnnotationProtocol>)annotation atIndex:(unsigned int)index;

/**
 * @brief if set to true gesture is handled only by one annotation.
 * @discussion Gesture considered handled if annotation returns true from onTapGesture:At: onPanGetsure:At: and oher handler methods from SCIGestureEventsHandler
 * @see SCIGestureEventsHandler
 */
@property(nonatomic) BOOL handleGestureFirstOnly;

@end

@interface SCIAnnotationCollection (Indexing)

- (id <SCIAnnotationProtocol>)objectAtIndexedSubscript:(unsigned int)idx;

- (void)setObject:(id <SCIAnnotationProtocol>)obj atIndexedSubscript:(unsigned int)idx;

@end

/** @}*/
