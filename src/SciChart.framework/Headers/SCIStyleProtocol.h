//
//  SCIStyle.h
//  SciChart
//
//  Created by Admin on 10/08/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import "SCICallbackBlock.h"

/**
 * Protocol for classes that define all chart elements visual style
 * @discussion For every style check in documentation (or by name) for which elements it can be used, else you will get exception
 * @see SCILineAnnotationStyle
 * @see SCITextAnnotationStyle
 * @see SCIBoxAnnotationStyle
 * @see SCIAxisMarkerAnnotationStyle
 * @see SCITooltipModifierStyleBase
 * @see SCITooltipModifierStyle
 * @see SCICursorModifierStyle
 * @see SCIRolloverModifierStyle
 * @see SCIBubbleSeriesStyle
 * @see SCILineSeriesStyle
 * @see SCIMountainSeriesStyle
 * @see SCICandlestickSeriesStyle
 * @see SCIOhlcSeriesStyle
 * @see SCIScatterSeriesStyle
 * @see SCIColumnSeriesStyle
 * @see SCIUniformHeatmapSeriesStyle
 * @see SCIBandSeriesStyle
 * @see SCIImpulseSeriesStyle
 * @see SCIErrorBarsSeriesStyle
 * @see SCIAxisStyle
 * @see SCITextFormattingStyle
 * @see SCIRenderSurfaceStyle
 */
@protocol SCIStyleProtocol ///
<NSObject>
/** @{ @} */

/**
 * @abstract Block which is called on every style property change.
 * @discussion It is used for invalidating parent annotation and provoking redraw of annotations and modifiers on style change
 * @discussion It is not advised to replace this block manually
 * @see SCIActionBlock
 */
@property (nonatomic, copy) SCIActionBlock styleChanged;

@end

/** @} */
