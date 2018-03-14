//
//  SCIAxisStyle.h
//  SciChart
//
//  Created by Admin on 20.10.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIPen2D.h"
#import "SCICallbackBlock.h"
#import "SCIStyleProtocol.h"

@class SCIPenStyle, SCIBrushStyle;
@class SCITextFormattingStyle;

#pragma mark SCIAxisLabelClippingMode enum
/**
 * @typedef SCIAxisLabelClippingMode
 * @brief A list of axis labels clipping modes.
 
 * @field SCIAxisLabelClipping_None labels will not be clipped
 
 * @field SCIAxisLabelClipping_Axis labels will be clipped to axis area
 
 * @field SCIAxisLabelClipping_Surface labels will be clipped to whole chart surface (axes and charts area)
 */
typedef NS_ENUM(NSUInteger, SCIAxisLabelClippingMode) {
    /** labels will not be clipped */
    SCIAxisLabelClipping_None,
    /** labels will be clipped to axis area */
    SCIAxisLabelClipping_Axis,
    /** labels will be clipped to whole chart surface (axes and charts area) */
    SCIAxisLabelClipping_Surface
};

#pragma mark - SCIAxisStyle class
/**
 * @abstract SCIAxisStyle class
 * @discussion Contains properties for axis theming and customization
 * @see SCIStyleProtocol
 * @see SCIAxis2DProtocol
 */
@interface SCIAxisStyle : NSObject <SCIStyleProtocol, NSCopying>

#pragma mark Minor ticks setting
/**
 * @abstract Defines if minor ticks will be drawn on axis.
 */
@property (nonatomic) BOOL drawMinorTicks;

/**
 * @abstract Defines minor ticks thickness and color.
 * @code
 * axis.style.minorTickBrush = SCIPenSolid(colorCode: 0xFFFFFFFF, width: 0.5)
 * @encode
 * @see SCIPen2DProtocol
 */
@property (nonatomic, strong) SCIPenStyle *minorTickBrush;

/**
 * @abstract Defines minor ticks line length
 */
@property (nonatomic) float minorTickSize;

#pragma mark Major ticks setting
/**
 * @abstract Defines if major ticks will be drawn on axis.
 */
@property (nonatomic) BOOL drawMajorTicks;

/**
 * @abstract Defines major ticks thickness and color.
 * @code
 * axis.style.majorTickBrush = SCIPenSolid(colorCode: 0xFFFFFFFF, width: 0.5)
 * @encode
 * @see SCIPen2DProtocol
 */
@property (nonatomic, strong) SCIPenStyle *majorTickBrush;

/**
 * @abstract Defines major ticks line length.
 */
@property (nonatomic) float majorTickSize;

#pragma mark Minor grid lines setting
/**
 * @abstract Defines if minor grid lines will be drawn on chart surface.
 */
@property (nonatomic) BOOL drawMinorGridLines;

/**
 * @abstract Defines minor grid lines thickness and color that are drawn on chart surface.
 * @code
 * axis.style.minorGridLineBrush = SCIPenSolid(colorCode: 0xFFFFFFFF, width: 0.5)
 * @encode
 * @see SCIPen2D
 */
@property (nonatomic, strong) SCIPenStyle *minorGridLineBrush;

#pragma mark Major Grid lines setting
/**
 * @abstract Defines if major grid lines will be drawn on chart surface.
 */
@property (nonatomic) BOOL drawMajorGridLines;

/**
 * @abstract Defines major grid lines thickness and color that are drawn on chart surface
 * @code
 * axis.style.majorGridLineBrush = SCIPenSolid(colorCode: 0xFFFFFFFF, width: 0.5)
 * @encode
 * @see SCIPen2DProtocol
 */
@property (nonatomic, strong) SCIPenStyle *majorGridLineBrush;

#pragma mark Major bands setting
/**
 * @abstract Defines if grid bands will be drawn on chart surface.
 * @discussion Bands are drawn between major grid lines.
 */
@property (nonatomic) BOOL drawMajorBands;

/**
 * @abstract Defines grid bands color that are drawn on chart surface.
 * @code
 * axis.style.gridBandBrush = SCIBrushSolid(colorCode: 0xE1232120)
 * @encode
 * @discussion Bands are drawn between major grid lines.
 * @see SCIBrush2DProtocol
 */
@property (nonatomic, strong) SCIBrushStyle *gridBandBrush;

#pragma mark Axis labels setting
/**
 * @abstract Defines if axis labels will be created.
 */
@property (nonatomic) BOOL drawLabels;

/**
 * @abstract Defines axis labels style.
 * @discussion Contains properties for customization of labels font, color, alignment etc.
 * @see SCITextFormattingStyle
 */
@property (nonatomic, strong) SCITextFormattingStyle * labelStyle;

/**
 * @abstract Defines axis Title label style.
 * @discussion Contains properties for customization of labels font, color, alignment etc.
 * @see SCITextFormattingStyle
 */
@property (nonatomic, strong) SCITextFormattingStyle * axisTitleLabelStyle;

/**
 * @abstract Defines axis labels clipping mode.
 * @discussion Labels can be clipped to axis bounds or chart surface bounds.
 * @see SCIAxisLabelClippingMode
 */
@property (nonatomic) SCIAxisLabelClippingMode labelClipping;

/**
 * @abstract Defines if axis should move labels instead of clipping.
 * @discussion Axis will atempt to layout labels that about to get clipped inside clipping area.
 * @discussion Clipping area is defined with "labelClipping" property
 */
@property (nonatomic) BOOL moveLabelsToClippingArea;

/**
 * @abstract Defines distance from axis panel border to axis labels. Spacing is horizontal for vertical axes and vertical for horizontal axes.
 */
@property (nonatomic) float labelSpacing;

#pragma mark Axis size
/**
 * @abstract Defines recommended size of axis panel. Width for vertical axes and height for horizontal axis.
 * @discussion Actual axis size can be different if it is not possible to layout axes with recommended size
 */
@property (nonatomic) float recommendedSize;

@end

/** @} */
