//
//  SCIVerticalLineAnnotation.h
//  SciChart
//
//  Created by Admin on 08/02/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Annotations
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCILineAnnotation.h"

/**
 * @typedef SCIVerticalLineAnnotationAlignment
 * @abstract Enumeration constants to define the Vertical Alignment mode used to place an annotation.
 * @discussion Possible values:
 * @discussion - SCIHorizontalLineAnnotationAlignment_Stretch A line stretched to fill the entire scichart surface
 * @discussion - SCIVerticalLineAnnotationAlignment_Bottom A line aligned to the bottom of the scichart surface
 * @discussion - SCIVerticalLineAnnotationAlignment_Top A line aligned to the top of the scichart surface
 * @discussion - SCIVerticalLineAnnotationAlignment_Center A line aligned to the center of the scichart surface
 */
typedef NS_ENUM(NSUInteger, SCIVerticalLineAnnotationAlignment) {
    SCIVerticalLineAnnotationAlignment_Stretch,
    SCIVerticalLineAnnotationAlignment_Bottom,
    SCIVerticalLineAnnotationAlignment_Top,
    SCIVerticalLineAnnotationAlignment_Center,
};


//@class SCIVerticalLineAnnotationStyle;

@class SCILineAnnotationLabel;

@interface SCIVerticalLineAnnotation : SCILineAnnotation

/**
 * Gets the formatted string value of the SCIVerticalLineAnnotation
 */
@property (nonatomic, copy) NSString * formattedValue;


/**
 * Gets or sets the Vertical Alignment for SCIVerticalLineAnnotation
 */
@property (nonatomic) SCIVerticalLineAnnotationAlignment verticalAlignment;

/**
 * Formats the value of the SCIVerticalLineAnnotation
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

-(void) removeLabelAt:(int)index;

@end

/** @}*/
