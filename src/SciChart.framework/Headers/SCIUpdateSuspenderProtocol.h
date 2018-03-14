//
//  SCIUpdateSuspenderProtocol.h
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
 * Defines the interface to an SCIUpdateSuspender, a disposable class which allows nested suspend/resume operations on an SCISuspendableProtocol instance
 */
@protocol SCIUpdateSuspenderProtocol <SCIDisposableProtocol>

/**
 * Gets a value indicating whether updates for this instance are currently suspended
 * @return True is this instance is suspended
 */
- (BOOL)isSuspended;

/**
 * Gets or sets a value indicating whether the target will resume when the SCIUpdateSuspenderProtocol is disposed. Default is YES.
 * @return If true then target will call -resumeUpdates: of SCISuspendableProtocol after the SCIUpdateSuspenderProtocol is disposed
 */
@property (nonatomic) BOOL resumeTargetOnClose;

@end

/**
 * @}
 */
