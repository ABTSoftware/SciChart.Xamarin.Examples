//
//  SCIDisposableBase.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 6/23/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Renderer
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIDisposableProtocol.h"

/**
 * Defines base class for disposable object.
 */
@interface SCIDisposableBase : NSObject <SCIDisposableProtocol>

/**
 * Helper method which checks if disposable is null before disposing.
 *
 * @param disposable The disposable instance.
 */
+ (void)tryToDispose:(nonnull id<SCIDisposableProtocol>)disposable;

/**
 * Helper method which disposes list of disposables.
 *
 * @param array The disposable list.
 */
+ (void)tryToDisposeArray:(nonnull NSArray<id<SCIDisposableProtocol>>*)array;

@end

/**
 * @}
 */
