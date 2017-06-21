//
//  SCIImpulseSeriesStyle.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 9/15/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIStyleProtocol.h"

@class SCIPenStyle;
@protocol SCIPointMarkerProtocol;
@class SCIPointMarkerClusterizer;

/**
 * @brief The SCIImpulseSeriesStyle class.
 * @discussion Provides styling capabilities for SCIFastImpulseRenderableSeries within SciChart.
 * @see SCIStyleProtocol
 * @see SCIFastImpulseRenderableSeries
 */
@interface SCIImpulseSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @brief Defines impulse line color and thickness
 * @code
 * style.linePen = SCIPenSolid(color: UIColor.blueColor(), width: 2)
 * @encode
 * @see SCIPenStyle
 */
@property (nonatomic, strong) SCIPenStyle * strokeStyle;

/**
 * @brief Defines impulse point marker
 * @code
 * let marker = SCIEllipsePointMarker()
 * marker.drawBorder = false
 * marker.fillBrush = SCIBrushSolid(color: UIColor.blueColor())
 * impulseSeries.style.pointMarker = marker
 * @endcode
 * @see SCIPointMarker
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
