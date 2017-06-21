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

@protocol SCILegendCellProtocol;

@class SCILegendCellStyle;

/**
 * Class SCILegendCollectionModifier - draws legend items and defines a size of the legendViewHolder. All elements are drawn with UICollectionView. And use SCILegendCellProtocol for cells which are instaces of UICollectionViewCell.
 */
@interface SCILegendModifier : SCILegendModifierBase

/**
 * The collectionView draws legend elements.
 */
@property (nonatomic, readonly) UICollectionView *collectionView;

/**
 * ReuseCellIdentifier which is used in collection view for cells. Don't forget provide your own ReuseCellIdentifier for custom cells. Default is SCILegendCellId for defauld cellClass.
 */
@property (nonatomic, readonly) NSString *currentRegisteredReuseIdentifier;

/**
 * Class of cell which will be used in collectionView for showing legend items. Default is SCILegendCell.
 * @see SCILegendCellProtocol
 * @see SCILegendCell
 */
@property (nonatomic, readonly) Class<SCILegendCellProtocol> cellClass;

/** 
 * Property below is used only for default classCell = SCILegendCell. If you register your own cellClass or NibFile, the property won't work.
 * @see SCILegendCellStyle
 */
@property (nonatomic) SCILegendCellStyle *styleOfItemCell;

/** 
 * Default cell class which is used - SCILegendCell. But you cen register for collectionView any other class
 * which inherites UICollectionViewCell and implements SCILegendCellProtocol;
 */
- (void)registerCellClass:(Class<SCILegendCellProtocol>)cellClass withReuseIdentifier:(NSString*)identifier;
- (void)registerCellNib:(UINib*)cellNib withReuseIdentifier:(NSString*)identifier;

@end

/** @}*/
