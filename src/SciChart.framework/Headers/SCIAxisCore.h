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
