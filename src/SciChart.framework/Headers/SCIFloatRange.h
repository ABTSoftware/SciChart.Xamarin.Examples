//
//  SCIFloatRange.h
//  SciChart
//
//  Created by Admin on 08.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Ranges
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRangeProtocol.h"

/**
 @brief Numeric float range
 @see SCIRangeProtocol
 */
@interface SCIFloatRange : NSObject <SCIRangeProtocol>

/**
 @brief Float range constructor with min and max values. Min and max internaly stored as float
 @param min SCIGenericType min value
 @param max SCIGenericType max value
 @see SCIGenericType
 @code
 let range = SCIFloatRange(min: SCIGeneric(0), max: SCIGeneric(10))
 @endcode
 */
-(id) initWithMin:(SCIGenericType)min Max:(SCIGenericType)max;

@end

/** @}*/
