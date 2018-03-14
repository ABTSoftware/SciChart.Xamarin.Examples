//
//  NiceDoubleScale.h
//  SciChart
//
//  Created by Admin on 21.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCINiceScale.h"

@class SCIDoubleAxisDelta;
@class SCIDoubleRange;

@interface SCINiceDoubleScale : NSObject <SCINiceScaleProtocol> {
@protected
    int _minorsPerMajor;
    double _minDelta;
    double _maxDelta;
    SCIDoubleRange * _niceRange;
    uint _maxTicks;
}

-(id) initWithMin:(double)min Max:(double)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(int)maxTicks;

-(SCIDoubleRange*) niceRange;

-(double) niceNumWithRange:(double)range Round:(BOOL)round;

@end
