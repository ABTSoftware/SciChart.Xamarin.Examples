//
//  SCIChartControllerProtocol.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 5/15/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol SCIChartControllerProtocol <NSObject>

/**
 * Zooms the chart to the extents of the data, plus any X or Y Grow By fraction set on the X and Y Axes
 */
-(void) zoomExtents;

/**
 * Zooms to extents with the specified animation duration
 * @param duration The duration of animation when zooming to extents
 */
-(void) animateZoomExtents:(float)duration;

/**
 * Zooms the chart to the extents of the data in the Y-Direction, accounting for the current data in view in the X-direction
 */
-(void) zoomExtentsY;

/**
 * Zooms the chart to the extents of the data in the Y-Direction, accounting for the current data in view in the X-direction
 * @param duration The duration of animation when zooming to extents
 */
-(void) animateZoomExtentsY:(float)duration;

/**
 * Zooms the chart to the extents of the data in the X-Direction
 */
-(void) zoomExtentsX;

/**
 * Zooms the chart to the extents of the data in the X-Direction
 * @param duration The duration of animation when zooming to extents
 */
-(void) animateZoomExtentsX:(float)duration;

@end
