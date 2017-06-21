//
//  TextAnnotation.h
//  SciChart
//
//  Created by Admin on 04.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Annotations
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAnchorPointAnnotation.h"
#import "SCIGenericType.h"

@class SCITextAnnotationStyle;

@interface SCITextAnnotation : SCIAnchorPointAnnotation

/**
 * Gets or sets the X position of the left top corner of the TextAnnotation
 * @code
 let textAnnotation = SCITextAnnotation()
 textAnnotation.xAxisId = "xAxis"
 textAnnotation.yAxisId = "yAxis"
 textAnnotation.coordMode = .Relative
 textAnnotation.x1 = SCIGeneric(0.7)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType x1;

/**
 * Gets or sets the Y position of the left top corner of the TextAnnotation
 * @code
 let textAnnotation = SCITextAnnotation()
 textAnnotation.xAxisId = "xAxis"
 textAnnotation.yAxisId = "yAxis"
 textAnnotation.coordMode = .Relative
 textAnnotation.y1 = SCIGeneric(0.5)
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType y1;

/**
 * Gets or sets the Text of the TextAnnotation
 * @code
 let textAnnotation = SCITextAnnotation()
 textAnnotation.text = "Hello, World"
 * @endcode
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic, copy) NSString * text;

/**
 * Gets or sets the TextAnnotation style
 * @discussion The variety of preperties can be set here, e.g. text color, font family, background color
 * @code
 let textAnnotation = SCITextAnnotation()
 textAnnotation.xAxisId = "xAxis"
 textAnnotation.yAxisId = "yAxis"
 textAnnotation.style.textStyle.fontSize = 18
 textAnnotation.style.textColor = UIColor.whiteColor()
 textAnnotation.style.backgroundColor = UIColor.clearColor()
 chartSurface.annotation = textAnnotation
 * @endcode
 * @see SCITextAnnotationStyle
 */
@property (nonatomic, copy) SCITextAnnotationStyle * style;


@property (nonatomic) BOOL editableText;
@property (nonatomic) BOOL selectebleText;

@end

/** @}*/
