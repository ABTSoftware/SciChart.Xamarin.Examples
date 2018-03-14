//
//  SCIPieRenderableSeries.h
//  SciChart
//
//  Created by Admin on 07/09/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <QuartzCore/QuartzCore.h>
#import "SCIPieSegment.h"
#import "SCIPieRenderableSeriesProtocol.h"

@class SCIPieSegmentCollection;

/** \addtogroup RenderableSeries
 *  @{
 */

/**
 Pie renderable series. Circle split in segments
 @see SCIPieRenderableSeriesProtocol
 */
@interface SCIPieRenderableSeries : NSObject <SCIPieRenderableSeriesProtocol>

/**
 Duration of appear animation in seconds
 */
@property (nonatomic) double appearAnimationDuration;
/**
 Start appear animation
 */
-(void) startAnimation;
/**
 Method called internally to calculate current animation state
 */
-(BOOL) updateAnimationState:(CFTimeInterval)timeInterval;

/**
 Draw labels if true
 */
@property (nonatomic) BOOL drawLabels;

/**
 Method that draws segment.
 @param segment SCIPieSegment to be drawn
 @param offset is starting angle in radians
 @param arcSize arc size of segment in radians
 @param center CGPoint center from which segment is drawn
 @param radius distance in point to outer edge of segment
 */
-(void) drawSegment:(SCIPieSegment*)segment offset:(double)offset arcSize:(double)arcSize center:(CGPoint)center radius:(double)radius;

/**
 Returns path for segment stroke and fill drawing
 @param segment SCIPieSegment for which path is calculated
 @param centre CGPoint centre from which arcs are calculated
 @param radius distance in points to outer arc
 @param startAngle angle in radians that defines start of segment area
 @param endAngle angle in radians that defines end of segment area
 @param segmentSpacing offset in points for segment from center and other segments
 */
-(CGMutablePathRef) getSegmentPath:(SCIPieSegment*)segment centre:(CGPoint)centre radius:(double)radius startAngle:(double)startAngle endAngle:(double)endAngle segmentSpacing:(double)segmentSpacing;
/**
 Returns path for segment outline drawing
 @param segment SCIPieSegment for which path is calculated
 @param centre CGPoint centre from which arcs are calculated
 @param radius distance in points to outer arc
 @param startAngle angle in radians that defines start of segment area
 @param endAngle angle in radians that defines end of segment area
 @param segmentSpacing offset in points for segment from center and other segments
 */
-(CGMutablePathRef) getOutlinePath:(SCIPieSegment*)segment centre:(CGPoint)centre radius:(double)radius startAngle:(double)startAngle endAngle:(double)endAngle segmentSpacing:(double)segmentSpacing;
/**
 Draw fill for segment with given path
 */
-(void)drawSegmentFill:(SCIPieSegment*)segment path:(CGMutablePathRef)path;
/**
 Draw solid fill for segment with given path. Called from drawSegmentFill:path:
 */
-(void)drawSegmentSolidFill:(SCIPieSegment*)segment path:(CGMutablePathRef)path;
/**
 Draw radial gradient fill for segment with given path. Called from drawSegmentFill:path:
 */
-(void)drawSegmentGradientFill:(SCIPieSegment*)segment path:(CGMutablePathRef)path;
/**
 Draw stroke for segment with given path
 */
-(void)drawSegmentStroke:(SCIPieSegment*)segment path:(CGMutablePathRef)path;
/**
 Draw outline for segment with given path
 */
-(void)drawSegmentOutline:(SCIPieSegment*)segment path:(CGMutablePathRef)path;

/**
 Entry point for drawing label for segment
 @param segment SCIPieSegment for which label is placed
 @param offset starting angle of segment in radians
 @param arcSize size of segment arc in radians
 @param center CGPoint center from which segment is drawn
 @param radius distance in double to outer edge
 */
-(void)drawSegmentLabel:(SCIPieSegment*)segment offset:(double)offset arcSize:(double)arcSize center:(CGPoint)center radius:(double)radius;
/**
 Return text to be placed on segment. By default it's % from total value
 @param segment SCIPieSegment segment for which text is generated
 @param value total value of all segments in series
 */
-(NSString*) getLabelTextForSegment:(SCIPieSegment*)segment totalValue:(double)value;
/**
 Draw text on segment
 @param segment SCIPieSegment on which text is placed
 @param text string to be written
 @param centre CGPoint center of series
 @param radius distance in point to outer edge
 @param startAngle angle in radians that define start of segment area
 @param endAngle angle in radians that define end of segment area
 @param placementOption not used currently
 */
-(void) placeLabelForSegment:(SCIPieSegment*)segment text:(NSString*)text centre:(CGPoint)centre radius:(double)radius startAngle:(double)startAngle endAngle:(double)endAngle placementOption:(int)placementOption;

/**
 Get transform for segment path. By default adds offset for selected sectors
 */
-(CGAffineTransform) getTransformForSegment:(SCIPieSegment*)segment startAngle:(double)startAngle endAngle:(double)endAngle;

/**
 Gets or sets distance between segments in circle
 */
@property (nonatomic) float segmentSpacing;

@end

/** @}*/

