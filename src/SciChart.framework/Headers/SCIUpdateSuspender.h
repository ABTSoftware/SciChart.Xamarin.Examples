//
//  SCIUpdateSuspender.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 6/23/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Renderer
 *  @{
 */

#import "SCIDisposableBase.h"
#import "SCIUpdateSuspenderProtocol.h"

@protocol SCISuspendableProtocol;

typedef void(^SCIRunnableBlock)();

/**
 * A disposable class which allows nested suspend/resume operations on an SCISuspendableProtocol target
 * @see SCISuspendableProtocol
 */
@interface SCIUpdateSuspender : SCIDisposableBase <SCIUpdateSuspenderProtocol>

/**
 * Initializes a new instance of the SCIUpdateSuspender class.
 * @param target The target instance
 */
- (nonnull instancetype)initWithTarget:(nonnull id<SCISuspendableProtocol>)target;

/**
 * Gets a value indicating whether updates for this instance are currently suspended
 * @return List of suspended instances.
 */
+ (nonnull NSMapTable<id<SCISuspendableProtocol>, NSNumber*> *)suspendedInstances;

/**
 * Helper method which suspend updates on target instance while runnable is executing
 * @param suspendable The {@link ISuspendable} which need to suspend before running runnable
 * @param runnable The SCIRunnableBlock to run code of changing state of target is suspended
 */
+ (void)usingWithSuspendable:(nonnull id<SCISuspendableProtocol>)suspendable withBlock:(nonnull SCIRunnableBlock)block;

/**
 * Gets a value indicating whether updates for this instance are currently suspended
 * @param target Target to check
 * @return True if target's updates are suspended
 */
+ (BOOL)isTargetSuspended:(nonnull id<SCISuspendableProtocol>)target;

@end

/**
 * @}
 */
