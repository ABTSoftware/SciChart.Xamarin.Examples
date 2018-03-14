//
//  SCIDateRange.h
//  SciChart
//
//  Created by Admin on 21.09.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Ranges
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRangeProtocol.h"

/**
 @brief Date time range
 @see SCIRangeProtocol
 */
@interface SCIDateRange : NSObject <SCIRangeProtocol>

/**
 @brief Date time range constructor with min and max values. Min and max internaly stored as NSDate
 @param min SCIGenericType min value
 @param max SCIGenericType max value
 @see SCIGenericType
 @code
 let range = SCIDateRange(min: SCIGeneric(NSDate()), max: SCIGeneric(NSDate()))
 @endcode
 */
-(id) initWithMin:(SCIGenericType)min Max:(SCIGenericType)max;
/**
 @brief Date time range constructor with min and max values. Min and max internaly stored as NSDate
 @param min NSDate min value
 @param max NSDate max value
 @code
 let range = SCIDateRange(dateMin: NSDate(), max: NSDate())
 @endcode
 */
-(id) initWithDateMin:(NSDate*)min Max:(NSDate*)max;

@end

/** @}*/
