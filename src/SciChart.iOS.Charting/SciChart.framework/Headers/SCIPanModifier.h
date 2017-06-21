//
//  SCIPanModifier.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 11/30/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"

/**
 * The class implements base functionality for modifiers which uses pan gesture. For example inertial scroll.
 */
@interface SCIPanModifier : SCIGestureModifier

- (void)performPanFrom:(CGPoint)lastPoint To:(CGPoint)currentPoint;
- (void)performPanEndingFrom:(CGPoint)lastPoint andVelocity:(CGPoint)velocity;

@end
