//
//  SCIChartHeatmapColourMap.h
//  SciChart
//
//  Created by Hrybenuik Mykola on 5/8/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SCIThemeableProtocol.h"
#import "SCIOrientation.h"
#import "SCITextureOpenGL.h"

/**
 * @brief Legend view for heatmap series.
 */
@interface SCIChartHeatmapColourMap : UIView <SCIThemeableProtocol>

/**
 * @brief Fonts of labels.
 */
@property (nonatomic, nonnull) UIFont *font;

/**
 * @brief Text colors of labels.
 */
@property (nonatomic, nonnull) UIColor *textColor;

/**
 * @brief NSNumberFormatter of representing min and max values in labels.
 * @code
 let numberFormatter = NSNumberFormatter.init()
 numberFormatter.minimumFractionDigits = 2
 numberFormatter.maximumFractionDigits = 2
 numberFormatter.minimumIntegerDigits = 1
 numberFormatter.decimalSeparator = "."
 colourMap.textFormat = numberFormatter
 * @endcode
 * @discussion Default format looks like "10.00"
 */
@property (nonatomic, nonnull) NSFormatter *textFormat;

/**
 * @brief Maximum value which is possible on the heatMap.
 * @discussion Default is 10.0
 */
@property (nonatomic) double maximum;

/**
 * @brief Minimum value which is possible on the heatMap.
 * @discussion Default is 1.0
 */
@property (nonatomic) double minimum;

/**
 * @brief Orientation of content on colorMapView.
 * @discussion Default is SCIOrientationVertical
 */
@property (nonatomic) SCIOrientation orientation;

/**
 * @brief Texture with gradient which represent possible values in range of minimum and maximum.
 */
@property (nonatomic, nullable) SCITextureOpenGL *colourMap;

@end
