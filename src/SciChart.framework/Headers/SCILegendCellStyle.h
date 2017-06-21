//
//  SCILegendCellStyle.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 8/16/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <UIKit/UIKit.h>

/**
 * The class allows editng style of default cell. New instance of SCILegendCellStyle should be set into property styleOfItemCell of SCILegendCollectionModifier instance.
 * @see SCILegendCollectionModifier
 */
@interface SCILegendCellStyle : NSObject

/**
 * Font name for seriesNameLabel on SCILegendCell. Default is [UIFont fontWithName:@"Helvetica" size:18.f]
 * @see SCILegendCell
 */
@property (nonatomic) UIFont *seriesNameFont;

/**
 * Text color for seriesNameLabel on SCILegendCell. Default is [UIColor darkTextColor]
 * @see SCILegendCell
 */
@property (nonatomic) UIColor *seriesNameTextColor;

/**
 * The image is used for checkBoxButton of SCILegendCell instance for UIControlStateSelected. Default is [UIImage imageNamed:@"checked_checkbox"]
 * @see SCILegendCell
 */
@property (nonatomic) UIImage *checkedBoxImage;

/**
 * The image is used for checkBoxButton of SCILegendCell instance for UIControlStateNormal. Default is [UIImage imageNamed:@"unchecked_checkbox"]
 * @see SCILegendCell
 */
@property (nonatomic) UIImage *uncheckedBoxImage;

/**
 * Border width of markerView of SCILegendCell instance. Default is 0.5f
 * @see SCILegendCell
 */
@property (nonatomic) CGFloat borderWidthMarkerView;

/**
 * Border color of markerView of SCILegendCell instance. Default is [UIColor whiteColor]
 * @see SCILegendCell
 */
@property (nonatomic) UIColor *borderColorMarkerView;

/**
 * Corner radius of markerView of SCILegendCell instance. Default is 5.0f
 * @see SCILegendCell
 */
@property (nonatomic) CGFloat cornerRadiusMarkerView;

/**
 * Size of markerView of SCILegendCell instance. Default is CGSizeMake(15.0f, 15.0f)
 * @see SCILegendCell
 */
@property (nonatomic) CGSize sizeMarkerView;

@end

/** @}*/
