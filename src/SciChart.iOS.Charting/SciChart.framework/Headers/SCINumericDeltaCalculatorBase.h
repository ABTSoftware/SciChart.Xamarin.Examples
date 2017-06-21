//
//  NumericDeltaCalculatorBase.h
//  SciChart
//
//  Created by Admin on 21.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIDeltaCalculator.h"

@protocol SCINiceScaleProtocol;

@interface SCINumericDeltaCalculatorBase : NSObject <SCIDeltaCalculatorProtocol>

-(id<SCINiceScaleProtocol>) getScaleWithMin:(double)min Max:(double)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;

@end
