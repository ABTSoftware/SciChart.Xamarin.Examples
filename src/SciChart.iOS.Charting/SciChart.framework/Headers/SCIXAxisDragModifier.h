//
//  SCIXAxisDragModifier.h
//  SciChart
//
//  Created by Admin on 06.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAxisDragModifierBase.h"

/**
 * @brief The SCIXAxisDragModifier class.
 * @discussion Provides drag to scale operations on X-axis.
 */
@interface SCIXAxisDragModifier : SCIAxisDragModifierBase

/**
 * @brief The SCIXAxisDragModifier class' property.
 * @discussion Defines how panning behaves when you reach the edge of the X-axis extents.
 */
@property (nonatomic) SCIClipMode clipModeX;

@end

/** @}*/