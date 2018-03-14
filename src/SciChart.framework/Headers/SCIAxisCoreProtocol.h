/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIInvalidatableElement.h"
#import "SCIGenericType.h"
#import "SCIRangeChangedCallbackHelper.h"
#import "SCISuspendableProtocol.h"

@protocol SCIRangeProtocol;
@protocol SCICoordinateCalculatorProtocol;
@protocol SCITickProviderProtocol;
@protocol SCIChartSurfaceProtocol;
@class UIView;

/**
 * @typedef SCIAutoRange
 * @abstract Enumeration constants to define the the autorange behaviour for Axis implementers
 * @discussion Possible values:
 * @discussion - SCIAutoRange_Once Allows Axis instance decide whether autorange or not when show Axis first time, e.g. if the current VisibleRange is nil or undefined
 * @discussion - SCIAutoRange_Always Autorange the Axis instance always
 * @discussion - SCIAutoRange_Never Never autoranges the Axis instance
 */
typedef NS_ENUM(int, SCIAutoRange) {
    /**
     * Allows Axis instance decide whether AutoRange or not when show Axis first time,
     * e.g. if the current VisibleRange is nil or undefined
     */
    SCIAutoRange_Once,

    /**
     * AutoRange the Axis instance always
     */
    SCIAutoRange_Always,

    /**
    * Never AutoRange the Axis instance
    */
    SCIAutoRange_Never,
};

#pragma mark - SCIAxisCore protocol

/**
 * @brief Defines protocol for Axis core functionality
 * @extends SCIInvalidatableElementProtocol
 */
@protocol SCIAxisCoreProtocol ///
        <NSObject, SCIInvalidatableElementProtocol, SCISuspendableProtocol>
/** @{ @} */

/**
 * Gets or sets the VisibleRange of the Axis
 * @see SCIChartSurface
 * @see SCIRangeProtocol
 */
@property(nonatomic, strong) id <SCIRangeProtocol> visibleRange;

/**
 * Gets or sets the GrowBy (0.1, 0.2) will increase the axis extents by 10% (min) and 20% (max) outside of the data range
 * @see SCIRangeProtocol
 */
@property(nonatomic, strong) id <SCIRangeProtocol> growBy; // <double>
/**
 * @brief Gets or sets axis minor ticks spacing
 * @see SCIGenericType
 */
@property(nonatomic) SCIGenericType minorDelta;

/**
 * @brief Gets or sets axis major ticks spacing
 * @see SCIGenericType
 */
@property(nonatomic) SCIGenericType majorDelta;

/**
 * @brief Method calculates axis' maximal visible range based on all renderable series' data attached to that axis
 * @see SCIRangeProtocol
 */
- (id <SCIRangeProtocol>)getMaximumRange;

/**
 * Gets or sets the parent that this Axis belongs to
 * @see SCIChartSurfaceProtocol
 */
@property(nonatomic, weak) id <SCIChartSurfaceProtocol> parentSurface;

/**
 * Gets or sets the axis title
 */
@property(nonatomic, copy) NSString *axisTitle;

/**
 * Gets or sets a flag indicating whether to flip the tick and pixel coordinate generation for this axis, causing the axis ticks to decrement and chart to be flipped in the axis direction
 */
@property(nonatomic) BOOL flipCoordinates;

/**
 * Gets or sets the TextFormatting string for tick labels on this axis
 */
@property(nonatomic, copy) NSString *textFormatting;

/**
 * Gets or sets the minimal zoom constrain of the axis
 * @discussion Used to set the minimum distance between Min and Max of the VisibleRange
 */
@property(nonatomic) SCIGenericType minimalZoomConstrain;

/**
 * Gets or sets the maximum zoom constrain of the axis
 * @discussion Used to set the maximum distance between Min and Max of the VisibleRange
 */
@property(nonatomic) SCIGenericType maximalZoomConstrain;

/**
 * Gets or sets the number of minor delta ticks per major tick
 * minor ticks count between major ticks
 */
@property(nonatomic) int minorsPerMajor;

/**
 * Gets or sets the max ticks
 */
@property(nonatomic) int maxAutoTicks;

/**
 * Gets or sets value, that indicates whether calculate ticks automatically. Default is true
 */
@property(nonatomic) BOOL autoTicks;

/**
 * Gets or sets a SCITickProvider instance on current axis
 * Used to compute the data-values of axis gridlines, ticks and labels
 */
@property(nonatomic, strong) id <SCITickProviderProtocol> tickProvider;

/**
 * Gets or sets AutoRange mode
 * @see SCIAutoRange
 */
@property(nonatomic) SCIAutoRange autoRange;

/**
 * Gets or sets the text formatting string for labels on this cursor
 */
@property(nonatomic, copy) NSString *cursorTextFormatting;

/**
 * Gets or sets whether the current axis is an logarithmic or not
 */
- (BOOL)isLogarithmicAxis;

/**
 * Gets whether VisibleRange is valid, e.g. is not nil, the difference between Max and Min is positive
 */
- (BOOL)hasValidVisibleRange;

/** Gets whether Axis has default visible range*/
- (BOOL)hasDefaultVisibleRange;

/**
 * Gets or sets whether the current axis is an X-Axis or not
 */
@property(nonatomic) BOOL isXAxis;

/**
 * Animates the visible range of the axis to the destination visible range, over the specified duration
 * @param to The end range
 * @param duration The duration of the animation
 */
- (void)animateVisibleRangeTo:(id <SCIRangeProtocol>)to AnimationTime:(float)duration;

- (void)animateVisibleRangeTo:(id <SCIRangeProtocol>)to AnimationTime:(float)duration andVelocity:(float)velocity;
- (void)animateVisibleRangeTo:(id<SCIRangeProtocol>)to AnimationTime:(float)duration velocity:(float)velocity rangeLimit:(id<SCIRangeProtocol>)rangeLimit;

/**
 * Gets or sets the animated VisibleRange of the Axis
 * @discussion When this property is set, the axis animates the Visible Range to the new value over a duration
 */
@property(nonatomic) BOOL animateVisibleRangeChanges;

/**
 * Gets or sets the Duration used when animates the visible range of the axis to the destination visible range
 * @see SCIRange
 */
@property(nonatomic) double animatedChangeDuration;

/**
 * @brief Method set visible range for axis. Visible range change is animated if animateVisibleRangeChanges is true and animatedChangeDuration is not zero
 */
- (BOOL)trySetOrAnimateVisibleRange:(id <SCIRangeProtocol>)newRange;

/**
 * @brief Method set visible range for axis. Visible range change is animated if duration is not zero
 */
- (BOOL)trySetOrAnimateVisibleRange:(id <SCIRangeProtocol>)newRange duration:(float)duration;

/**
 * Gets whether the passed range is valid
 * @param range Passed range, that should be validated
 */
- (BOOL)isValidRange:(id <SCIRangeProtocol>)range;

/**
 * Called to check the axis properties are valid for rendering
 */
- (void)validateAxis;

/**
 * Gets the current SCICoordinateCalculator for this axis, based on visible range and axis type
 */
- (id <SCICoordinateCalculatorProtocol>)getCurrentCoordinateCalculator;

/**
 * Gets the size of the axis in the Viewport
 */
- (double)getAxisSize;

/**
 * Gets the coordinate from data-value
 * @param value Data-value to be converted
 * @see SCIGenericType
 */
- (double)getCoordinate:(SCIGenericType)value;

/**
 * Gets the data-value from coordinate
 * @param pixelCoordinate Coordinate
 * @return SCIGenericType
 * @see SCIGenericType
 */
- (SCIGenericType)getDataValue:(double)pixelCoordinate;

/**
 * Returns the offset of the Axis
 */
- (double)getAxisOffset;

/**
 * Method stops all axis internal timers used for animations
 */
- (void)free;

/**
 * Called when visible range is changed
 * @code
 let callback: SCIAxisVisibleRangeChanged = {newRange, oldRange, isAnimated, sender in
 // do important stuff here...
 }
 self.chartSurface.xAxis.registerVisibleRangeChangedCallback(callback)
 * @endcode
 */
- (id <SCICallbackHelperProtocol>)registerVisibleRangeChangedCallback:(SCIAxisVisibleRangeChanged)callback;

/**
 * Gets or sets Title's custom view
 */
@property(nonatomic) UIView* titleCustomView;

@end

/** @}*/
