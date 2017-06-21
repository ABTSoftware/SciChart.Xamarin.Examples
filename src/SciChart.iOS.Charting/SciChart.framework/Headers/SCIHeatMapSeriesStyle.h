//
//  SCIHeatMapSeriesStyle.h
//  SciChart
//
//  Created by Admin on 08.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup Themes
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICallbackBlock.h"
#import "SCIGenericType.h"
#import "SCIStyle.h"

@class SCITextureOpenGL;

/**
 * @brief The SCIHeatMapSeriesStyle class.
 * @discussion Provides styling capabilities for SCIHeatMapRenderableSeries within SciChart.
 * @see SCIHeatMapRenderableSeries
 * @see SCIStyleProtocol
 */
@interface SCIHeatMapSeriesStyle : NSObject <SCIStyleProtocol, NSCopying>

/**
 * @brief Defines SCIHeatMapSeries Palette
 * @discussion Must be initialized with SCITextureOpenGL gradient texture with size 1x(Count) up to 1x128
 * @discussion default implementation is reinbow texture with size 1x7
 @code
 var grad: Array<Float> = [0.0, 0.2, 0.4, 0.6, 0.8, 1.0]
 var colors: Array<UInt32> = [0x00000000, 0x00000080, 0x30008080, 0x70008000, 0xFFFFFF00, 0xFFFF0000]
 heatRenderableSeries.style.palette = SCITextureOpenGL.init(gradientCoords: &grad, colors: &colors, count: 6)
 @endcode
 * @discussion Mapping of values on pallete can be customized with min and max properties. If min equal -3, max equal 3 and palette ranges from black (min) to white (max), then -3, -4, will be mapped as black, 3, 5 will be mapped as white, -1, 0, 2 will be maped as gray
 * @see SCITextureOpenGL
 */
@property (nonatomic, strong) SCITextureOpenGL * palette;

/**
 * @brief mapping of minimum value on palette
 * @discussion All values passed to heat map that are lower or equal to min will be mapped as first color in palette
 */
@property (nonatomic) SCIGenericType min;

/**
 * @brief mapping of maximum value on palette
 * @discussion All values passed to heat map that are greate or equal to max will be mapped as last color in palette
 */
@property (nonatomic) SCIGenericType max;

/**
 * @brief The SCIHeatMapSeriesStyle class' custom init.
 * @discussion Provides capability to initialize SCIHeatMapSeriesStyle with Palette.
 * @discussion Must be initialized with SCITextureOpenGL gradient texture with size 1x(Count) up to 1x128
 * @discussion default implementation is reinbow texture with size 1x7
 * @code
 var grad: Array<Float> = [0.0, 0.2, 0.4, 0.6, 0.8, 1.0]
 var colors: Array<UInt32> = [0x00000000, 0x00000080, 0x30008080, 0x70008000, 0xFFFFFF00, 0xFFFF0000]
 let gradient = SCIHeatMapSeriesStyle(palette: SCITextureOpenGL.init(gradientCoords: &grad, colors: &colors, count: 6))
 let style = SCIHeatMapSeriesStyle(palette: gradient)
 * @endcode
 * @discussion Mapping of values on pallete can be customized with min and max properties. If min equal -3, max equal 3 and palette ranges from black (min) to white (max), then -3, -4, will be mapped as black, 3, 5 will be mapped as white, -1, 0, 2 will be maped as gray
 * @see SCITextureOpenGL
 */
-(instancetype)initWithPalette:(SCITextureOpenGL*)palette;

@end

/** @} */