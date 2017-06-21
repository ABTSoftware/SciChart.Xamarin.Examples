//
//  MountainSeriesStyle.h
//  SciChart
//
//  Created by Admin on 22.10.15.
//  Copyright © 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIStyleProtocol.h"

@class SCIPenStyle;
@class SCIBrushStyle;
@protocol SCIPointMarkerProtocol;

/**
 * @brief The SCIMountainSeriesStyle class.
 * @discussion Provides styling capabilities for SCIFastMountainRenderableSeries within SciChart.
 * @see SCIFastMountainRenderableSeries
 */
@interface SCIMountainSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @brief Defines mountain area fill color
 * @code
 * style.areaBrush = SCIBrushSolid(colorCode: 0xFFA0A050)
 * @encode
 * @see SCIBrushStyle
 */
@property (nonatomic, strong) SCIBrushStyle *areaStyle;

/**
 * @brief Defines mountain area outline color and width
 * @code
 * style.borderPen = SCIPenSolid(colorCode: 0xFFF0F050, width: 1)
 * @encode
 * @see SCIPenStyle
 */
@property (nonatomic, strong) SCIPenStyle *strokeStyle;

/**
 * @brief Gets or sets a point marker
 * @discussion Point markers will be displayed at data points if drawPointMarkers is set to true
 * @code
 * let marker = SCIEllipsePointMarker()
 * marker.drawBorder = false
 * marker.fillBrush = SCIBrushSolid(color: UIColor.redColor())
 * lineSeries.style.pointMarker = marker
 * @endcode
 * @see SCIPointMarkerProtocol
 */
@property (nonatomic, strong) id<SCIPointMarkerProtocol> pointMarker;

/**
 * @brief If true mountain area outline will be digital (jagged)
 */
@property (nonatomic) BOOL isDigitalLine;

@end

/** @} */
