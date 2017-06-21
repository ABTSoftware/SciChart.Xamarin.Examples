//
//  SCIBubbleSeriesStyle.h
//  SciChart
//
//  Created by Admin on 18.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */
#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIStyleProtocol.h"

@class SCIPenStyle;
@class SCIBrushStyle;

/**
 * @brief The SCIBubbleSeriesStyle class
 * @discussion Provides styling capabilities for SCIBubbleRenderableSeries
 * @see SCIBubbleRenderableSeries
 * @see SCIStyleProtocol
 */
@interface SCIBubbleSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @brief Defines bubble fill color
 * @code
 * style.bubbleBrush = SCIBrushSolid(colorCode: 0xFF00A0FF)
 * @encode
 * @see SCIBrushStyle
 */
@property (nonatomic, strong) SCIBrushStyle * bubbleBrushStyle;

/**
 * @brief Defines Bubble's outline color and width
 * @code
 * style.borderPen = SCIPenSolid(colorCode: 0xFF00A0FF, width: 1)
 * @encode
 * @see SCIPenStyle
 */
@property (nonatomic, strong) SCIPenStyle * strokeStyle;

/**
 * @brief Defines Bubble's level of detalization or number of edges
 * @discussion The higher value, the better looking circle will be. But it can hit performance, especially with outlines turned on
 * @discussion Default value is 20
 */
@property (nonatomic) int detalization;

@end

/** @} */
