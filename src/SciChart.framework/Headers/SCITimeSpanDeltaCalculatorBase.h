//
//  TimeSpanDeltaCalculatorBase.h
//  SciChart
//
//  Created by Admin on 05.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIDateDeltaCalculator.h"

@interface SCITimeSpanDeltaCalculatorBase : NSObject <SCIDateDeltaCalculatorProtocol>

-(double) getTicks:(SCIGenericType)value;

@end
