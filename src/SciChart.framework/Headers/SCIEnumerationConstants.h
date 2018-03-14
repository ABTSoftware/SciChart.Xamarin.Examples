//
//  SCIEnumerationConstants.h
//  SciChart
//
//  Created by Admin on 17.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

#ifndef SciChart_EnumerationConstants_h
#define SciChart_EnumerationConstants_h

typedef NS_ENUM(int, SCIArraySearchMode) {
    SCIArraySearchMode_Exact,
    SCIArraySearchMode_Nearest,
    SCIArraySearchMode_RoundDown,
    SCIArraySearchMode_RoundUp
};

typedef NS_ENUM(int, SCIDirection2D) {
    SCIDirection2D_XDirection,
    SCIDirection2D_YDirection,
    SCIDirection2D_XYDirection
};

typedef NS_ENUM(int, SCIAxisDragMode) {
    SCIAxisDragMode_Scale,
    SCIAxisDragMode_Pan
};

/**
 * @typedef SCIClipMode
 * @abstract Enumeration constants to define the ZoomPanClip mode used when scrolling the VisibleRange of current Axis
 * @discussion Possible values:
 * @discussion - SCIClipMode_None Means you can pan right off the edge of the data into uncharted space.
 * @discussion - SCIClipMode_StretchAtExtents Causes a zooming (stretch) action when you reach the edge of the data.
 * @discussion - SCIClipMode_ClipAtMin Forces the panning operation to stop suddenly at the minimum of the data, but expand at the maximum
 * @discussion - SCIClipMode_ClipAtMax Forces the panning operation to stop suddenly at the maximum of the data, but expand at the minimum
 * @discussion - SCIClipMode_ClipAtExtents Forces the panning operation to stop suddenly at the extents of the data
 */
typedef NS_ENUM(int, SCIClipMode) {
    /**
     * ClipMode.None means you can pan right off the edge of the data into uncharted space.
     */
    SCIClipMode_None,

    /**
     * ClipMode.StretchAtExtents causes a zooming (stretch) action when you reach the edge of the data.
     */
    SCIClipMode_StretchAtExtents,

    /**
     * ClipAtMin forces the panning operation to stop suddenly at the minimum of the data, but expand at the maximum.
     */
    SCIClipMode_ClipAtMin,

    /**
     * ClipAtMax forces the panning operation to stop suddenly at the maximum of the data, but expand at the minimum.
     */
    SCIClipMode_ClipAtMax,

    /**
     * ClipAtExtents forces the panning operation to stop suddenly at the extents of the data.
     */
    SCIClipMode_ClipAtExtents
};

#endif
