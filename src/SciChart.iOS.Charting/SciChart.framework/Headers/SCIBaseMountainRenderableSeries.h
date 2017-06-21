//
//  SCIBaseMountainRenderableSeries.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 5/4/17.
//  Copyright © 2017 SciChart. All rights reserved.
//


/** \addtogroup RenderableSeries
 *  @{
 */
#import "SCIRenderableSeriesBase.h"
#import "SCIThemeableProtocol.h"

@class SCIMountainSeriesStyle;
@protocol SCIBrushStyleProtocol;

@interface SCIBaseMountainRenderableSeries : SCIRenderableSeriesBase <SCIThemeableProtocol>

/**
 * @brief Get or set style for visual customization
 * @see SCIMountainSeriesStyle
 */
@property(nonatomic, copy) SCIMountainSeriesStyle *style;

/**
 * @brief Gets or sets selected series style
 * @discussion If set to nil selected style is default series style
 */
@property(nonatomic, copy) SCIMountainSeriesStyle *selectedStyle;

@property(nonatomic) BOOL isDigitalLine;

@property(nonatomic, strong) id <SCIBrushStyleProtocol> areaStyle;

@end
/** @}*/
