//
//  SCIZoomExtentsModifier.h
//  SciChart
//
//  Created by Admin on 12.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGestureModifier.h"
#import "SCIEnumerationConstants.h"

@interface SCIZoomExtentsModifier : SCIGestureModifier

@property (nonatomic) BOOL isAnimated;

@property (nonatomic) SCIDirection2D direction;

@end

/** @}*/
