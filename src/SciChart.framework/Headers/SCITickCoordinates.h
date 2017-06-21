//
//  TickCoordinates.h
//  SciChart
//
//  Created by Admin on 13.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SCITickCoordinates : NSObject

-(id) initWithMinorTicks:(double*)minorTicks Count:(int)minorTicksCount
              MajorTicks:(double*)majorTicks Count:(int)majorTicksCount
   MinorTicksCoordinates:(float*)minorTickCoord Count:(int)minorTickCoordCount
   MajorTicksCoordinates:(float*)majorTickCoord Count:(int)majorTickCoordCount;
-(BOOL) isEmpty;
-(void) getMinorTicks:(double**)ticks Count:(int*)count;
-(void) getMajorTicks:(double**)ticks Count:(int*)count;
-(void) getMinorTickCoordinates:(float**)ticks Count:(int*)count;
-(void) getMajorTickCoordinates:(float**)ticks Count:(int*)count;

@end
