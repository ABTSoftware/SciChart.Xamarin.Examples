//
//  SCICollectionChangedEventArgs.h
//  SciChart
//
//  Created by Admin on 30/01/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * Defines an enumeration with collection changed types
 */
typedef NS_ENUM(NSUInteger, SCICollectionChangedAction) {
    /**
     * Add one or more items from collection
     */
    SCICollectionChangedAction_Add,

    /**
     * Remove one or more items from collection
     */
    SCICollectionChangedAction_Remove,

    /**
     * Replace one or more items in collection
     */
    SCICollectionChangedAction_Replace,

    /**
     * Reset the content of collection
     */
    SCICollectionChangedAction_Reset
};

@class SCICollectionChangedEventArgs;

typedef void (^SCICollectionChangedCallback) (SCICollectionChangedEventArgs *);

@interface SCICollectionChangedEventArgs : NSObject

/**
 * Gets the list of new items involved in the change.
 */
@property (nonatomic, strong) NSArray * addedItems;

/**
 * Gets the old items which were removed or replaced in this change
 */
@property (nonatomic, strong) NSArray * removedItems;

/**
 * Gets the index at which the change occurred.
 */
@property (nonatomic) int addedIndex;

/**
 * Gets the index at which the change occurred.
 */
@property (nonatomic) int removedIndex;

/**
 * Gets the action that caused the event.
 */
@property (nonatomic) SCICollectionChangedAction action;

-(id) initWithAction:(SCICollectionChangedAction)action RemovedItems:(NSArray*)removedItems RemovedIndex:(int)removedIndex AddedItems:(NSArray*)addedItems AddedIndex:(int)addedIndex;

@end
