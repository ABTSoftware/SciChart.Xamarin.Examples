//
//  SCIDateDeltaCalculator.h
//  SciChart
//
//  Created by Admin on 01.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import "SCIDeltaCalculator.h"
@class SCITimeSpanDelta;

@protocol SCIDateDeltaCalculatorProtocol <SCIDeltaCalculatorProtocol>

-(SCITimeSpanDelta*) getDeltaFromRangeMin:(SCIGenericType)min Max:(SCIGenericType)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;

@end
