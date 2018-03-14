//
//  SCIRadialGradientBrushStyle.h
//  SciChart
//
//  Created by Admin on 10/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIBrushStyle.h"
#import <QuartzCore/QuartzCore.h>

@interface SCIRadialGradientBrushStyle : SCIBrushStyle

@property (nonatomic, nonnull) NSArray<UIColor *> *colors;
@property (nonatomic, nonnull) NSArray<NSNumber *> *stops;
@property (nonatomic, nonnull, readonly) UIColor *color;
@property (nonatomic, readonly) unsigned int colorCode;
@property (nonatomic) CGPoint center;

- (nonnull instancetype)initWithColorStart:(nonnull UIColor *)colorStart
                                    finish:(nonnull UIColor *)colorFinish;

- (nonnull instancetype)initWithColorCodeStart:(uint)colorStart
                                        finish:(uint)colorFinish;

- (nonnull instancetype)initWithGradientStops:(nonnull float*)stops
                                       colors:(nonnull uint*)colors
                                        count:(int)count;

- (nonnull instancetype)initWithCenter:(CGPoint)center
                            colorStart:(nonnull UIColor *)colorStart
                                finish:(nonnull UIColor *)colorFinish;

- (nonnull instancetype)initWithCenter:(CGPoint)center
                        colorCodeStart:(uint)colorStart
                                finish:(uint)colorFinish;

- (nonnull instancetype)initWithCenter:(CGPoint)center
                         gradientStops:(nonnull float*)stops
                                colors:(nonnull uint*)colors
                                 count:(int)count;

@end
