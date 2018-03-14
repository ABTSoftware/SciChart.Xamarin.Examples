//
//  SCIThemeProviderProtocol.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 12/12/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@protocol SCIPointMarkerProtocol;
@class SCITooltipModifierStyle, SCICursorModifierStyle, SCIRolloverModifierStyle, SCITextFormattingStyle, SCILegendCellStyle, SCIPenStyle, SCIBrushStyle;

/**
 * Defines the interface to a SciChart Theme, which provides theme colors for SCIChartSurface
 * You may implement SCIThemeProviderProtocol yourself and pass it to ThemeManager to set the global theme for all SCIChartSurface views
 */
@protocol SCIThemeProviderProtocol <NSObject>

/**
 * Gets the length of major tick lines which are rendered by SCIAxisBase instance
 *
 * @return The length of major tick lines in pixels
 */
@property (nonatomic, readonly) float majorTickLinesLength;

/**
 * Gets the length of minor tick lines which are rendered by SCIAxisBase instance
 *
 * @return The length of minor tick lines in pixels
 */
@property (nonatomic, readonly) float minorTickLinesLength;

/**
 * Gets the SCIBrushStyle which will be used as style for SCIChartSurface renderableSeriesAreaFill property
 *
 * @return The style which will be used for rendering of border
 */
@property (nonatomic, readonly) SCIBrushStyle *renderableSeriesAreaFillStyle;

/**
 * Gets the SCIPenStyle which will be used as style for SCIChartSurface renderableSeriesAreaBorder property
 *
 * @return The style which will be used for rendering of border
 */
@property (nonatomic, readonly) SCIPenStyle *renderableSeriesAreaBorderStyle;

/**
 * Gets the SCITextFormattingStyle which will be used for rendering of SCIAxisBase tick labels
 *
 * @return The style which will be used for rendering of tick labels
 */
@property (nonatomic, readonly) SCITextFormattingStyle *tickTextStyle;

/**
 * Gets the SCITextFormattingStyle which will be used for rendering of SCIAxisBase title
 *
 * @return The style which will be used for rendering of axis title
 */
@property (nonatomic, readonly) SCITextFormattingStyle *axisTitleTextStyle;

/**
 * Gets the SCIPenStyle which will be used for rendering of SCIAxisBase major grid lines
 *
 * @return The style which will be used for rendering of axis major grid lines
 */
@property (nonatomic, readonly) SCIPenStyle *majorGridLinesStyle;

/**
 * Gets the SCIPenStyle which will be used for rendering of SCIAxisBase minor grid lines
 *
 * @return The style which will be used for rendering of axis minor grid lines
 */
@property (nonatomic, readonly) SCIPenStyle *minorGridLinesStyle;

/**
 * Gets the SCIBrushStyle which will be used for rendering of SCIAxisBase major bands
 *
 * @return The style which will be used to render axis major bands
 */
@property (nonatomic, readonly) SCIBrushStyle *axisBandsStyle;

/**
 * Gets the SCIPenStyle which will be used for rendering of SCIRolloverModifierStyle vertical line
 *
 * @return The style which will be used for rendering of rollover vertical line
 */
@property (nonatomic, readonly) SCIPenStyle *rolloverLineStyle;

/**
 * Gets the SCIPenStyle which will be used for rendering of cross pointer provided by SCITooltipModifierStyle
 *
 * @return The style which will be used to render the cross pointer of tooltip modifier
 */
@property (nonatomic, readonly) SCIPenStyle *crossPointerLineStyle;

/**
 * Gets the SCIPenStyle which will be used for rendering of SCICursorModifierStyle cross
 *
 * @return The style which will be used to render cross for cursor modifier
 */
@property (nonatomic, readonly) SCIPenStyle *cursorLineStyle;

@property (nonatomic, readonly) SCIBrushStyle *rubberBandFillStyle;

@property (nonatomic, readonly) SCIPenStyle *rubberBandStrokeStyle;

/**
 * Gets the default text style for SCIAxisMarkerAnnotationStyle
 *
 * @return The default text style for axis marker annotation
 */
@property (nonatomic, readonly) SCITextFormattingStyle *defaultAxisMarkerAnnotationStyle;

/**
 * Gets the default font style for SCIAxisBase tooltips
 *
 * @return The default text style axis tooltip labels
 */
@property (nonatomic, readonly) SCITextFormattingStyle *axisTooltipTextStyle;

/**
 * Gets the default font style for SCILegendModifier and SCIChartHeatmapColourMap
 *
 * @return The default font style for legend and heatamp colour map
 */
@property (nonatomic, readonly) SCITextFormattingStyle *defaultLabelTextStyle;

/**
 * Gets the default line style for SCIFastLineRenderableSeries
 *
 * @return The default line style for line series
 */
@property (nonatomic, readonly) SCIPenStyle *defaultLineSeriesColor;

/**
 * Gets the default fill style for SCIFastMountainRenderableSeries for areaStyle property
 *
 * @return The default area fill style for mountain series
 */
@property (nonatomic, readonly) SCIBrushStyle *defaultMountainFillColor;

/**
 * Gets the default line style for SCIFastMountainRenderableSeries for strokeStyle property
 *
 * @return The default line style for mountain series
 */
@property (nonatomic, readonly) SCIPenStyle *defaultMountainLineColor;

/**
 * Gets the default fill style for SCIFastColumnRenderableSeries for fillBrushStyle property
 *
 * @return The default fill style for column series
 */
@property (nonatomic, readonly) SCIBrushStyle *defaultColumnFillStyle;

/**
 * Gets the default line style for SCIFastColumnRenderableSeries for strokeStyle property
 *
 * @return The default line style for column series
 */
@property (nonatomic, readonly) SCIPenStyle *defaultColumnLineStyle;

/**
 * Gets the default line style for SCIFastCandlestickRenderableSeries for strokeUpStyle property
 *
 * @return The default fill style when candle is going up
 */
@property (nonatomic, readonly) SCIPenStyle *defaultCandleStrokeUpStyle;

/**
 * Gets the default line style for SCIFastCandlestickRenderableSeries for strokeDownStyle property
 *
 * @return The default fill style when candle is going down
 */
@property (nonatomic, readonly) SCIPenStyle *defaultCandleStrokeDownStyle;

/**
 * Gets the default fill style for SCIFastCandlestickRenderableSeries for fillUpBrushStyle property
 *
 * @return The default fill style when candle is going up
 */
@property (nonatomic, readonly) SCIBrushStyle *defaultCandleFillUpStyle;

/**
 * Gets the default fill style for SCIFastCandlestickRenderableSeries for fillDownBrushStyle property
 *
 * @return The default fill style when candle is going down
 */
@property (nonatomic, readonly) SCIBrushStyle *defaultCandleFillDownStyle;

/**
 * Gets the default fill style for SCIFastBandRenderableSeries for fillY1BrushStyle property
 *
 * @return The default fill style for band up
 */
@property (nonatomic, readonly) SCIPenStyle *defaultUpBandLineStyle;

/**
 * Gets the default line style for SCIFastBandRenderableSeries for strokeStyle property
 *
 * @return The default line style for down band
 */
@property (nonatomic, readonly) SCIPenStyle *defaultDownBandLineStyle;

/**
 * Gets the default line style for SCIFastBandRenderableSeries for strokeY1Style property
 *
 * @return The default line style for band up
 */
@property (nonatomic, readonly) SCIBrushStyle *defaultUpBandFillStyle;

/**
 * Gets the default fill style for SCIFastBandRenderableSeries for fillBrushStyle property
 *
 * @return The default fill style for band down
 */
@property (nonatomic, readonly) SCIBrushStyle *defaultDownBandFillStyle;

/**
 * Gets the default line style for SCILineAnnotation
 *
 * @return The default line style for line annotation
 */
@property (nonatomic, readonly) SCIPenStyle *defaultLineAnnotationStyle;

/**
 * Gets the default text style for SCITextAnnotation
 *
 * @return The default text style for text annotation
 */
@property (nonatomic, readonly) SCITextFormattingStyle *defaultTextAnnotationStyle;

/**
 * Gets the default background for SCITextAnnotation
 *
 * @return The default background for text annotation
 */
@property (nonatomic, readonly) SCIBrushStyle *defaultTextAnnotationBackgroundStyle;

/**
 * Gets the default SCIPointMarkerProtocol which will be used for drawing of resizing grips for all Annotations
 *
 * @return The default resizing grip for annotations
 */
@property (nonatomic, readonly) id<SCIPointMarkerProtocol> defaultAnnotationGrip;

/**
 * Gets the NSDictionary of the params which will be used as background of SCIChartSurface
 *
 * @return NSDictionary of drawable resource with SCIChartSurface background
 */
@property (nonatomic, readonly) NSDictionary *sciChartSurfaceBackground;

/**
 * Gets the NSDictionary of the params which will be used as background of SCILegendModifier
 *
 * @return NSDictionary of drawable resource with SCILegendModifier background
 */
@property (nonatomic, readonly) NSDictionary *legendBackground;

@property (nonatomic, readonly) NSDictionary *labelBackground;

@property (nonatomic, readonly) NSDictionary *axisTooltipBackground;

@end

/** @} */
