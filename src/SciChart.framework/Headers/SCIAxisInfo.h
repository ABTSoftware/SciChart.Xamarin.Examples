//
//  AxisInfo.h
//  SciChart
//
//  Created by Admin on 16.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Axis
 *  @{
 */

#import <Foundation/Foundation.h>
#import <QuartzCore/QuartzCore.h>
#import "SCIAxisEnums.h"
#import "SCIGenericType.h"

@class SCITooltipDataView;

@interface SCIAxisInfo : NSObject

@property (nonatomic, copy) NSString * axisId;
@property (nonatomic, copy) NSString * axisTitle;
@property (nonatomic) SCIAxisAlignment axisAlignment;
@property (nonatomic) SCIGenericType dataValue;
@property (nonatomic, copy) NSString * axisFormattedDataValue;
@property (nonatomic) BOOL isHorizontal;
@property (nonatomic) BOOL isXAxis;
@property (nonatomic, copy) NSString * cursorFormattedDataValue;
@property (nonatomic) BOOL isMasterChartAxis;
@property (nonatomic) CGRect frame;
@property (nonatomic) NSNumberFormatter *numberFormatter;
@property (nonatomic) NSDateFormatter *dateTimeFormatter;

-(SCITooltipDataView *) createAxisDataView;

@end

/** @}*/
