//
//  SCIZoomPanModifierBase.h
//  SciChart
//
//  Created by Admin on 11.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIPanModifier.h"
#import "SCIEnumerationConstants.h"

@interface SCIZoomPanModifierBase : SCIPanModifier

@property (nonatomic) SCIDirection2D direction;
@property (nonatomic) SCIClipMode clipModeX;
@property (nonatomic) BOOL zoomExtentsY;

@property (nonatomic, readonly) BOOL gestureLocked;

@end

/** @}*/
