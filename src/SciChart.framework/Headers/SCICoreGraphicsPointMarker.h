//
//  SCICoreGraphicsPointMarker.h
//  SciChart
//
//  Created by Admin on 08.04.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup PointMarkers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIPointMarkerBase.h"
#import <QuartzCore/QuartzCore.h>

/**
 @typedef SCIPointMarkerCoreGraphicsSetup
 @brief Block that contains core graphics drawing sequence
 @code
 marker.drawingCall = { ( context, area ) in
   CGContextSetFillColorWithColor(context, UIColor.blueColor().CGColor)
   CGContextFillEllipseInRect(context, area);
 }
 @endcode
 */
typedef void (^SCIPointMarkerCoreGraphicsSetup) (CGContextRef context, CGRect area);

/**
 @brief Point marker with drawing based on core graphics commands. It renders core graphics context to texture before drawing
 @see SCIPointMarker
 */
@interface SCICoreGraphicsPointMarker : SCIPointMarkerBase

/**
 @brief Scale of texture for point marker.
 @discussion Default value is NaN, which means that scale is calculated based on UIScreen scale
 @discussion Scale should be greater than 0
 */
@property (nonatomic) float scale;

/**
 @brief Block that contains core graphics drawing sequence
 @code
 marker.drawingCall = { ( context, area ) in
   CGContextSetFillColorWithColor(context, UIColor.blueColor().CGColor)
   CGContextFillEllipseInRect(context, area);
 }
 @endcode
 @see SCIPointMarkerCoreGraphicsSetup
 */
@property (nonatomic, copy) SCIPointMarkerCoreGraphicsSetup drawingCall;

@end

/** @}*/