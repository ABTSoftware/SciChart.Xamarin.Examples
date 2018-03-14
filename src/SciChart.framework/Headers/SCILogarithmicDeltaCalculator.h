//
//  LogarithmicDeltaCalculator.h
//  SciChart
//
//  Created by Admin on 15.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCINumericDeltaCalculatorBase.h"

@interface SCILogarithmicDeltaCalculator : SCINumericDeltaCalculatorBase

+(SCINumericDeltaCalculatorBase*) instance;

@property (nonatomic) double logarithmicBase;

@end
