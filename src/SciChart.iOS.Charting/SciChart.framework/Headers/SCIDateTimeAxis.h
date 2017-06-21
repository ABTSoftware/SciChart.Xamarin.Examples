//
//  DateTimeAxis.h
//  SciChart
//
//  Created by Admin on 01.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCITimeSpanAxisBase.h"

/**
 @brief Axis that represents date time values and provides tools for layout date time data in SciChart
 @see SCITimeSpanAxisBase
 */
@interface SCIDateTimeAxis : SCITimeSpanAxisBase

/**
 @brief Set axis lsbel formatting when visible range is less than one day. Values are formatted with NSDateFormatter
 */
@property (nonatomic, copy) NSString * subDayTextFormatting;
/**
 @brief Set axis lsbel formatting when visible range is less than one year. Values are formatted with NSDateFormatter
 */
@property (nonatomic, copy) NSString * subYearTextFormatting;
/**
 @brief Set axis lsbel formatting when visible range is more than one day. Values are formatted with NSDateFormatter
 */
@property (nonatomic, copy) NSString * decadesTextFormatting;

@end

/** @}*/