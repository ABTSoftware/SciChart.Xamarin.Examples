//
//  SCIStackedSeriesCollectionBase.h
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
#import "SCIThemeableProtocol.h"

@protocol SCIStackedRenderableSeriesProtocol, SCIRenderPassDataProtocol, SCIStackedSeriesCollectionAnimnationProtocol;
@class SCIRenderPassData, SCIStackedDataHelper;

/**
 * @brief The SCIStackedGroupSeries class.
 * @discussion That series is not visible, but used for organization of drawing SCIStackedRenderableSeries that were added to it.
 * @remark Do not need any data, and do not have styles. Provide data and styles to attached SCIStackedRenderableSeries.
 * @see SCIRenderableSeriesProtocol
 * @see SCIRenderableSeriesBase
 * @see SCIStackedRenderableSeriesProtocol
 */
@interface SCIStackedSeriesCollectionBase : SCIRenderableSeriesBase <SCIThemeableProtocol> {
    @protected NSMutableArray<id <SCIStackedRenderableSeriesProtocol>> *_series;
    @protected NSMutableArray<id <SCIRenderPassDataProtocol>> *_renderData;
    @protected BOOL _drawRequest;
}

/**
 * @brief Method adds stacked series to drawing queue. 
 * @discussion Order of adding matters, because usually data of stacked series is modified with data of all previous stacked series
 * @params series SCIStackedRenderableSeriesProtocol to be drawn
 */
- (void)add:(id <SCIStackedRenderableSeriesProtocol>)series;

/**
 * @brief Method removes stacked series from drawing queue.
 * @params series SCIStackedRenderableSeriesProtocol to be removed
 */
- (void)remove:(id <SCIStackedRenderableSeriesProtocol>)series;

/**
 * @brief Method removes all stacked series from drawing queue.
 */
- (void)removeAll;

/**
 * @brief Returns updated SCIRenderPassData for particular SCIRenderableSeries
 */
- (SCIRenderPassData *)renderDataForSeries:(id <SCIRenderableSeriesProtocol>)series;

/**
 * @brief Defines mode for stacked series, if value is true data convert into percentage
 */
@property BOOL isOneHundredPercentSeries;

- (void) updateRenderData:(SCIRenderPassData*)data ForSeries:(id<SCIStackedRenderableSeriesProtocol>)series;

/**
 Make the series animatable. After adding animation and then change data series of the renderable series make new data appear with animation.
 It is not thread safe method. It should be called only from main thread.
 @code
 renderableSeries.addAnimation(SCIScaleRenderableSeriesAnimation(duration: 5, curveAnimation: SCIAnimationCurveEaseOut))
 renderableSeries.dataSeries = newDataSeries
 @endcode
 @param animation some base animation object which implements SCIStackedSeriesCollectionAnimnationProtocol.
 */
- (void)addAnimation:(id<SCIStackedSeriesCollectionAnimnationProtocol>)animation;

@property (nonatomic, readonly) NSArray<id <SCIStackedRenderableSeriesProtocol>> *series;

@property (nonatomic) SCIActionBlock collectionDataSeriesObserver;

@end

@interface SCIStackedSeriesCollectionBase(DrawingDirection)

- (void)recalculateRenderDataForVerticalPlacement;

@end
/** @}*/
