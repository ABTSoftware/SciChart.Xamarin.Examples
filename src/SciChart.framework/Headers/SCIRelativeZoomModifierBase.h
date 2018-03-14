//
//  SCIRelativeZoomModifierBase.h
//  SciChart
//
//  Created by Admin on 11.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"
#import "SCIEnumerationConstants.h"

@interface SCIRelativeZoomModifierBase : SCIGestureModifier

@property (nonatomic) SCIDirection2D direction;
@property (nonatomic) double growFactor;

-(void) performZoomAt:(CGPoint)mousePoint XValue:(double)xValue YValue:(double)yValue;
-(void) growByFraction:(double)fraction AtPoint:(CGPoint)location AtAxis:(id<SCIAxis2DProtocol>)axis;

@end

/** @}*/
