//
//  IAxisEnums.h
//  SciChart
//
//  Created by Admin on 16.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#ifndef SciChart_AxisEnums_h
#define SciChart_AxisEnums_h

/**
 * @typedef SCIAxisAlignment
 * @abstract Enumeration constants to define the alignment mode used to place an axis.
 * @discussion Possible values:
 * @discussion - SCIAxisAlignment_Default An element stretched to fill the entire layout slot for the parent element
 * @discussion - SCIAxisAlignment_Right An element aligned to the right of the layout slot for the parent element
 * @discussion - SCIAxisAlignment_Left An element aligned to the left of the layout slot for the parent element
 * @discussion - SCIAxisAlignment_Top An element aligned to the top of the layout slot for the parent element
 * @discussion - SCIAxisAlignment_Bottom An element aligned to the bottom of the layout slot for the parent element
 */
typedef NS_ENUM(int, SCIAxisAlignment) {
    /** An element stretched to fill the entire layout slot for the parent element*/
    SCIAxisAlignment_Default,
    /** An element aligned to the left of the layout slot for the parent element*/
    SCIAxisAlignment_Left,
    /** An element aligned to the top of the layout slot for the parent element*/
    SCIAxisAlignment_Top,
    /** An element aligned to the right of the layout slot for the parent element*/
    SCIAxisAlignment_Right,
    /** An element aligned to the bottom of the layout slot for the parent element*/
    SCIAxisAlignment_Bottom
};

#endif

/** @}*/
