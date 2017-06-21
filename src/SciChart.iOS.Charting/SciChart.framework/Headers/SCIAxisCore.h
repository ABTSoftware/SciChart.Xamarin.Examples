//
//  AxisCore.h
//  SciChart
//
//  Created by Admin on 10.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIInvalidatableElement.h"
#import "SCIGenericType.h"
#import "SCIAxisCoreProtocol.h"
#import "SCIRangeChangedCallbackHelper.h"

#pragma mark - SCIAxisCore default implementation

@class SCITickCoordinates;
@protocol SCIDeltaCalculatorProtocol;
@protocol SCITickCoordinatesProviderProtocol;
@protocol SCILabelProviderProtocol;
@class SCIAxisResizeAnimationHelper;
@class SCIRangeChangedCallbackHandler;

/**
 * @brief Provides base class for 2D Axis types throughout the SciChart SDK
 */
@interface SCIAxisCore : NSObject <SCIAxisCoreProtocol> {
    @protected
    __weak id<SCIChartSurfaceProtocol> _parentSurface;
}

/**
 * Gets or sets the parent that this Axis belongs to
 * @see SCIChartSurfaceProtocol
 */
@property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;

/**
 * Gets or sets the axis title
 */
@property (nonatomic, copy) NSString * axisTitle;

/**
 * Gets or sets a flag indicating whether to flip the tick and pixel coordinate generation for this axis, causing the axis ticks to decrement and chart to be flipped in the axis direction
 */
@property (nonatomic) BOOL flipCoordinates;

/**
 * Gets or sets the TextFormatting string for tick labels on this axis. Should be C format string
 */
@property (nonatomic, copy) NSString * textFormatting;

/**
 * Gets or sets the minimal zoom constrain of the axis
 * @discussion Used to set the minimum distance between Min and Max of the VisibleRange
 */
@property (nonatomic) SCIGenericType minimalZoomConstrain;

/**
 * Gets or sets the maximum zoom constrain of the axis
 * @discussion Used to set the maximum distance between Min and Max of the VisibleRange
 */
@property (nonatomic) SCIGenericType maximalZoomConstrain;

/**
 * Gets or sets the number of minor delta ticks per major tick
 */
@property (nonatomic) int minorsPerMajor; // minor ticks count between major ticks

/**
 * Gets or sets the max ticks
 */
@property (nonatomic) int maxAutoTicks; // max amount of major ticks

/**
 * Gets or sets value, that indicates whether calculate ticks automatically. Default is true
 */
@property (nonatomic) BOOL autoTicks; // if disabled minorDelta and majorDelta are not calculated and have to be set manually

/**
 * Gets or sets a SCITickProvider instance on current axis
 * Used to compute the data-values of axis gridlines, ticks and labels
 */
@property (nonatomic, strong) id<SCITickProviderProtocol> tickProvider;

/**
 * Gets or sets AutoRange mode
 * @see SCIAutoRange
 */
@property (nonatomic) SCIAutoRange autoRange;

/**
 * Gets or sets the text formatting string for labels on this cursor. Should be C format string
 */
@property (nonatomic, copy) NSString * cursorTextFormatting;

/**
 * Gets or sets whether the current axis is an X-Axis or not
 */
@property (nonatomic) BOOL isXAxis;

/**
 * Gets or sets a SCITickCoordinatesProvider instance on current axis
 * @discussion Used to transform the data-values received from TickProvider instance to the coordinates for Axis gridlines, ticks and labels drawing
 */
@property (nonatomic, strong) id<SCITickCoordinatesProviderProtocol> tickCoordinatesProvider;

/**
 * Gets or sets whether current Axis is a static axis
 */
@property (nonatomic) BOOL isStaticAxis;

/**
 * Gets or sets a SCILabelProvider instance
 * @discussion Used to programmatically override the formatting of text and cursor labels
 */
@property (nonatomic, strong) id<SCILabelProviderProtocol> labelProvider;

/**
 * Gets or sets the animated VisibleRange of the Axis
 * @discussion When this property is set, the axis animates the Visible Range to the new value over a duration
 */
@property (nonatomic) BOOL animateVisibleRangeChanges;

/**
 * Gets or sets the Duration used when animates the visible range of the axis to the destination visible range
 * @see SCIRange
 */
@property (nonatomic) double animatedChangeDuration;

/** 
 * Gets a value indicating whether this instance is a category axis
 */
- (BOOL)isCategoryAxis;

/** Returns an undefined SCIRange, called internally by SciChart to reset the Visible Range of an axis to an undefined state
 * @see SCIRangeProtocol
 */
- (id<SCIRangeProtocol>)getUndefinedRange;

/** Returns a defulat non zero SCIRange, called internally by SciChart to reset the Visible Range of an axis to an undefined state
 * @see SCIRangeProtocol
 */
- (id<SCIRangeProtocol>)getDefaultNonZeroRange;

/**
 * Checks whether the range is of valid type for this axis
 * @param range Range to check
 */
- (BOOL)isRangeOfValidType:(id<SCIRangeProtocol>)range;

/**
 * When overridden in derived class, changes value of the VisibleRange according to axis requirements before it is applied
 */
- (void)coerceVisibleRange;

/**
 * Checks if the VisibleRange is valid, e.g. is not nil, the difference between Max and Min is positive
 */
- (BOOL)isVisibleRangeValid;

/**
 * Overridden by derived types, called internally to calculate MinorTicks, MajorTicks before Axis drawing
 */
- (SCITickCoordinates *)CalculateTicks;

/**
 * Calculates the deltas for use in this render pass
 */
- (void)calculateDelta;

/**
 * Returns an instance of a SCIDeltaCalculator which is used to compute the data-values of MajorDelta, MinorDelta
 * @discussion Overridden by derived types to allow calculations specific to that axis type
 * @return SCIDeltaCalculatorProtocol instance
 */
- (id<SCIDeltaCalculatorProtocol>)getDeltaCalculator;

/**
 * Calculates max auto ticks amount, which is >= 1
 */
- (uint)getMaxAutoTicks;

/**
 * Asserts the type passed in is supported by the current axis implementation
 * @param range Range type
 * @see SCIDataType
 */
- (void)assertRangeType:(id<SCIRangeProtocol>)range;


/**
 @brief Axis visible range changes callback controller.
 @discussion For internal use.
 */
@property (nonatomic) SCIRangeChangedCallbackHandler * rangeCallbackHandler;

@end

/** @}*/
