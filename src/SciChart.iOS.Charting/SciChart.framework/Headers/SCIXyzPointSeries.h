//
//  XyzPointSeries.h
//  SciChart
//
//  Created by Yaroslav Pelyukh on 18.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//
#import <Foundation/Foundation.h>
#import "SCIPointSeries.h"

@interface SCIXyzPointSeries: NSObject <SCIPointSeriesProtocol>

-(id)initWithSeriesXY:(id<SCIPointSeriesProtocol>) xy
                   XZ:(id<SCIPointSeriesProtocol>) xz;

-(SCIArrayController *) zValues;

@end
