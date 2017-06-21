//
//  SCIPathColor.h
//  SciChart
//
//  Created by Admin on 17.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

@class UIColor;

/**
 @brief Protocol provides basic methods for SciChart brushes.
 @remark For all brushes color code bytes order is 0xAABBGGRR
* @extends NSCopying
 */
@protocol SCIPathColorProtocol ///
 <NSObject, NSCopying>
/** @{ @} */

@required
/**
 @brief Returns color of brush. Can be not valid for textured brushes
 */
-(UIColor*) color;

/**
 @brief Returns color code of brush. Can be not valid for textured brushes. Color code bytes order is 0xAABBGGRR
 */
-(unsigned int) colorCode;
/**
 @brief Returns color code of brush for specific coordinates. Can be not valid for textured brushes. Color code bytes order is 0xAABBGGRR
 */
-(unsigned int) colorCodeAtX:(double)x Y:(double)y;

@end