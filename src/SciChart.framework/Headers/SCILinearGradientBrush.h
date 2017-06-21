//
//  ILinearGradientBrush.h
//  SciChart
//
//  Created by Admin on 10.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

#import "SCILinearGradientEnum.h"

/**
 @brief Protocol defines gradient brushes and pens. Class should implement SCIBrush2D or SCIPen2D too.
 @see SCIBrush2DProtocol
 @see SCIPen2DProtocol
 */
@protocol SCILinearGradientBrushProtocol <NSObject>

/**
 @brief Defines gradient starting coordinate. Gradient color changes from minCoord to maxCoord
 @discussion coordinate should be either X or Y depending on gradient direction
 */
@property (nonatomic) float minCoord;
/**
 @brief Defines gradient finish coordinate. Gradient color changes from minCoord to maxCoord
 @discussion coordinate should be either X or Y depending on gradient direction
 */
@property (nonatomic) float maxCoord;

/**
 @brief Returns gradient direction set for brush instance
 */
-(SCILinearGradientDirection)direction;

/**
 @brief Returns index of gradient which is used in brush atlas controller
 @remark For internal use
 */
@property (nonatomic) float gradientIndex;

/**
 @brief Method for getting colors array and color array size
 @param data Gradient color array. Out parameter.
 @param size gradient array size. Out parameter.
 */
-(void) getGradientData:(uint**)data size:(int*)size;

@end
