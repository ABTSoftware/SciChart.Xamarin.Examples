//
//  SCILogarithmicCoordinateCalculator.h
//  SciChart
//
//  Created by Admin on 15.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup CoordinateCalculators
 *  @{
 */

#import "SCICoordinateCalculatorProtocol.h"

/**
 @extends SCICoordinateCalculatorProtocol
 */
@protocol SCILogarithmicCoordinateCalculatorProtocol ///
<SCICoordinateCalculatorProtocol>
/** @{ @} */

-(double) logarithmicBase;

@end

/** @}*/