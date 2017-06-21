//
//  TimeSpanAxisBase.h
//  SciChart
//
//  Created by Admin on 01.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAxisBase.h"

/**
 @brief Provides base functions for axes that represents date time values and provides tools for layout date time data in SciChart
 @see SCIAxisBase
 */
@interface SCITimeSpanAxisBase : SCIAxisBase

/**
 @brief Method creates visible range valid for SCITimeSpanAxisBase imlementation with provided min and max values
 @discussion Should be implemented in subclass
 @see SCIGenericType
 @see SCIRangeProtocol>
 */
-(id<SCIRangeProtocol>) toVisibleRangeMin:(SCIGenericType)min Max:(SCIGenericType)max;

@end

/** @}*/