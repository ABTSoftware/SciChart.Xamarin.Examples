//
//  SCILanierGradientPenStyle.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 2/17/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import "SCIPenStyle.h"
#import "SCILinearGradientEnum.h"

@interface SCILinearGradientPenStyle : SCIPenStyle

@property (nonatomic, nonnull) NSArray<UIColor *> *colors;
@property (nonatomic, nonnull) NSArray<NSNumber *> *stops;
@property (nonatomic) SCILinearGradientDirection direction;
@property (nonatomic, nonnull, readonly) UIColor *color;
@property (nonatomic, readonly) unsigned int colorCode;

/**
 @brief Constructor creates gradient pen with given gradient start and finish colors, gradient direction and pen stroke width
 @code
 let pen = SCIPenLinearGradient(colorStart: UIColor.redColor(), finish: UIColor.blueColor(), direction: .Vertical, width: 1.5)
 @endcodde
 @see SCILinearGradientDirection
 */
- (nonnull instancetype)initWithColorStart:(nonnull UIColor *)colorStart
                                    finish:(nonnull UIColor *)colorFinish
                                 direction:(SCILinearGradientDirection)direction
                                 thickness:(float)thickness;
/**
 @brief Constructor creates gradient pen with given gradient start and finish color codes, gradient direction and pen stroke width. Color code bytes order is 0xAARRGGBB
 @code
 let pen = SCIPenLinearGradient(colorCodeStart: 0xFF0000FF, finish: 0xFFFF0000, direction: .Horizontal, width: 1.5)
 @endcode
 @see SCILinearGradientDirection
 */
- (nonnull instancetype)initWithColorCodeStart:(unsigned int)colorStart
                                        finish:(unsigned int)colorFinish
                                     direction:(SCILinearGradientDirection)direction
                                     thickness:(float)thickness;

/**
 @brief Constructor creates gradient pen with given gradient data and pen stroke width.
 @param stops Float array of positions of gradient color from 0 to 1. Array length should be equal to count parameter
 @param colors unsigned int array of gradient color codes. Array length should be equal to count parameter. Color code bytes order is 0xAABBGGRR
 @param count length of coords and colors arrays
 @param direction gradient direction
 @param thickness stroke thickness
 @code
 var gradient: Array<Float> = [0.0, 0.4, 0.7, 1.0]
 var colors: Array<UInt32> = [0xFF404040, 0xFF404040, 0xFFFFFF00, 0xFFFF0000]
 let pen = SCIPenLinearGradient(gradientCoords: &gradient, colors: &colors, count: 4, direction: .Vertical, width: 1.5)
 @endcode
 @see SCILinearGradientDirection
 */
- (nonnull instancetype)initWithGradientStops:(nonnull float*)stops
                                       colors:(nonnull uint*)colors
                                        count:(int)count
                                    direction:(SCILinearGradientDirection)direction
                                    thickness:(float)thickness;

@end
