//
//  SCICategoryArrayController.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 7/8/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <SciChart/SciChart.h>

/**
 * The class is used by category DataSeries. All methods which return data are overrided. And they return data of indecies not of values. Chart is drawn based on indecies.
 */
@interface SCICategoryArrayController : SCIArrayController

/**
 * @brief Get value at index of category. The method is used by SCICategoryDateTimeAxis, SCICategoryDateTimeLabelProvider, SCICategoryDateTimeTickProvider, SCICategoryNumericAxis, SCICategoryNumericLabelProvider, SCICategoryNumericTickProvider.
 * @discussion The classes responsible for drawing values on Axis, so they need values, not indecies.
 * @see SCICategoryDateTimeAxis
 * @see SCICategoryDateTimeLabelProvider
 * @see SCICategoryDateTimeTickProvider
 * @see SCICategoryNumericAxis
 * @see SCICategoryNumericLabelProvider
 * @see SCICategoryNumericTickProvider
 */
- (SCIGenericType)getCategoryValueAtIndex:(int)index;

@end

/** @}*/
