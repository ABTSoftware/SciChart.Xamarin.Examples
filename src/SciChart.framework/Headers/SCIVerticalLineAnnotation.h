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

@class SCIVerticalLineAnnotationStyle;

@class SCILineAnnotationLabel;

@interface SCIVerticalLineAnnotation : SCILineAnnotation

/**
 * Gets the formatted string value of the SCIVerticalLineAnnotation
 */
@property (nonatomic, copy) NSString * formattedValue;

/**
 * Formats the value of the SCIVerticalLineAnnotation
 */
-(NSString *) formatValue:(SCIGenericType)value;

@property (nonatomic) SCIGenericType x;

-(void) addLabel:(SCILineAnnotationLabel*)label;
-(void) removeLabel:(SCILineAnnotationLabel*)label;
-(SCILineAnnotationLabel *) labelAt:(int)index;
-(void) removeLabelAt:(int)index;

@property (nonatomic, copy) SCIVerticalLineAnnotationStyle * style;

@end

/** @}*/
