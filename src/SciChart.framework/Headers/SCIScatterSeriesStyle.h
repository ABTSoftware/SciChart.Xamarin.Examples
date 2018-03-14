//
//  SCIScatterSeriesStyle.h
//  SciChart
//
//  Created by Admin on 30.11.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIStyleProtocol.h"

@protocol SCIPointMarkerProtocol;
@class SCIPointMarkerClusterizer;

/**
 * @brief The SCIScatterSeriesStyle class.
 * @discussion Provides styling capabilities for SCIFastOhlcRenderableSeries within SciChart.
 * @see SCIFastOhlcRenderableSeries
 */
@interface SCIScatterSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @brief Gets or sets a point marker
 * @discussion Point markers will be displayed at data points if drawPointMarkers is set to true
 * @code
 * let marker = SCIEllipsePointMarker()
 * marker.drawBorder = false
 * marker.fillBrush = SCIBrushSolid(color: UIColor.redColor())
 * series.style.pointMarker = marker
 * @endcode
 * @see SCIPointMarkerProtocol
 */
@property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker;

/**
 * @brief Point marker drawing optimization
 * @discussion For internal use
 * @see SCIPointMarkerClusterizer
 */
@property (nonatomic, strong) SCIPointMarkerClusterizer * cluster;

/**
 * @brief Culling distance of tightly packed point markers
 * @discussion Distance in pixels on screen at which point markers will be culled.
 * @discussion Default value is 2. Bigger value can create noticable gaps, smaller will hit performance
 */
@property (nonatomic) float clusterSpacing;

@end

/** @} */
