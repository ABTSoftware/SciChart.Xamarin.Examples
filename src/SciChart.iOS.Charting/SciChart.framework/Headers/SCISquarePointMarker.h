//
//  SquarePointMarker.h
//  SciChart
//
//  Created by Admin on 26.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup PointMarkers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIPointMarkerBase.h"

@class SCIPenStyle, SCIBrushStyle;

/**
 @brief Point marker with rectangular shape
 @see SCIPointMarkerProtocol
 */
@interface SCISquarePointMarker : SCIPointMarkerBase

/**
 @brief Defines point marker fill color
 @see SCIBrush2DProtocol
 */
@property (nonatomic, strong) SCIBrushStyle *fillStyle;
/**
 @brief Defines point marker outline thickness and color
 @see SCIPen2DProtocol
 */
@property (nonatomic, strong) SCIPenStyle *strokeStyle;

@end

/** @}*/
