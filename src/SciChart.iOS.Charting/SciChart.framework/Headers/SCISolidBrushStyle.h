//
//  SCISolidBrushStyle.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 2/19/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import "SCIBrushStyle.h"

@interface SCISolidBrushStyle : SCIBrushStyle

- (nonnull instancetype)initWithColorCode:(unsigned int)colorCode;

- (nonnull instancetype)initWithColor:(nonnull UIColor*)color;

@end
