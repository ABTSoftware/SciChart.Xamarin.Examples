//
//  SCIPinchZoomModifier.h
//  SciChart
//
//  Created by Admin on 11.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRelativeZoomModifierBase.h"

@interface SCIPinchZoomModifier : SCIRelativeZoomModifierBase

@property (nonatomic, readonly) BOOL gestureLocked;

@end

/** @}*/