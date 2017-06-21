//
//  SCIStackedRenderableSeries.h
//  SciChart
//
//  Created by Admin on 19.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import "SCIRenderableSeriesProtocol.h"

@class SCIStackedSeriesCollectionBase;

@protocol SCIRenderPassDataProtocol, SCIStackedRenderableSeriesProtocol;

/**
 * @abstract Action that is performed by SCIStackedRenderableSeries at beginning of render loop
 * @discussion For internal use
 * @param series SCIRenderableSeriesProtocol sender of data
 * @param data SCIRenderPassDataProtocol data that will be used in drawing loop
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderPassDataProtocol
 */
typedef void(^SCIStackedSeriesRenderDataRequest)(id <SCIRenderableSeriesProtocol, SCIStackedRenderableSeriesProtocol> series, id <SCIRenderPassDataProtocol> data);

/**
 * @brief SCIStackedRenderableSeries protocol defines methods for stacked series. If renderable series implements this protocol it can be used as series in SCIStackedGroupSeries
 * @see SCIRenderableSeriesProtocol
 * @see SCIStackedGroupSeries
 @extends SCIRenderableSeriesProtocol
 */
@protocol SCIStackedRenderableSeriesProtocol ///
        <SCIRenderableSeriesProtocol>
/** @{ @} */

/**
 * @brief Action that is performed at beginning of rendering
 * @discussion For internal use. Do not override it, because it is used by SCIStackedGroupSeries for collecting data for drawing
 * @see SCIStackedSeriesRenderDataRequest
 */
@property(nonatomic, copy) SCIStackedSeriesRenderDataRequest updateRenderData;

/**
 * @brief Performs drawing of stacked series. This method is called by SCIStackedGroupSeries after data preparation
 * @params renderContext SCIRenderContext2D OpenGl context that performs drawing
 * @params renderPassData SCIRenderPassData data prepared for drawing. Valid only in current render loop
 * @see SCIRenderContext2DProtocol
 * @see SCIRenderPassDataProtocol
 */
- (void)drawWithContext:(id <SCIRenderContext2DProtocol>)renderContext
        WithStackedData:(id <SCIRenderPassDataProtocol>)renderPassData;

/**
 * @brief Instance of SCIStackedGroupSeries where current SCIStackedRenderableSeries is added.
 * @see SCIStackedGroupSeries
 */
@property(weak) SCIStackedSeriesCollectionBase *parentStackedGroupSeries;

@optional

/**
 * @brief The method is used in SCIStackedHorizontalColumnGroupSeries. Sets information in renderable series which is used for horizontally shifting.
 * @see SCIStackedHorizontalColumnGroupSeries
 */
- (void)shiftOrderNumber:(NSMutableArray<NSNumber *> *)currentNumber andCountDataSeries:(NSMutableArray<NSNumber *> *)coundDataSeries;

@end

/** @}*/