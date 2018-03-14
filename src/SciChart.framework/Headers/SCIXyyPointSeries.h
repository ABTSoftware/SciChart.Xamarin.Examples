//
//  XyyPointSeries.h
//  SciChart
//
//  Created by Admin on 16.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIPointSeries.h"

@interface SCIXyyPointSeries : NSObject <SCIPointSeriesProtocol>

-(id)initWithSeriesY1:(id<SCIPointSeriesProtocol>)y1 Y2:(id<SCIPointSeriesProtocol>)y2;

-(SCIArrayController *) y1Values;
-(SCIArrayController *) y2Values;

@end
