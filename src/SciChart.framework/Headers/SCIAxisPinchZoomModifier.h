//
//  SCIAxisPinchZoomModifier.h
//  SciChart
//
//  Created by Admin on 13.04.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRelativeZoomModifierBase.h"

/**
 * @brief The SCIAxisPinchZoomModifier class.
 * @discussion Provides drag to scale operations on Y-axis.
 */
@interface SCIAxisPinchZoomModifier : SCIRelativeZoomModifierBase

@property (nonatomic, readonly) BOOL gestureLocked;

/**
 * @brief The SCIAxisPinchZoomModifier class' property.
 * @discussion Defines which Axis to attach the AxisPinchZoomModifier to, matching by string Id
 */
@property (nonatomic, copy) NSString* axisId;

@end

/** @}*/