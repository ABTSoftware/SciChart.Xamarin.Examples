//
//  SCIPieRenderPassData.h
//  SciChart
//
//  Created by Admin on 17/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <QuartzCore/QuartzCore.h>

/** \addtogroup RenderableSeries
 *  @{
 */

/**
 Data used in rendering of Pie and Donut series
 @see SCIPieRenderableSeries
 @see SCIDonutRenderableSeries
 */
@interface SCIPieRenderPassData : NSObject

/**
 Center of circle
 */
@property (nonatomic) CGPoint center;
/**
 Distance in points from center to inner arc. Ignored by Pie series
 */
@property (nonatomic) double innerRadius;
/**
 Distance in points from center to outer arc
 */
@property (nonatomic) double outerRadius;
/**
 Frame inside of which series is contained
 */
@property (nonatomic) CGRect frame;
/**
 Distance in points between segments in circle
 */
@property (nonatomic) double segmentSpacing;

@end

/** @}*/
