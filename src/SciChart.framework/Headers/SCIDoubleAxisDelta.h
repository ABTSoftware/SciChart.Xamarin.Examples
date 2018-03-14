//
//  DoubleAxisDelta.h
//  SciChart
//
//  Created by Admin on 20.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIAxisDelta.h"

@interface SCIDoubleAxisDelta : NSObject <SCIAxisDeltaProtocol>

-(id) initWithMin:(double)min Max:(double)max;

-(SCIDoubleAxisDelta *) clone;

-(BOOL) equals:(id)object;

@end
