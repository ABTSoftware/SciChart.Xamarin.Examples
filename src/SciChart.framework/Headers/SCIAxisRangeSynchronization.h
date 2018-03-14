//
//  SCIAxisRangeSyncronization.h
//  SciChart
//
//  Created by Admin on 15/07/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>

@protocol SCIAxis2DProtocol;

@interface SCIAxisRangeSynchronization : NSObject

-(void) attachAxis:(id<SCIAxis2DProtocol>)axis;
-(void) detachAxis:(id<SCIAxis2DProtocol>)axis;

@end

/** @}*/
