//
//  SCIPieRenderableSeriesProtocol.h
//  SciChart
//
//  Created by Admin on 17/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import "SCIInvalidatableElement.h"
#import <QuartzCore/QuartzCore.h>

@class SCIPieRenderPassData;
@class SCIPieLayoutPassData;
@class SCIPieChartSurface;
@class SCIPieSegmentCollection;
@class SCIPieHitTestProvider;
@class SCIBrushStyle;
@class SCIPenStyle;
@class SCITextFormattingStyle;
@class SCIPieSegment;
@class SCIPieSeriesInfo;
@class SCIPieHiTestInfo;

/** \addtogroup RenderableSeries
 *  @{
 */

/**
 * @typedef SCIPieSeriesSizingMode
 * @brief Enum of sizing mode for Pie and donut series
 */
typedef NS_ENUM(NSUInteger, SCIPieSeriesSizingMode) {
    /** Series size is relative to other series size with relative mode */
    SCIPieSeriesSizeMode_Relative,
    /** Series size is absolute and set in points */
    SCIPieSeriesSizeMode_Absolute
};

/**
 @extends SCIInvalidatableElementProtocol
 */
@protocol SCIPieRenderableSeriesProtocol ///
<NSObject, SCIInvalidatableElementProtocol>
/** @{ @} */

/**
 Parent surface of renderable series. Set internally during adding renderable series to surface
 @see SCIPieChartSurface
 */
@property (nonatomic, weak, nullable) SCIPieChartSurface * parentSurface;

/**
 Collection of segments of renderable series
 @see SCIPieSegmentCollection
 @see SCIPieSegment
 */
@property (nonatomic, strong, nonnull) SCIPieSegmentCollection * segments;

/**
 Renderable series name
 */
@property (nonatomic, strong, nonnull) NSString * seriesName;
/**
 Gets or sets series visibility
 */
@property (nonatomic) BOOL isVisible;
/**
 Return true if series has selected sectors
 */
-(BOOL) isSelected;

/**
 Total combined value of all segments
 */
-(double) totalSegmentValue;

/**
 Data used for drawing. Contains information like frame, center and radius
 Changes internally during charts layout process
 @see SCIPieRenderPassData
 */
@property (nonatomic, nonnull) SCIPieRenderPassData * renderData;
/**
 Height of renderable series. Not used for drawing. Radius of series is calculated internally from this property in combination with heightSizingMode
 */
@property (nonatomic) double height;
/**
 Mode for charts height
 @see SCIPieSeriesSizingMode
 */
@property (nonatomic) SCIPieSeriesSizingMode heightSizingMode;
/**
 Starting angle offset for series in radinas. Default is zero (start at right) and increases clockwise
 */
@property (nonatomic) double startAngle;
/**
 Scaleof circle series. Value is fraction of circle where 0 is empty circle and 1 is full circle
 */
@property (nonatomic) double scale;

/**
 Sets renderData based on calculated layout data
 Called internally during autolayout process
 @see SCIPieRenderPassData
 @see SCIPieLayoutPassData
 */
-(void) setLayout:(SCIPieLayoutPassData * _Nonnull)data;

/**
 Start appear animation with duration in seconds
 */
-(void)animate:(double)duration;

/**
 Entry point for drawing
 */
-(void) draw;
/**
 Set isSelected to false for all segments
 */
-(void) deselectSegments;
/**
 Set isSelected to true for segment by index
 */
-(void) selectSegmentAtIndex:(int)index;
/**
 Changes isSelected state for segment by index
 */
-(void) setSegmentSelected:(BOOL)selected atIndex:(int)index;
/**
 Performs hit test at point and return segment index if hit, or -1 if miss
 */
-(int)getSegmentIndexAtPoint:(CGPoint)point;
/**
 Formats text for segment. By default its' "Title: value (percent_of_total%)"
 */
-(NSString * _Nonnull)getSegmentTextAtIndex:(int)index;
/**
 Returns tools for hit test
 @see SCIPieHitTestProvider
 */
-(SCIPieHitTestProvider * _Nullable)hitTestProvider;
/**
 Gets or sets offset from center in points for selected segments
 */
@property (nonatomic) double selectedSegmentOffset;
/**
 Gets or sets fill style for segments. Used only if fill style is nil on segment.
 */
@property (nonatomic, nullable) SCIBrushStyle * segmentFillStyle;
/**
 Gets or sets selected fill style for segments. Used only if selected fill style is nil on segment.
 */
@property (nonatomic, nullable) SCIBrushStyle * selectedSegmentFillStyle;
/**
 Gets or sets stroke style for segments. Used only if stroke style is nil on segment.
 */
@property (nonatomic, nullable) SCIPenStyle * segmentStrokeStyle;
/**
 Gets or sets selected stroke style for segments. Used only if selected stroke style is nil on segment.
 */
@property (nonatomic, nullable) SCIPenStyle * selectedSegmentStrokeStyle;
/**
 Gets or sets outline style for segments. Used only if outline style is nil on segment.
 */
@property (nonatomic, nullable) SCIPenStyle * segmentOutlineStyle;
/**
 Gets or sets selected outline style for segments. Used only if selected outline style is nil on segment.
 */
@property (nonatomic, nullable) SCIPenStyle * selectedSegmentOutlineStyle;
/**
 Gets or sets title style for segments. Used only if title style is nil on segment.
 */
@property (nonatomic, nullable) SCITextFormattingStyle * segmentTitleStyle;
/**
 Gets or sets selected title style for segments. Used only if selected title style is nil on segment.
 */
@property (nonatomic, nullable) SCITextFormattingStyle * selectedSegmentTitleStyle;

/**
 Return fill style for segment based on style priorities (segment style first, series style second) and selected state
 */
-(SCIBrushStyle * _Nullable)getFillStyleForSegment:(SCIPieSegment * _Nonnull)segment;
/**
 Return stroke style for segment based on style priorities (segment style first, series style second) and selected state
 */
-(SCIPenStyle * _Nullable)getStrokeStyleForSegment:(SCIPieSegment * _Nonnull)segment;
/**
 Return outline style for segment based on style priorities (segment style first, series style second) and selected state
 */
-(SCIPenStyle * _Nullable)getOutlineStyleForSegment:(SCIPieSegment * _Nonnull)segment;
/**
 Return text style for segment based on style priorities (segment style first, series style second) and selected state
 */
-(SCITextFormattingStyle * _Nullable)getTextStyleForSegment:(SCIPieSegment * _Nonnull)segment;

@end

/** @}*/
