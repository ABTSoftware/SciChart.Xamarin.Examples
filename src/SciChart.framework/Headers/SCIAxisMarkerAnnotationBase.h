//
//  SCIAxisMarkerAnnotationBase.h
//  SciChart
//
//  Created by Admin on 09/02/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Annotations
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAnnotationBase.h"

@class SCIAxisMarkerAnnotationStyle;

@interface SCIAxisMarkerAnnotationBase : SCIAnnotationBase

/**
 * Gets or sets the SCIAxisMarkerAnnotationBase  style
 * @discussion The variety of properties can be set here, e.g. text color, background color, margin, etc.
 * @code
 let averageMarker = SCIAxisMarkerAnnotation()
 averageMarker.style.backgroundColor = UIColor.fromABGRColorCode(0xFF00a5ff)
 chartSurface.annotation = averageMarker
 * @endcode
 * @see SCILineAnnotationStyle
 */
@property (nonatomic, copy) SCIAxisMarkerAnnotationStyle * style;

/**
 * Gets the formatted string value of the AxisMarkerAnnotation
 */
@property (nonatomic, copy) NSString * formattedValue;

/**
 * Formats the value of the AxisMarkerAnnotation
 */
-(NSString *) formatValue:(SCIGenericType)value;

-(UITextField *) axisLabel;

-(id<SCIAxis2DProtocol>) currentAxis;

-(void) resetAxis;

-(SCIGenericType)positionOnAxis;

@end

/** @}*/
