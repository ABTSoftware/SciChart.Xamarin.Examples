//
//  SCIPenLinearGradient.h
//  SciChart
//
//  Created by Admin on 23.10.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIPen2D.h"
#import "SCILinearGradientBrush.h"

@protocol SCIRenderPassDataProtocol;

/**
 @brief Pen with stroke thickness and gradient color
 @see SCIPen2DProtocol
 @see SCILinearGradientBrushProtocol
 */
@interface SCIPenLinearGradient : NSObject <SCIPen2DProtocol, SCILinearGradientBrushProtocol>

/**
 @brief Constructor creates gradient pen with given gradient start and finish colors, gradient direction and pen stroke width
 @code
 let pen = SCIPenLinearGradient(colorStart: UIColor.redColor(), finish: UIColor.blueColor(), direction: .Vertical, width: 1.5)
 @endcodde
 @see SCILinearGradientDirection
 */
-(id) initWithColorStart:(UIColor *)colorStart Finish:(UIColor *)colorFinish Direction:(SCILinearGradientDirection)direction Width:(float)width;
/**
 @brief Constructor creates gradient pen with given gradient start and finish color codes, gradient direction and pen stroke width. Color code bytes order is 0xAABBGGRR
 @code
 let pen = SCIPenLinearGradient(colorCodeStart: 0xFF0000FF, finish: 0xFFFF0000, direction: .Horizontal, width: 1.5)
 @endcode
 @see SCILinearGradientDirection
 */
-(id) initWithColorCodeStart:(unsigned int)colorStart Finish:(unsigned int)colorFinish Direction:(SCILinearGradientDirection)direction Width:(float)width;

/**
 @brief Constructor creates gradient pen with given gradient data and pen stroke width.
 @param coords Float array of positions of gradient color from 0 to 1. Array length should be equal to count parameter
 @param colors unsigned int array of gradient color codes. Array length should be equal to count parameter. Color code bytes order is 0xAABBGGRR
 @param count length of coords and colors arrays
 @param direction gradient direction
 @param width stroke thickness
 @code
 var gradient: Array<Float> = [0.0, 0.4, 0.7, 1.0]
 var colors: Array<UInt32> = [0xFF404040, 0xFF404040, 0xFFFFFF00, 0xFFFF0000]
 let pen = SCIPenLinearGradient(gradientCoords: &gradient, colors: &colors, count: 4, direction: .Vertical, width: 1.5)
 @endcode
 @see SCILinearGradientDirection
 */
-(instancetype)initWithGradientCoords:(float*)coords Colors:(uint*)colors Count:(int)count
                            Direction:(SCILinearGradientDirection)direction Width:(float)width;

@end