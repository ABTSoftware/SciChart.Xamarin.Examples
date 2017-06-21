//
//  SCIBrushLinearGradient.h
//  SciChart
//
//  Created by Admin on 07.10.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIBrush2D.h"
#import "SCILinearGradientBrush.h"

@protocol SCIRenderPassDataProtocol;

/**
 @brief Brush with gradient fill color
 @see SCIBrush2DProtocol
 @see SCILinearGradientBrushProtocol
 */
@interface SCIBrushLinearGradient : NSObject <SCIBrush2DProtocol, SCILinearGradientBrushProtocol>

/**
 @brief Constructor creates gradient brush with given gradient direction, gradient start and finish colors
 @code
 let brush = SCIBrushLinearGradient(colorStart: UIColor.redColor(), finish: UIColor.blueColor(), direction: .Vertical)
 @endcodde
 @see SCILinearGradientDirection
 */
-(id) initWithColorStart:(UIColor*)startColor Finish:(UIColor*)finishColor Direction:(SCILinearGradientDirection)gradientDirection;
/**
 @brief Constructor creates gradient brush with given gradient direction, gradient start and finish color codes. Color code bytes order is 0xAABBGGRR
 @code
 let brush = SCIBrushLinearGradient(colorCodeStart: 0xFF0000FF, finish: 0xFFFF0000, direction: .Horizontal)
 @endcode
 @see SCILinearGradientDirection
 */
-(id) initWithColorCodeStart:(uint)startColor Finish:(uint)finishColor Direction:(SCILinearGradientDirection)gradientDirection;

/**
 @brief Constructor creates gradient brush with given gradient data
 @param coords Float array of positions of gradient color from 0 to 1. Array length should be equal to count parameter
 @param colors unsigned int array of gradient color codes. Array length should be equal to count parameter. Color code bytes order is 0xAABBGGRR
 @param count length of coords and colors arrays
 @param direction gradient direction
 @code
 var gradient: Array<Float> = [0.0, 0.4, 0.7, 1.0]
 var colors: Array<UInt32> = [0xFF404040, 0xFF404040, 0xFFFFFF00, 0xFFFF0000]
 let brush = SCIBrushLinearGradient(gradientCoords: &gradient, colors: &colors, count: 4, direction: .Vertical)
 @endcode
 @see SCILinearGradientDirection
 */
-(instancetype)initWithGradientCoords:(float*)coords Colors:(uint*)colors Count:(int)count
                            Direction:(SCILinearGradientDirection)direction;

@end
