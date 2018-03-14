//
//  SCIPieDonutLayoutManager.h
//  SciChart
//
//  Created by Admin on 11/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>

@class SCIPieChartSurface;

/** \addtogroup Visuals
 *  @{
 */

/**
 Tool for auto layout of Pie and Donut series inside of SCIPieChartSurface
 */
@interface SCIPieLayoutManager : NSObject

/**
 SCIPieChartSurface that uses layout manager to calculate Pie and Donut series layyout
 @see SCIPieChartSurface
 */
@property (nonatomic, weak) SCIPieChartSurface * parentSurface;

/**
 * Gets or sets size of hole for first donut series. Hole size in points
 */
@property (nonatomic) float holeRadius;
/**
 * Gets or sets space between pie series in points
 */
@property (nonatomic) float seriesSpacing;
/**
 * Gets or sets distance from chart area border to pie charts in points
 */
@property (nonatomic) float margin;
/**
 * Gets or sets minimum series height which is used if autolayout failed to calculate size
 */
@property (nonatomic) float seriesMinimumHeight;
/**
 Gets or sets distance between segments in circle
 */
@property (nonatomic) float segmentSpacing;

/**
 Creates intance of layout manager
 @param parentSurface SCIPieChartSurface that uses layout manager to calculate Pie and Donut series layyout
 @see SCIPieChartSurface
 */
-(instancetype)initWithParent:(SCIPieChartSurface*)parentSurface;

/**
 Method is called on request of parent surface. Calculates layout for Pie and Donut series of parent surface
 */
-(void) layoutSeries;

@end

/** @}*/

