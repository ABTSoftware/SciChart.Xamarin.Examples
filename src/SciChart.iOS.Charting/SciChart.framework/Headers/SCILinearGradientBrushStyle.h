//
//  SCILinearGradientBrushStyle.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 2/19/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import "SCIBrushStyle.h"
#import "SCILinearGradientEnum.h"

@interface SCILinearGradientBrushStyle : SCIBrushStyle

@property (nonatomic, nonnull) NSArray<UIColor *> *colors;
@property (nonatomic, nonnull) NSArray<NSNumber *> *stops;
@property (nonatomic) SCILinearGradientDirection direction;
@property (nonatomic, nonnull, readonly) UIColor *color;
@property (nonatomic, readonly) unsigned int colorCode;

- (nonnull instancetype)initWithColorStart:(nonnull UIColor *)colorStart
                                    finish:(nonnull UIColor *)colorFinish
                                 direction:(SCILinearGradientDirection)direction;

- (nonnull instancetype)initWithColorCodeStart:(uint)colorStart
                                        finish:(uint)colorFinish
                                     direction:(SCILinearGradientDirection)direction;

- (nonnull instancetype)initWithGradientStops:(nonnull float*)stops
                                       colors:(nonnull uint*)colors
                                        count:(int)count
                                    direction:(SCILinearGradientDirection)direction;

@end
