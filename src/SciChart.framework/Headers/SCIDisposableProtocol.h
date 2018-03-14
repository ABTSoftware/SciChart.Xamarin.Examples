//
//  SCIDisposableProtocol.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 6/23/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Renderer
 *  @{
 */

#import <Foundation/Foundation.h>

/**
 * Classes which implement SCIDisposableProtocol interface can be disposed
 */
@protocol SCIDisposableProtocol <NSObject>

/**
 * Releases all allocated resources
 */
- (void)dispose;

@end

/**
 * @}
 */
