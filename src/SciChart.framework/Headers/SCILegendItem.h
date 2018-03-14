//
//  SCILegendItem.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 8/4/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@protocol SCIRenderableSeriesProtocol;

/**
 * SCILegendItem model of data which will be shown in legend modifier. And those items are generated in SCILegendModifier.
 * @see SCILegendModifier
 */
@interface SCILegendItem : NSObject

/**
 * MarkerColor - is color of series. Uses in SCILegendCell for background of markerView property.
 * @see SCILegendCell
 */
@property (nonatomic, nullable) UIColor *markerColor;

/**
 * If dataSeries is visible on chartSurface the property will be YES. It is used in SCILegendCell for checking box.
 * @see SCILegendCell
 */
@property (nonatomic) BOOL isVisible;

/**
 * If dataSeries is selected on chartSurface the property will be YES. It is used in SCILegendCell for checking box.
 * @see SCILegendCell
 */
@property (nonatomic) BOOL isSelected;

/**
 * It is used in SCILegendCell for showing markerView or not.
 * @see SCILegendCell
 */
@property (nonatomic) BOOL showMarker;

/**
 * It is used in SCILegendCell for showing checkBoxButton or not.
 * @see SCILegendCell
 */
@property (nonatomic) BOOL showCheckBoxes;

/**
 * It is used in SCILegendCell for showing series name.
 * @see SCILegendCell
 */
@property (nonatomic, nullable) NSString *seriesName;

/**
 * Renderable series which is used for generating data upper. Also the renderable series is used for changing visibility of renderebleSeries on chartSurface.
 * @see SCILegendCell
 */
@property (nonnull, readonly) id<SCIRenderableSeriesProtocol> renderebleSeries;

/**
 * An instance of SCILegendItem should be created by the initializer.
 * @param series is renderebleSeries which sets renderebleSeries property, markerColor, seriesName, isVisible.
 * @see SCILegendCell
 */
- (_Nonnull instancetype)initWithRenderebleSeries:(_Nonnull id<SCIRenderableSeriesProtocol>)series;

@end

/** @}*/
