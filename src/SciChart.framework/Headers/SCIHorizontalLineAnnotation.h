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

@class SCIHorizontalLineAnnotationStyle;
@class SCILineAnnotationLabel;

@interface SCIHorizontalLineAnnotation : SCILineAnnotation

/**
 * Gets the formatted string value of the SCIHorizontalLineAnnotation
 */
@property (nonatomic, copy) NSString * formattedValue;

/**
 * Formats the value of the SCIHorizontalLineAnnotation
 */
-(NSString *) formatValue:(SCIGenericType)value;

-(void) addLabel:(SCILineAnnotationLabel*)label;
-(void) removeLabel:(SCILineAnnotationLabel*)label;
-(SCILineAnnotationLabel *) labelAt:(int)index;
-(void) removeLabelAt:(int)index;

@property (nonatomic) SCIGenericType y;
@property (nonatomic, copy) SCIHorizontalLineAnnotationStyle * style;

@end

/** @}*/
