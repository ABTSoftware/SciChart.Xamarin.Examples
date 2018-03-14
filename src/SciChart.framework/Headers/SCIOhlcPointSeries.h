//
//  OhlcPointSeries.h
//  SciChart
//
//  Created by Admin on 23.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIPointSeries.h"

@interface SCIOhlcPointSeries : NSObject <SCIPointSeriesProtocol>

-(id)initWithSeriesOpen:(id<SCIPointSeriesProtocol>)open High:(id<SCIPointSeriesProtocol>)high Low:(id<SCIPointSeriesProtocol>)low Close:(id<SCIPointSeriesProtocol>)close;
-(id) initWithCapacity:(int)size;

-(SCIArrayController *) openValues;
-(SCIArrayController *) highValues;
-(SCIArrayController *) lowValues;
-(SCIArrayController *) closeValues;

-(id<SCIPointSeriesProtocol>)openPointSeries;
-(id<SCIPointSeriesProtocol>)highPointSeries;
-(id<SCIPointSeriesProtocol>)lowPointSeries;
-(id<SCIPointSeriesProtocol>)closePointSeries;

@end
