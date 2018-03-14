//
//  SCILegendCollectionModifier.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 8/4/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import "SCILegendModifierBase.h"

@protocol SCILegendItemViewProtocol;

@class SCILegendCellStyle;

/**
 * Class SCILegendCollectionModifier - draws legend items and defines a size of the legendViewHolder. All elements are drawn with UICollectionView. And use SCILegendCellProtocol for cells which are instaces of UICollectionViewCell.
 */
@interface SCILegendModifier : SCILegendModifierBase

/**
 * Class of cell which will be used in collectionView for showing legend items. Default is SCILegendCell.
 * @see SCILegendCellProtocol
 * @see SCILegendCell
 */
@property (nonatomic) Class<NSObject, SCILegendItemViewProtocol> cellClass;

/** 
 * Property below is used only for default classCell = SCILegendCell. If you register your own cellClass or NibFile, the property won't work.
 * @see SCILegendCellStyle
 */
@property (nonatomic) SCILegendCellStyle *styleOfItemCell;

@end

/** @}*/
