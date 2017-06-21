//
//  LineAnnotation.h
//  SciChart
//
//  Created by Admin on 24.12.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Annotations
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAnnotationBase.h"

@class SCILineAnnotationStyle;

@interface SCILineAnnotation : SCIAnnotationBase

/**
 * Gets or sets the X start point
 * @code
 let lineAnnotation = SCILineAnnotation()
 lineAnnotation.xAxisId = "xAxis"
 lineAnnotation.yAxisId = "yAxis"
 lineAnnotation.coordMode = .RelativeY
 lineAnnotation.x1 = SCIGeneric(1)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType x1;

/**
 * Gets or sets the Y start point
 * @code
 let lineAnnotation = SCILineAnnotation()
 lineAnnotation.xAxisId = "xAxis"
 lineAnnotation.yAxisId = "yAxis"
 lineAnnotation.coordMode = .RelativeY
 lineAnnotation.y1 = SCIGeneric(0.05)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType y1;

/**
 * Gets or sets the X end point
 * @code
 let lineAnnotation = SCILineAnnotation()
 lineAnnotation.xAxisId = "xAxis"
 lineAnnotation.yAxisId = "yAxis"
 lineAnnotation.coordMode = .RelativeY
 lineAnnotation.x2 = SCIGeneric(1)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType x2;

/**
 * Gets or sets the Y end point
 * @code
 let lineAnnotation = SCILineAnnotation()
 lineAnnotation.xAxisId = "xAxis"
 lineAnnotation.yAxisId = "yAxis"
 lineAnnotation.coordMode = .RelativeY
 lineAnnotation.y2 = SCIGeneric(0.95)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType y2;

/**
 * Gets or sets the LineAnnotation style
 * @discussion The variety of preperties can be set here, e.g. line width, color, point marker
 * @code
 let lineAnnotation = SCILineAnnotation()
 lineAnnotation.style.linePen = SCIPenSolid(colorCode: 0xFFFF0000, width: 2)
 chartSurface.annotation = lineAnnotation
 * @endcode
 * @see SCILineAnnotationStyle
 */
@property (nonatomic, copy) SCILineAnnotationStyle * style;

@end

/** @}*/
