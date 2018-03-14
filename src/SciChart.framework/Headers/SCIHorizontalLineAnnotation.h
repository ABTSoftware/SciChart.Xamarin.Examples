//
//  SCIHorizontalLineAnnotation.h
//  SciChart
//
//  Created by Admin on 09/02/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Annotations
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCILineAnnotation.h"

/**
 * @typedef SCIHorizontalLineAnnotationAlignment
 * @abstract Enumeration constants to define the Horizontal Alignment mode used to place an annotation.
 * @discussion Possible values:
 * @discussion - SCIHorizontalLineAnnotationAlignment_Stretch A line stretched to fill the entire scichart surface
 * @discussion - SCIHorizontalLineAnnotationAlignment_Left A line aligned to the left of the scichart surface
 * @discussion - SCIHorizontalLineAnnotationAlignment_Right A line aligned to the right of the scichart surface
 * @discussion - SCIHorizontalLineAnnotationAlignment_Center A line aligned to the center of the scichart surface
 */
typedef NS_ENUM(NSUInteger, SCIHorizontalLineAnnotationAlignment) {
    SCIHorizontalLineAnnotationAlignment_Stretch,
    SCIHorizontalLineAnnotationAlignment_Left,
    SCIHorizontalLineAnnotationAlignment_Right,
    SCIHorizontalLineAnnotationAlignment_Center
};

@class SCILineAnnotationLabel;

@interface SCIHorizontalLineAnnotation : SCILineAnnotation

/**
 * Gets the formatted string value of the SCIHorizontalLineAnnotation
 */
@property (nonatomic, copy) NSString * formattedValue;

/**
 * Gets or sets the horizontal alignment
 */
@property (nonatomic) SCIHorizontalLineAnnotationAlignment horizontalAlignment;

/**
 * Formats the value of the SCIHorizontalLineAnnotation
 */
-(NSString *) formatValue:(SCIGenericType)value;

/**
 * Adds SCIAnnotationLabel into SCIHorizontalLineAnnotation's labels collection
 */
-(void) addLabel:(SCILineAnnotationLabel*)label;

/**
 * Removes SCIAnnotationLabel from SCIHorizontalLineAnnotation's labels collection
 */
-(void) removeLabel:(SCILineAnnotationLabel*)label;

/**
 * Gets SCIAnnotationLabel from SCIHorizontalLineAnnotation's labels collection
 */
-(SCILineAnnotationLabel *) labelAt:(int)index;

/**
 * Removes SCIAnnotationLabel from SCIHorizontalLineAnnotation's labels collection at particular position
 */
-(void) removeLabelAt:(int)index;

@end

/** @}*/
