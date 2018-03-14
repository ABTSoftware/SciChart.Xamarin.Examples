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

typedef void(^SCILegendCheckAction)(SCILegendItem * _Nonnull legendItem, BOOL checked);

/**
 * SCILegendItemViewProtocol
 */
@protocol SCILegendItemViewProtocol ///
<NSObject>
/** @{ @} */

@required

/**
 Callback of check box action.
 */
@property (copy, nullable) SCILegendCheckAction checkActionHandler;

- (void)setCheckActionHandler:(nullable SCILegendCheckAction)checkActionHandler;

/**
 Configurate view with model of renderable series

 @param item SCILegendItem
 */
- (void)setupWithItem:(nonnull SCILegendItem*)item;


/**
 Name of nib for creating instance of the class from xib file with all needed constraints. Return nil if the class does not have xib.

 @return nib name.
 */
+ (nullable NSString*)nibName;

@optional

/**
 Configurate view with custom style. Called when legend modifier has own style.
 */
- (void)setCustomStyleForCell:(nonnull SCILegendCellStyle *)style;

@end

/** @}*/
