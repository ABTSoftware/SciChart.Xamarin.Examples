//
//  Range.h
//  SciChart
//
//  Created by Admin on 08.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Ranges
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIGenericType.h"

@class SCIDoubleRange;

/**
 @typedef SCIRangeClipMode
 @brief Enum defines range clipping modes
 @see SCIRange
 @field SCIRangeClipMode_MinMax range is clipped at min and max values
 
 @field SCIRangeClipMode_Max range is clipped only at max value
 
 @field SCIRangeClipMode_Min range is clipped only at min value
 */
typedef NS_ENUM(int, SCIRangeClipMode) {
    /** range is clipped at min and max values */
    SCIRangeClipMode_MinMax,
    /** range is clipped only at max value */
    SCIRangeClipMode_Max,
    /** range is clipped only at min value */
    SCIRangeClipMode_Min
};

/**
 @typedef SCIRangeType
 @brief Defines range types
 @field SCIRangeType_Numeric numeric range
 
 @field SCIRangeType_Date date time range
 
 @field SCIRangeType_Index index range
 
 @see SCIRange
 */
typedef NS_ENUM(int, SCIRangeType) {
    /** numeric range */
    SCIRangeType_Numeric,
    /** date time range */
    SCIRangeType_Date,
    /** index range */
    SCIRangeType_Index
};

/**
 @brief Defines protcol for ranges. Range is defined by min, max values and type
 */
@protocol SCIRangeProtocol ///
<NSObject>
/** @{ @} */

@required

/**
 @brief Returns range type (numeric, date time or index)
 @see SCIRangeType
 */
-(SCIRangeType) rangeType;

/**
 @brief Gets or sets min value for range
 @see SCIGenericType
 */
@property (nonatomic) SCIGenericType min;
/**
 @brief Gets or sets max value for range
 @see SCIGenericType
 */
@property (nonatomic) SCIGenericType max;
/**
 @brief Returns difference between max and min values
 @see SCIGenericType
 */
-(SCIGenericType) diff;
/**
 @brief Return true if difference between max and min is zero
 */
-(BOOL) isZero;

/**
 @brief Converts range to SCIDoubleRange
 @see SCIDoubleRange
 */
-(SCIDoubleRange*) asDoubleRange;

/**
 @brief Method sets min and max values for range
 @see SCIGenericType
 */
-(void) setMinTo:(SCIGenericType)min MaxTo:(SCIGenericType)max;
/**
 @brief Method sets min and max values for range and clips values to limits
 @param min SCIGenericType min value
 @param max SCIGenericType max value
 @limits SCIRange resulting min and max can not be out of this range
 @see SCIGenericType
 */
-(void) setMinTo:(SCIGenericType)min MaxTo:(SCIGenericType)max WithLimits:(id<SCIRangeProtocol>)limits;
/**
 @brief Multiplies min and max values of current range. Returns self
 @param min min multiplier
 @param max max multiplier
 */
-(id<SCIRangeProtocol>) growMinBy:(SCIGenericType)min MaxBy:(SCIGenericType)max;
/**
 @brief Clips range to maximum range. Return self
 */
-(id<SCIRangeProtocol>) clipTo:(id<SCIRangeProtocol>)maximumRange;
/**
 @brief Returns true if value is greater than min and lesser than max of range
 */
-(BOOL) isValueWithinTheRange:(SCIGenericType)value;

/**
 @brief Returns true if range is defines. Usually it means that max greater than min and min and max is not NaN
 */
-(BOOL) isDefined;

/**
 @brief Compares range instance to another range and returhns true if they are equal
 */
-(BOOL) equals:(__unsafe_unretained id<SCIRangeProtocol>)otherRange;

/**
 @brief Returns new range as union of two ranges. Min is minimal from two ranges and max is maximal from two ranges
 */
-(id<SCIRangeProtocol>) unionWith:(__unsafe_unretained id<SCIRangeProtocol>)range;
/**
 @brief Creates copy of range
 */
-(id<SCIRangeProtocol>) clone;
/**
 @brief Check if min lesser than max and throw exception if not
 */
-(void) assertMinLessOrEqualToThanMax;
/**
 @brief Enlarges current range with logarithmic scaling
 */
-(id<SCIRangeProtocol>) growMinBy:(SCIGenericType)minFraction MaxBy:(SCIGenericType)maxFraction isLogarithmic:(BOOL)isLogarithmic LogBase:(double)logBase;

@end

/** @}*/
