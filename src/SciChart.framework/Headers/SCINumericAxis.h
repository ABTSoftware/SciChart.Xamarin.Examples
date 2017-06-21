//
//  NumericAxis.h
//  SciChart
//
//  Created by Admin on 15.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAxisBase.h"

/**
 @brief Axis that represents numeric values and provides tools for layout numeric data in SciChart
 @see SCIAxisBase
 */
@interface SCINumericAxis : SCIAxisBase

/**
 @brief Gets or sets axis label number formatter
 @discussion If value is not set labels are formated with textFormatting
 */
@property (nonatomic) NSNumberFormatter *numberFormatter;

@end

/** @}*/