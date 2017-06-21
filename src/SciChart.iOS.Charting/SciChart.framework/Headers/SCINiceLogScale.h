//
//  NiceLogScale.h
//  SciChart
//
//  Created by Admin on 15.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCINiceDoubleScale.h"

@interface SCINiceLogScale : SCINiceDoubleScale

-(id) initWithMin:(double)min Max:(double)max LogBase:(double)logBase MinorsPerMajor:(int)minorsPerMajor MaxTicks:(int)maxTicks;

@end
