//
//  SCIDeltaCalculator.h
//  SciChart
//
//  Created by Admin on 13.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

@protocol SCIAxisDeltaProtocol;
#import "SCIGenericType.h"

@protocol SCIDeltaCalculatorProtocol <NSObject>

-(id<SCIAxisDeltaProtocol>) getDeltaFromRangeMin:(SCIGenericType)min Max:(SCIGenericType)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;

@end
