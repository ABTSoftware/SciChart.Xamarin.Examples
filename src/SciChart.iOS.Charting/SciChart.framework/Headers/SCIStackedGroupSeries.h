//
//  StackedGroupSeries.h
//  SciChart
//
//  Created by Admin on 19.02.16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIRenderableSeriesBase.h"
#import "SCIThemebleProtocol.h"

@protocol SCIStackedRenderableSeriesProtocol, SCIRenderPassDataProtocol;
@class SCIRenderPassData, SCIStackedDataHelper;

/**
 @brief The SCIStackedGroupSeries class.
 @discussion That series is not visible, but used for organization of drawing SCIStackedRenderableSeries that were added to it.
 @remark Do not need any data, and do not have styles. Provide data and styles to attached SCIStackedRenderableSeries.
 @see SCIRenderableSeriesProtocol
 @see SCIRenderableSeriesBase
 @see SCIStackedRenderableSeriesProtocol
 */
@interface SCIStackedGroupSeries : SCIRenderableSeriesBase <SCIThemebleProtocol> {
    @public
    NSMutableArray<id<SCIStackedRenderableSeriesProtocol>> *_series;
    NSMutableArray<id<SCIRenderPassDataProtocol>> *_renderData;
    BOOL _drawRequest;
}

/**
 * @brief Method adds stacked series to drawing queue. 
 * @discussion Order of adding matters, because usually data of stacked series is modified with data of all previous stacked series
 * @params series SCIStackedRenderableSeriesProtocol to be drawn
 */
-(void)addSeries:(id<SCIStackedRenderableSeriesProtocol>)series;

/**
 * @brief Method removes stacked series from drawing queue.
 * @params series SCIStackedRenderableSeriesProtocol to be removed
 */
-(void)removeSeries:(id<SCIStackedRenderableSeriesProtocol>)series;

/**
 * @brief Method removes all stacked series from drawing queue.
 */
-(void)removeAllSeries;

/**
 * @brief Returns updated SCIRenderPassData for particular SCIRenderableSeries
 */
-(SCIRenderPassData*)renderDataForSeries:(id<SCIRenderableSeriesProtocol>)series;

/**
 * @brief Defines mode for stacked series, if value is true data convert into percentage
 */
@property BOOL isOneHundredPercentSeries;

@end

/** @}*/
