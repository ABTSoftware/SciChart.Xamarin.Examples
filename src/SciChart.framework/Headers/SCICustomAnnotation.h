//
//  SCICustomAnnotation.h
//  SciChart
//
//  Created by Yaroslav Pelyukh on 2/3/17.
//  Copyright © 2017 SciChart. All rights reserved.

#import <UIKit/UIKit.h>
#import "SCIAnnotationBase.h"

/** \addtogroup Annotations
 *  @{
 */

@class SCICustomAnnotationStyle;

@interface SCICustomAnnotation : SCIAnnotationBase

/**
 * Gets or sets the X start point
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType x1;

/**
 * Gets or sets the Y start point
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType y1;

/**
 * Gets or sets the X start point
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType x2;

/**
 * Gets or sets the Y start point
 * @see SCIAnnotationCoordMode
 */
@property (nonatomic) SCIGenericType y2;


/**
 * Gets or sets the Content View
 */
@property (nonatomic) UIView* customView;

/**
 * Gets or sets the CustomAnnotation style
 * @discussion The variety of properties can be set here, e.g. resize marker
 * @code
 * @endcode
 * @see SCICustomAnnotationStyle
 */
@property (nonatomic, copy) SCICustomAnnotationStyle * style;

@end

/** @}*/
