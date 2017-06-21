//
//  HeatMapDataSeries.h
//  SciChart
//
//  Created by Admin on 04.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup DataSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIDataSeries.h"
#import "SCIXyzDataSeries.h"

@class SCIArrayController2D;

/**
 * DataSeries for SCIHeatMapRenderableSeries. It is specific data series which doesn't have direct method to change the data of x, y, z columns. The size of x and y clomns define on initializing. Also the step of values defines on initializing too.
 * @see SCIHeatMapRenderableSeries
 */
@interface SCIHeatMapDataSeries : NSObject <SCIDataSeriesProtocol>

/**
 * Only initializers below should be used for creating an instance of SCIHeatMapDataSeries. Based on sizeX and sizeY defining a size of Z column.
 * @code
 * let range = SCIDoubleRange(min: SCIGeneric(0), max: SCIGeneric(1))
 * var size: Int32 = 100
 * let heatmapDataSeries = SCIHeatMapDataSeries(typeX: .float, y: .float, z: .float, sizeX: size, y: size, rangeX: range, y: range)
 * @endcode
 */
-(id)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ
             SizeX:(int)sizeX Y:(int)sizeY
            RangeX:(id<SCIRangeProtocol>)rangeX Y:(id<SCIRangeProtocol>)rangeY;

/**
 * Only initializers below should be used for creating an instance of SCIHeatMapDataSeries. Based on sizeX and sizeY defining a size of Z column.
 * @code
 * var size: Int32 = 100
 * let heatmapDataSeries = SCIHeatMapDataSeries(typeX: .float, y: .float, z: .float, sizeX: size, y: size, startX: SCIGeneric(0), stepX: SCIGeneric(0.1), startY: SCIGeneric(0), stepY: SCIGeneric(0.1))
 * @endcode
 */
-(id)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ
             SizeX:(int)sizeX Y:(int)sizeY
            StartX:(SCIGenericType)startX StepX:(SCIGenericType)stepX
            StartY:(SCIGenericType)startY StepY:(SCIGenericType)stepY;

/**
 * The step of x values.
 */
-(SCIGenericType)stepX;

/**
 * The step of y values.
 */
-(SCIGenericType)stepY;

/**
 * Range of x Values. You can get from the range min and max value in x column.
 */
@property (nonatomic, strong) id<SCIRangeProtocol> xRange;

/**
 * Range of y Values. You can get from the range min and max value in y column.
 */
@property (nonatomic, strong) id<SCIRangeProtocol> yRange;

/**
 * Return an instance of SCIArrayController of x values.
 */
-(id<SCIArrayControllerProtocol>) xIndices;

/**
 * Return an instance of SCIArrayController of y values.
 */
-(id<SCIArrayControllerProtocol>) yIndices;

/**
 * Return an instance of SCIArrayController2D of z values. You can use it for changing Z value. Like in the example below.
 * @code
 * heatmapDataSeries.data().setValue(SCIGeneric(NewValueOfZ), atX:i, y: j)
 * @endcode
 */
-(SCIArrayController2D *) data;

/**
 * Count of x Values.
 */
-(int) sizeX;

/**
 * Count of y Values.
 */
-(int) sizeY;

@property (nonatomic, copy) NSString * seriesName; // Name of dataSeries, which is used in tooltip, legend and hittest modifier.

@property (nonatomic, strong) id<SCIDataDistributionCalculatorProtocol> dataDistributionCalculator;

/**
 * Here the callback is called when method "dataSeriesChanged" is called.
 *
 */
@property (nonatomic, copy) SCIActionBlock onDataSeriesChanged;

/**
 * Calls onDataSeriesChanged callback.
 */
-(void) dataSeriesChanged;

/**
 * Last resampled point series which was used for drawing the dataSeries.
 */
@property (nonatomic, strong) id<SCIPointSeriesProtocol> lastPointSeries;

@end

/** @}*/
