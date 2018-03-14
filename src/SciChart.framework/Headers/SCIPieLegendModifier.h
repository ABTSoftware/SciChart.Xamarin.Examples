//
//  SCIPieLegendModifier.h
//  SciChart
//
//  Created by Admin on 25/10/2017.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SCILegendModifier.h"

/** \addtogroup ChartModifiers
 *  @{
 */

@protocol SCIPieRenderableSeriesProtocol;

/**
 * Class SCIPieLegendModifier - draws legend items and defines a size of the legendViewHolder. All elements are drawn with UICollectionView. And use SCILegendCellProtocol for cells which are instaces of UICollectionViewCell.
 @see SCILegendModifier
 */
@interface SCIPieLegendModifier : SCILegendModifier

/**
 Pie or donut renderable series which sectors Legend displays
 @see SCIPieRenderableSeriesProtocol
 */
@property (nonatomic, weak) id<SCIPieRenderableSeriesProtocol> pieSeries;

@end

/** @}*/
