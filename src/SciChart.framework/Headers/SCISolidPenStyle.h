//
//  SCISolidPenStyle.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 2/17/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import "SCIPenStyle.h"
//#import "SCIRenderContext2D.h"

@interface SCISolidPenStyle : SCIPenStyle

- (nonnull instancetype)initWithColor:(nonnull UIColor*)color
                        withThickness:(float)thickness
                        andStrokeDash:(nonnull NSArray<NSNumber*>*)strokeDashArray;

- (nonnull instancetype)initWithColor:(nonnull UIColor*)color
                        withThickness:(float)thickness;

- (nonnull instancetype)initWithColorCode:(unsigned int)colorCode
                            withThickness:(float)thickness;

- (nonnull instancetype)initWithColorCode:(unsigned int)colorCode
                            withThickness:(float)thickness
                            andStrokeDash:(nonnull NSArray<NSNumber*>*)strokeDashArray;

@end
