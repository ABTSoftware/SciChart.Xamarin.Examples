//
//  SCISuspendableProtocol.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 6/23/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Renderer
 *  @{
 */

#import <Foundation/Foundation.h>

@protocol SCIUpdateSuspenderProtocol;

/**
 * Classes which implement SCISuspendableProtocol can have updates suspended/resumed. Useful for batch operations
 */
@protocol SCISuspendableProtocol

/**
 * Gets a value indicating whether updates for the target are currently suspended
 * @return True if this instance is suspended
 */
- (BOOL)isSuspended;

/**
 * Suspends drawing updated on the target until the returned object is disposed, when a final draw call will be issued
 * @return SCIUpdateSuspenderProtocol instance which suspends updated until it will be disposed
 */
- (nonnull id<SCIUpdateSuspenderProtocol>)suspendUpdates;

/**
 * Resumes updates on the target, intended to e called by IUpdateSuspender
 * @param suspender SCIUpdateSuspenderProtocol instance which was created by -suspendUpdates: call
 */
- (void)resumeUpdates:(nonnull id<SCIUpdateSuspenderProtocol>)suspender;

/**
 * Called by SCIUpdateSuspenderProtocol each time a target suspender is disposed. When the final target suspender has been disposed
 */
- (void)decrementSuspend;

@end
/**
 * @}
 */
