//
//  LogarithmicNumericAxis.h
//  SciChart
//
//  Created by Admin on 14.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCINumericAxis.h"
#import "SCILogarithmicAxis.h"

/**
 @brief Axis with logarithmic scaling that represents numeric values and provides tools for layout numeric data in SciChart with logarithmic scaling
 @see SCIAxisBase
 */
@interface SCILogarithmicNumericAxis : SCINumericAxis <SCILogarithmicAxisProtocol>

@end

/** @}*/