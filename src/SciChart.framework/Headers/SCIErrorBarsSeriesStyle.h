//
//  SCIErrorBarsSeriesStyle.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 9/17/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIStyleProtocol.h"

@class SCIPenStyle;

/**
 * The class provide settings of style for Error bars. It is used in class SCIFastFixedErrorBarsRenderableSeries.
 * @see SCIFastFixedErrorBarsRenderableSeries
 * @see SCIStyle
 */
@interface SCIErrorBarsSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @brief The SCIErrorBarsSeriesStyle class' property.
 * @discussion Defines Line's Pen.
 * @code
 * errorBarStyle.linePen = SCIPenSolid(colorCode: 0xFF00FF00, width: 1)
 * @encode
 */
@property (nonatomic, strong) SCIPenStyle * strokeStyle;

/**
 * Parameter of drawing line for high limit of error bar.
 * @see SCIFastFixedErrorBarsRenderableSeries
 * @code
 * errorBarStyle.highPen = SCIPenSolid(colorCode: 0xFF00FF00, width: 1)
 * @encode
 */
@property (nonatomic, strong) SCIPenStyle * strokeHighStyle;

/**
 * Parameter of drawing line for low limit of error bar.
 * @see SCIFastFixedErrorBarsRenderableSeries
 * @code
 * errorBarStyle.lowPen = SCIPenSolid(colorCode: 0xFF00FF00, width: 1)
 * @encode
 */
@property (nonatomic, strong) SCIPenStyle * strokeLowStyle;

@end

/** @} */
