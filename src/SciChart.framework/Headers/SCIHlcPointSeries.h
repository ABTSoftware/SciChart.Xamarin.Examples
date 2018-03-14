//
//  SCIHlcPointSeries.h
//  SciChart
//
//  Created by Yaroslav Pelyukh on 3/16/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIPointSeries.h"

@interface SCIHlcPointSeries : NSObject <SCIPointSeriesProtocol>

-(id)initWithSeriesHigh:(id<SCIPointSeriesProtocol>)high Low:(id<SCIPointSeriesProtocol>)low Close:(id<SCIPointSeriesProtocol>)close;
-(id) initWithCapacity:(int)size;

-(SCIArrayController *) highValues;
-(SCIArrayController *) lowValues;

-(id<SCIPointSeriesProtocol>)highPointSeries;
-(id<SCIPointSeriesProtocol>)lowPointSeries;
-(id<SCIPointSeriesProtocol>)closePointSeries;

@end
