//
//  AxisBase.h
//  SciChart
//
//  Created by Admin on 10.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIAxisCore.h"
#import "SCIAxis2DProtocol.h"
#import "SCIThemeableProtocol.h"

@class SCIAxisParams;
@protocol SCIRenderSurfaceProtocol;
@class SCIArrayController;

/**
 * @brief Provides base functionality for Axes throughout SciChart
 */
@interface SCIAxisBase : SCIAxisCore <SCIAxis2DProtocol, SCIThemeableProtocol> {
@protected
    id <SCICoordinateCalculatorProtocol> _currentCoordinateCalculator;
    id <SCIAxisInteractivityHelperProtocol> _currentInteractivityHelper;
    SCIArrayController *_supportedTypes;
}

+ (NSString *)defaultAxisId;

/**
 * Defines the minimum distance to the edge of the chart to cull axis labels
 */
- (int)minDistanceToBounds;

/**
 @brief Method is used for adding some grow by to default zero range.
 @discussion By default growth of zero range is 0.01 in min and max direction. This is needed because actual zero range is impossible to draw, and once set it would be impossible to interact with such axis with modifiers.
 */
- (double)zeroRangeGrowBy;

/**
 *  Get the RenderSurface instance off the parent SCIChartSurface
 */
- (id <SCIRenderSurfaceProtocol>)renderSurface;

/**
 @brief Method enlarges default zero range a little with zeroRangeGrowBy.
 @discussion Method is called when internal calculations returns zero range, for example for maximum range.
 */
- (id <SCIRangeProtocol>)coerceZeroRange:(id <SCIRangeProtocol>)maximumRange;

/**
 @brief Returns a list of types which current axis is designed to work with
 @return SCIArrayController which contains list of supported SCIDataType
 @see SCIArrayController
 @see SCIDataType
 */
- (SCIArrayController *)getSupportedTypes;

/**
 * Gets an SCIAxisParams instance with info about the current axis setup
 * @see SCIAxisParams
 */
- (SCIAxisParams *)getAxisParams;

@property(nonatomic) BOOL isLicenseValid;

/**
 * Called internal to draw gridlines before Axis drawing
 */
- (void)drawGridLinesWithContext:(id <SCIRenderContext2DProtocol>)renderContext WithCoordinates:(SCITickCoordinates *)tickCoords;

/**
 * Called internal to draw axis ticks before Axis drawing
 */
- (void)onDrawAxis:(SCITickCoordinates *)tickCoords;

/**
 * Returns an offset for the axis
 */
- (double)getOffsetForLabels;

/**
 * Gets the data-value from tick
 * @param value Tick
 * @return SCIGenericType
 * @see SCIGenericType
 */
- (SCIGenericType)convertTickToDataValue:(SCIGenericType)value;

/**
 * Called internal to draw axis area before Axis drawing
 */
- (void)drawAxisAreaWithContext:(id <SCIRenderContext2DProtocol>)renderContext;

/**
 * Called internal to prepare gridlines before Axis drawing
 */
- (BOOL)prepareToDrawGridLines:(id <SCIRenderContext2DProtocol>)renderContext;

/**
 * Called internal to draw bands before Axis drawing
 */
- (void)drawBandsWithContext:(id <SCIRenderContext2DProtocol>)renderContext;

/**
 * Called internal to draw minor gridlines before Axis drawing
 */
- (void)drawMinorGridLinesWithContext:(id <SCIRenderContext2DProtocol>)renderContext;

/**
 * Called internal to draw major gridlines before Axis drawing
 */
- (void)drawMajorGridLinesWithContext:(id <SCIRenderContext2DProtocol>)renderContext;

@end

/** @}*/
