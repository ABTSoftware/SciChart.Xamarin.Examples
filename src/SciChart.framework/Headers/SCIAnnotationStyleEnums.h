//
//  SCIAnnotationStyleEnums.h
//  SciChart
//
//  Created by Admin on 12.01.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

/**
 @file
 */

/**
 * @typedef SCIAnnotationSurfaceEnum
 * @brief Enum of annotation placement modes.
 */
typedef NS_ENUM(NSUInteger, SCIAnnotationSurfaceEnum) {
    /** annotation will be on top of charts */
    SCIAnnotationSurface_AboveChart,
    /** annotation will be below charts */
    SCIAnnotationSurface_BelowChart,
    /** annotation will be on X axis */
    SCIAnnotationSurface_XAxis,
    /** annotation will be on Y axis */
    SCIAnnotationSurface_YAxis
};

/** @}*/
