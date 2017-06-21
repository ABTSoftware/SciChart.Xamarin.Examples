//
//  BoxAnnotation.h
//  SciChart
//
//  Created by Admin on 12.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Annotations
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAnnotationBase.h"

@class SCIBoxAnnotationStyle;

@interface SCIBoxAnnotation : SCIAnnotationBase

/**
 * Gets or sets the X start point
 * @code
 let boxAnn = SCIBoxAnnotation()
 boxAnn.xAxisId = "xAxis"
 boxAnn.yAxisId = "yAxis"
 boxAnn.coordMode = .Relative
 boxAnn.x1 = SCIGeneric(0.25)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType x1;

/**
 * Gets or sets the Y start point
 * @code
 let boxAnn = SCIBoxAnnotation()
 boxAnn.xAxisId = "xAxis"
 boxAnn.yAxisId = "yAxis"
 boxAnn.coordMode = .Relative
 boxRed.y1 = SCIGeneric(0.25)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType y1;

/**
 * Gets or sets the X end point
 * @code
 let boxAnn = SCIBoxAnnotation()
 boxAnn.xAxisId = "xAxis"
 boxAnn.yAxisId = "yAxis"
 boxAnn.coordMode = .Relative
 boxRed.x2 = SCIGeneric(0.5)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType x2;

/**
 * Gets or sets the Y end point
 * @code
 let boxAnn = SCIBoxAnnotation()
 boxAnn.xAxisId = "xAxis"
 boxAnn.yAxisId = "yAxis"
 boxAnn.coordMode = .Relative
 boxRed.y2 = SCIGeneric(0.5)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType y2;

/**
 * Gets or sets the BoxAnnotation style
 * @discussion The variety of preperties can be set here, e.g. box fill brush, border pen
 * @code
 let boxAnn = SCIBoxAnnotation()
 boxAnn.xAxisId = "xAxis"
 boxAnn.yAxisId = "yAxis"
 boxAnn.style.fillBrush = SCIBrushSolid(colorCode: 0x301010FF)
 boxAnn.style.borderPen = SCIPenSolid(colorCode: 0xFF0000FF, width: 2)
 chartSurface.annotation = boxAnn
 * @endcode
 * @see SCIBoxAnnotationStyle
 */
@property (nonatomic, copy) SCIBoxAnnotationStyle * style;

@end

/** @}*/
