//
//  SCILegendModifier.h
//  SciChart
//
//  Created by Mykola Hrybeniuk on 8/3/16.
//  Copyright © 2016 SciChart. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import "SCIChartModifierBase.h"
#import "SCIThemeableProtocol.h"
#import <UIKit/UIKit.h>
#import "SCIOrientation.h"

/**
 * @brief The Enum defines a position of the legend on chartSurface.
 */
typedef NS_OPTIONS(NSUInteger, SCILegendPosition) {
    
    /** Means that The holderLegendView doesn't add to chart surface. And user can add the holderLegendView to any other view. */
    SCILegendPositionNone   = 0,
    
    /** Other variants means the location of holderLegendView on the chartSurface. */
    SCILegendPositionLeft   = 1 << 0,
    SCILegendPositionRight  = 1 << 1,
    SCILegendPositionTop    = 1 << 2,
    SCILegendPositionBottom = 1 << 3,
    SCILegendPositionCenter = 1 << 4,
};

/**
 * @brief Variants of visability of data series on the legend.
 */
typedef NS_OPTIONS(NSUInteger, SCISourceMode) {
    SCISourceMode_AllSeries  = 0,
    
    /** It Means that on the legend will be shown only data series which are shown on chart surface. */
    SCISourceMode_AllVisibleSeries,
    
    /** It Means that on the legend will be shown only data series which are selected on chart surface. */
    SCISourceMode_SelectedSeries,
    
    /** It Means that on the legend will be shown only data series which are unselected on chart surface. */
    SCISourceMode_UnselectedSeries
};

@class SCILegendItem;

/**
 * Class SCILegendModifier - defines base functionality of legend modifier. e.g Defines a position, generates dataSource, orientation.
 */
@interface SCILegendModifierBase : SCIChartModifierBase <SCIThemeableProtocol>

/**
 * Position on surfaceChart. Default is SCILegendPositionTop|SCILegendPositionLeft.
 * @see SCILegendPosition
 */
@property (nonatomic) SCILegendPosition position;

/**
 * Orientation of content on the legend. Default is SCIOrientationVertical
 * @see SCIOrientation
 */
@property (nonatomic) SCIOrientation orientation;

/**
 * Filtering of which data series legend must be shown on the legend. Default is SCILegendShowSeriesAll.
 * @see SCILegendShowSeries
 */
@property (nonatomic) SCISourceMode sourceMode;

/**
 * Show check boxes. Default is YES.
 */
@property (nonatomic) BOOL showCheckBoxes;

/**
 * Show series marker. Default is YES.
 */
@property (nonatomic) BOOL showSeriesMarkers;

/**
 * Array of SCILegendItem which will be displayed on the legend.
 * @see SCILegendShowSeries
 */
@property (nonatomic) NSArray <SCILegendItem *> *dataSource;

/**
 * The root view of legend.
 */
@property (nonatomic, readonly) UIView *holderLegendView;

/**
 * Preferred max size of holder view for legend. You can limit size of frame for legend view by setting this property. Default CGSize(.0f, .0f) - means holder view will have max size equal to chartsurface view size.
 */
@property (nonatomic) CGSize preferredMaxSize; //

/**
 * @abstract Call the init for setting default position and orientation of the LegendView.
 * @param postition - defines a position of legend on chart surface, if it is set in SCILegendPositionNone, the legend will not be placed on chart surface.
 * @param orientation - defines orientation of content on the legend.
*/
- (instancetype)initWithPosition:(SCILegendPosition)postition andOrientation:(SCIOrientation)orientation;

/**
 * Call the method when need to define new location for the holderLegendView on the chart surface. It can be helpfull when you change size of the holderLegendView.
 */
- (void)layoutPositionOfHolderView;

/**
 * Method is called internal every time when modifier needs for new dataSource. So the method can be overrided if you want to generate your own data source. Don't forget to set generated datasource into @property (nonatomic) NSArray <SCILegendItem *> *dataSource
 */
- (void)generateDataSourceAndSetDataSource;

@end

/** @}*/
