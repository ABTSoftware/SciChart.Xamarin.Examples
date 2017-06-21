//
//  SCISpritePointMarker.h
//  SciChart
//
//  Created by Admin on 28.03.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup PointMarkers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIPointMarkerBase.h"

@class SCITextureBrushStyle;

/**
 @brief Point marker with texture drawing
 @see SCIPointMarkerProtocol
 */
@interface SCISpritePointMarker : SCIPointMarkerBase

/**
 @brief Defines textured brush for point marker
 @see SCITexturedBrushProtocol
 */
@property (nonatomic, strong) SCITextureBrushStyle *textureBrush;

@end

/** @}*/
