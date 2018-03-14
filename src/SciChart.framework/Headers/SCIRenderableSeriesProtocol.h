//
//  SCIRenderableSeriesProtocol.h
//  SciChart
//
//  Created by Admin on 15.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup RenderableSeries
 *  @{
 */

#import "SCIDrawable.h"
#import "SCIResamplingMode.h"
#import "SCIHitTestProvider.h"
#import "SCIPenStyle.h"
#import "SCIPointMarker.h"
#import "SCISuspendableProtocol.h"

@protocol SCIDataSeriesProtocol;
@protocol SCIAxis2DProtocol;
@protocol SCIRenderPassDataProtocol;
@protocol SCIRangeProtocol;
@protocol SCIChartSurfaceProtocol;
@class SCISeriesInfo;
@protocol SCIStyleProtocol;
@protocol SCIPaletteProviderProtocol;
@protocol SCIPointSeriesProtocol;
@protocol SCIBaseRenderableSeriesAnimationProtocol;

@class UIColor;

/**
 * @brief Protocol declares properties and methods common for all renderable series
 * @discussion Renderable series is charts visual part. For it to be displayed you have to attach renderable series to SCIChartSurface, setup axes ID and provide data series.
 * @extends SCIDrawableProtocol
 */
@protocol SCIRenderableSeriesProtocol ///
        <NSObject, SCIDrawableProtocol, SCISuspendableProtocol>
/** @{ @} */

/**
 * @brief The SCIRenderableSeriesProtocol class' property.
 * @discussion Defines Line's Pen.
 * @code
 * series.linePen = SCIPenSolid(colorCode: 0xFF00FF00, width: 1)
 * @encode
 */
@property (nonatomic) id<SCIPenStyleProtocol> strokeStyle;

@property (nonatomic) id<SCIPointMarkerProtocol> pointMarker;

@property (nonatomic) float opacity;

/**
 * @brief Surface that holds and displays renderable series
 * @see SCIChartSurfaceProtocol
 */
@property(nonatomic, weak) id <SCIChartSurfaceProtocol> parentSurface;

/**
 * @brief Property that controls chart visibility. If set to false all drawing steps will be skipped
 */
@property(nonatomic) BOOL isVisible;

/**
 * @brief If set to true, renderable series considered as selected
 */
@property(nonatomic) BOOL isSelected;

/**
 * @brief mode of point reduction (resampling)
 * @see SCIResamplingMode
 */
@property(nonatomic) SCIResamplingMode resamplingMode;

/**
 * @brief Data series, contains data
 * @discussion Make sure that data series type is suitable for specific given renderable series. Check in documentation for specific renderable series
 * @see SCIDataSeriesProtocol
 */
@property(nonatomic, strong) id <SCIDataSeriesProtocol> dataSeries;

/**
 * @brief X axis on surface to which renderable series are bound
 * @discussion This is property for internal use mainly. It is checked and initialised at render loop
 * @see SCIAxis2DProtocol
 */
@property(nonatomic, weak) id <SCIAxis2DProtocol> xAxis;

/**
 * @brief Y axis on surface to which renderable series are bound
 * @discussion This is property for internal use mainly. It is checked and initialised at render loop
 * @see SCIAxis2DProtocol
 */
@property(nonatomic, weak) id <SCIAxis2DProtocol> yAxis;

/**
 * @brief X axis ID on surface to which renderable series are bound
 * @discussion Make sure that axis with given ID attached to SCIChartSurface
 * @see SCIAxis2D
 */
@property(nonatomic, copy) NSString *xAxisId;

/**
 * @brief Y axis ID on surface to which renderable series are bound
 * @discussion Make sure that axis with given ID attached to SCIChartSurface
 * @see SCIAxis2D
 */
@property(nonatomic, copy) NSString *yAxisId;

/**
 * @brief Render pass data that is used during current drawing loop
 * @discussion For internal use. Data is valid only during current drawing loop
 */
@property(nonatomic, strong) id <SCIRenderPassDataProtocol> currentRenderPassData;

/**
 * @brief Zero line of chart in data value
 * @discussion Some charts depends on this property during drawing. For example mountains and columns
 */
@property(nonatomic) double zeroLineY;

/**
 * @brief Returns coordinates of zero line set at property "zeroLineY"
 */
- (double)getYZeroCoord;

/**
 * @brief Returns color of renderable series based on it's style and brushes
 */
- (UIColor *)seriesColor;

/**
 * @brief Method for getting renderable series X range based on it's data and drawing methods
 * @return SCIRange renderable series maximum X range
 * @see SCIRangeProtocol
 */
- (id <SCIRangeProtocol>)getXRange;

/**
 * @brief Method for getting renderable series Y range based on it's data and drawing methods and current X range
 * @return SCIRange renderable series Y range at given X range diapason
 * @see SCIRangeProtocol
 */
- (id <SCIRangeProtocol>)getYRange:(id <SCIRangeProtocol>)xRange;

/**
 * @brief Method for getting positive renderable series Y range based on it's data and drawing methods and current X range
 * @return SCIRange renderable series positive Y range at given X range diapason
 * @see SCIRangeProtocol
 */
- (id <SCIRangeProtocol>)getYRange:(id <SCIRangeProtocol>)xRange Positive:(BOOL)getPositiveRange;

/**
 * @brief Method for getting hit test tools for specific renderable series
 * @return SCIHitTestProvider hit test tools for renderable series
 * @see SCIHitTestProviderProtocol
 */
- (id <SCIHitTestProviderProtocol>)hitTestProvider;

/**
 * @brief Method for getting series info from hit test results
 * @discussion SCISeriesInfo is intermediate class that constructs UIView with series info data
 * @params info SCIHitTestInfo you can get from hit test tools
 * @return SCISeriesInfo tools for construction of series data view
 * @see SCISeriesInfo
 * @see SCIHitTestInfo
 */
- (SCISeriesInfo *)toSeriesInfoWithHitTest:(SCIHitTestInfo)info;

/**
 * @brief Tools for flexible customization of renderable series style
 * @see SCIPaletteProviderProtocol
 */
@property(nonatomic, strong) id <SCIPaletteProviderProtocol> paletteProvider;

/**
 Perform animation on the renderable series. It is used in for internal purposes.
 @param animation some base animation object which implements SCIBaseRenderableSeriesAnimationProtocol.
 @param pointSeries final state of point series when animation is finished.
 */
- (id<SCIPointSeriesProtocol>)performAnimation:(id<SCIBaseRenderableSeriesAnimationProtocol>)animation withPointSeries:(id<SCIPointSeriesProtocol>)pointSeries;

/**
 Make the series animatable. After adding animation and then change data series of the renderable series make new data appear with animation.
 It is not thread safe method. It should be called only from main thread.
 @code
    renderableSeries.addAnimation(SCIScaleRenderableSeriesAnimation(duration: 5, curveAnimation: SCIAnimationCurveEaseOut))
    renderableSeries.dataSeries = newDataSeries
 @endcode
 @param animation some base animation object which implements SCIBaseRenderableSeriesAnimationProtocol.
 */
- (void)addAnimation:(id<SCIBaseRenderableSeriesAnimationProtocol>)animation;

/**
 Remove animation from queue, All animations automatically are removed from queue when they are finished, only repeatable animations are left.
 It is not thread safe method. It should be called only from main thread.
 @param animation particular animation which should be removed.
 */
- (void)removeAnimation:(id<SCIBaseRenderableSeriesAnimationProtocol>)animation;

/**
 Checks whether this series is valid for update.
 Returns true if series is valid, otherwise - false.
 */
- (BOOL) isValidForUpdate;

@end

/** @}*/
