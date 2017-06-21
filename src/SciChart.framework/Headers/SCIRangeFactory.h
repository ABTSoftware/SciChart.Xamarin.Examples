//
//  RangeFactory.h
//  SciChart
//
//  Created by Admin on 09.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Ranges
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRangeProtocol.h"
#import "SCIGenericType.h"
#import "SCIDataType.h"

@interface SCIRangeFactory : NSObject

+(id<SCIRangeProtocol>) clone:(id<SCIRangeProtocol>)originalRange WithMin:(SCIGenericType)min Max:(SCIGenericType)max Limit:(id<SCIRangeProtocol>)rangeLimit;
+(id<SCIRangeProtocol>) clone:(id<SCIRangeProtocol>)originalRange WithMin:(SCIGenericType)min Max:(SCIGenericType)max;
+(id<SCIRangeProtocol>) getRangeOfType:(SCIDataType)type Min:(SCIGenericType)min Max:(SCIGenericType)max;
+(id<SCIRangeProtocol>) getRangeWithRangeType:(Class)type Min:(SCIGenericType)min Max:(SCIGenericType)max;

@end

/** @}*/
