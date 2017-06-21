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

@class SCIArrayController2D, SCIDataSeriesObserver;

@protocol SCIUniformHeatmapDataSeriesProtocol <SCIDataSeriesProtocol>

/**
 * Range of x Values. You can get from the range min and max value in x column.
 */
@property (nonatomic, strong, nullable) id<SCIRangeProtocol> xRange;

/**
 * Range of y Values. You can get from the range min and max value in y column.
 */
@property (nonatomic, strong, nullable) id<SCIRangeProtocol> yRange;

/**
 * The step of x values.
 */
@property (nonatomic) SCIGenericType stepX;

/**
 * The step of y values.
 */
@property (nonatomic) SCIGenericType stepY;

/**
 * The start of x values.
 */
@property (nonatomic) SCIGenericType startX;

/**
 * The start of y values.
 */
@property (nonatomic) SCIGenericType startY;

/**
 * Return an instance of SCIArrayController of x values.
 */
-(nonnull id<SCIArrayControllerProtocol>) xIndices;

/**
 * Return an instance of SCIArrayController of y values.
 */
-(nonnull id<SCIArrayControllerProtocol>) yIndices;

/**
 * Return an instance of SCIArrayController2D of z values. You can use it for changing Z value. Like in the example below.
 * @code
 * heatmapDataSeries.data().setValue(SCIGeneric(NewValueOfZ), atX:i, y: j)
 * @endcode
 */
-(nonnull SCIArrayController2D *) zValues;

/**
 * Count of x Values.
 */
-(int) sizeX;

/**
 * Count of y Values.
 */
-(int) sizeY;

/**
 * Updates Z Value at specified xIndex and yIndex
 *
 * @param xIndex The xIndex to update at
 * @param yIndex The yIndex to update at
 * @param value  The value to set
 */
-(void) updateZAtXIndex:(int)xIndex yIndex:(int)yIndex withValue:(SCIGenericType) value;

/**
 * Updates Z values for this data series
 * @param values The new Z values
 */
-(void) updateZValues: ( SCIArrayController2D* _Nonnull ) values;

-(void) updateZValues:(SCIGenericType)values Size:(int)size;

/**
 * Updates the range of Z values for this series
 *
 * @param xIndex The xIndex to start update at
 * @param yIndex The yIndex to start update at
 * @param values The new Z values
 */
-(void) updateRangeZAtXIndex: (int)xIndex yIndex:(int)yIndex withValues:(SCIArrayController2D* _Nonnull) values;

/**
 * Callback is called every time when somthing chages in data series (appending new values, removing, inserting).
 */

- (void)addObserver:(SCIDataSeriesObserver* _Nonnull)observer;

- (void)removeObserver:(SCIDataSeriesObserver* _Nonnull)observer;

@end


/**
 * DataSeries for SCIFastUniformHeatmapRenderableSeries. It is specific data series which doesn't have direct method to change the data of x, y, z columns. The size of x and y clomns define on initializing. Also the step of values defines on initializing too.
 * @see SCIFastUniformHeatmapRenderableSeries
 */
@interface SCIUniformHeatmapDataSeries : NSObject <SCIUniformHeatmapDataSeriesProtocol>

/**
 * Last resampled point series which was used for drawing the dataSeries.
 */
@property (nonatomic, strong, nonnull) id<SCIPointSeriesProtocol> lastPointSeries;

/**
 * Data distribution calculator for current data series
 */
@property (nonatomic, strong, nonnull) id<SCIDataDistributionCalculatorProtocol> dataDistributionCalculator;

/**
 * Calls onDataSeriesChanged callback.
 */
-(void) dataSeriesChanged;

/**
 * Only initializers below should be used for creating an instance of SCIUniformHeatmapDataSeries. Based on sizeX and sizeY defining a size of Z column.
 * @code
 * let range = SCIDoubleRange(min: SCIGeneric(0), max: SCIGeneric(1))
 * var size: Int32 = 100
 * let heatmapDataSeries = SCIUniformHeatmapDataSeries(typeX: .float, y: .float, z: .float, sizeX: size, y: size, rangeX: range, y: range)
 * @endcode
 */
//-(id)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ
  //           SizeX:(int)sizeX Y:(int)sizeY
    //        RangeX:(id<SCIRangeProtocol>)rangeX Y:(id<SCIRangeProtocol>)rangeY;

/**
 * Only initializers below should be used for creating an instance of SCIUniformHeatmapDataSeries. Based on sizeX and sizeY defining a size of Z column.
 * @code
 * var size: Int32 = 100
 * let heatmapDataSeries = SCIUniformHeatmapDataSeries(typeX: .float, y: .float, z: .float, sizeX: size, y: size, startX: SCIGeneric(0), stepX: SCIGeneric(0.1), startY: SCIGeneric(0), stepY: SCIGeneric(0.1))
 * @endcode
 */
-(nonnull instancetype)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ
             SizeX:(int)sizeX Y:(int)sizeY
            StartX:(SCIGenericType)startX StepX:(SCIGenericType)stepX
            StartY:(SCIGenericType)startY StepY:(SCIGenericType)stepY;

-(nonnull instancetype)initWithZValues:(SCIArrayController2D* _Nonnull) array2D
            StartX:(SCIGenericType)startX StepX:(SCIGenericType)stepX
            StartY:(SCIGenericType)startY StepY:(SCIGenericType)stepY;

-(nonnull instancetype)initWithTypeX:(SCIDataType)typeX Y:(SCIDataType)typeY Z:(SCIDataType)typeZ
             SizeX:(int)sizeX Y:(int)sizeY
            RangeX:(id<SCIRangeProtocol> _Nonnull)rangeX Y:(id<SCIRangeProtocol> _Nonnull)rangeY;

@end

/** @}*/
