//
//  NiceTimeSpanScale.h
//  SciChart
//
//  Created by Admin on 05.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>

@class SCIDoubleRange;

@interface SCINiceTimeSpanScale : NSObject

-(instancetype)initWithMin:(NSTimeInterval) min Max:(NSTimeInterval)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;
-(SCIDoubleRange*) tickSpacing;
-(SCIDoubleRange*) niceRange;

@end
