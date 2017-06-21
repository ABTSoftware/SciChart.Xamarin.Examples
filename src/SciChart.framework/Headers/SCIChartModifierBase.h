//
//  SCIChartModifierBase.h
//  SciChart
//
//  Created by Admin on 04.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCIChartModifierProtocol.h"

@protocol SCIChartSurfaceProtocol;
@protocol SCIAxis2DProtocol;
@class SCIAxisCollection;

@interface SCIChartModifierBase : NSObject <SCIChartModifierProtocol>

@property (nonatomic) BOOL isEnabled;

@property (nonatomic) BOOL isAttached;

@property (nonatomic, copy) NSString *modifierName;

@property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;

-(SCIAxisCollection*) xAxes;
-(SCIAxisCollection*) yAxes;

-(id<SCIAxis2DProtocol>) xAxis;
-(id<SCIAxis2DProtocol>) yAxis;

-(id<SCIAxis2DProtocol>) getXAxis:(NSString*)axisName;
-(id<SCIAxis2DProtocol>) getYAxis:(NSString*)axisName;

@property (nonatomic) BOOL autoPassAreaCheck;

@end

/** @}*/
