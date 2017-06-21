//
//  SCINiceScale.h
//  SciChart
//
//  Created by Admin on 21.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

@class SCIDoubleAxisDelta;

@protocol SCINiceScaleProtocol <NSObject>

-(SCIDoubleAxisDelta*) tickSpacing;
-(void) calculateDelta;

@end
