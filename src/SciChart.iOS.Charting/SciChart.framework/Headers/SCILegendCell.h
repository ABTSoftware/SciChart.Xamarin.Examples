//
//  SCILegendCell.h
//  SCILegendCollection
//
//  Created by Mykola Hrybeniuk on 8/4/16.
//  Copyright © 2016 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <UIKit/UIKit.h>

@class SCILegendItem, SCILegendCellStyle;

typedef void(^SCILegendCheckAction)(SCILegendItem *legendItem, BOOL checked);

/**
 *
 */
@protocol SCILegendCellProtocol ///
<NSObject>
/** @{ @} */

@required
+ (CGSize)preferredLayoutSizeFittingSize:(CGSize)size forItem:(SCILegendItem*)item;
- (void)setupWithItem:(SCILegendItem*)item;

@optional
@property (copy) SCILegendCheckAction checkActionHandler;
- (void)setCheckActionHandler:(SCILegendCheckAction)checkActionHandler;

@end

/**
 * The class is used in SCILegendCollectionModifier to visualize SCILegendItem.
 * @see SCILegendCollectionModifier
 * @see SCILegendItem
 */
@interface SCILegendCell : UICollectionViewCell <SCILegendCellProtocol>

/**
 * New images for states can be set in SCILegendCellStyle which is property of SCILegendCollectionModifier. 
 * Also it can be hidden if set property showCheckBoxes = NO.
 * @code
 * SCILegendCollectionModifier *legendModifier = [SCILegendCollectionModifier new];
 * legendModifier.showCheckBoxes = NO;
 * legendModifier.styleOfItemCell.checkedBoxImage = [UIImage new];
 * legendModifier.styleOfItemCell.uncheckedBoxImage = [UIImage new];
 * @endcode
 * @see SCILegendCellStyle
 * @see SCILegendCollectionModifier
 * @see SCILegenModifier
 */
@property (weak, nonatomic) IBOutlet UIButton *checkBoxButton;

/**
 * The size can be set in SCILegendCellStyle which is property of SCILegendCollectionModifier.
 * Also it can be hidden if set property showSeriesMarkers = NO.
 * @code
 * SCILegendCollectionModifier *legendModifier = [SCILegendCollectionModifier new];
 * legendModifier.showSeriesMarkers = NO;
 * legendModifier.styleOfItemCell.sizeMarkerView = CGSizeMake(320.f, 320.f);
 * @endcode
 * @see SCILegendCellStyle
 * @see SCILegendCollectionModifier
 * @see SCILegenModifier
 */
@property (weak, nonatomic) IBOutlet UIView *markerView;

/**
 * Font and text color can be changed in seriesNameLabel.
 * @code
 * SCILegendCollectionModifier *legendModifier = [SCILegendCollectionModifier new];
 * legendModifier.styleOfItemCell.seriesNameFont = [UIFont fontWithName:@"Helvetica" size:16.f];
 * legendModifier.styleOfItemCell.seriesNameTextColor = [UIColor grayColor];
 * @endcode
 * @see SCILegendCellStyle
 * @see SCILegendCollectionModifier
 * @see SCILegenModifier
 */
@property (weak, nonatomic) IBOutlet UILabel *seriesNameLabel;

/**
 * The method are used in SCILegendCollectionModifier for setting style of cell.
 * @see SCILegendCollectionModifier
 */
- (void)setCustomStyleForCell:(SCILegendCellStyle*)style;

/**
 * The method returns a preferred size of cell for item with certain style. This size will be used for calculating a general size of legend modifier view.
 * @see SCILegendCollectionModifier
 */
+ (CGSize)preferredLayoutSizeFittingSize:(CGSize)size
                                 forItem:(SCILegendItem*)item
                         withCustomStyle:(SCILegendCellStyle*)style;

@end

/** @}*/
