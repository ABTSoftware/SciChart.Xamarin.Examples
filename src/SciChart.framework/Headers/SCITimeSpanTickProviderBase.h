//
//  TimeSpanTickProviderBase.h
//  SciChart
//
//  Created by Admin on 01.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCITickProvider.h"

@interface SCITimeSpanTickProviderBase : NSObject <SCITickProviderProtocol>

-(double) roundUp:(double)current Delta:(double)delta;
-(BOOL) isAdditionValid:(double)current Delta:(double)delta;
-(double) addDelta:(double)current Delta:(double)delta;
-(BOOL) isDateDivisible:(double)current ByDelta:(double)delta;

@end
