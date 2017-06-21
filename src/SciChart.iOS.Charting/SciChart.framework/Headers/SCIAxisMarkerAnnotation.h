//
//  SCIAxisMarkerAnnotation.h
//  SciChart
//
//  Created by Admin on 27/07/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Annotations
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAxisMarkerAnnotationBase.h"

@class SCIAxisMarkerAnnotationStyle;

@interface SCIAxisMarkerAnnotation : SCIAxisMarkerAnnotationBase

/**
 * Gets or sets the position of the AxisMarkerAnnotation
 * @code
 let lastMarker = SCIAxisMarkerAnnotation()
 lastMarker.position = SCIGeneric(34)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType position;

@end

/** @}*/
