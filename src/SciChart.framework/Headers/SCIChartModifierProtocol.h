//
//  SCIChartModifier.h
//  SciChart
//
//  Created by Admin on 04.08.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup ChartModifiers
 *  @{
 */

@class SCIAxisCollection;
@protocol SCIAxis2DProtocol;
@protocol SCIChartSurfaceProtocol;

/**
 */
@protocol SCIChartModifierProtocol ///
<NSObject>
/** @{ @} */

@property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;
@property (nonatomic) BOOL isAttached;
@property (nonatomic) BOOL isEnabled;
@property (nonatomic, copy) NSString *modifierName;

-(id<SCIAxis2DProtocol>) xAxis;
-(id<SCIAxis2DProtocol>) yAxis;
-(SCIAxisCollection*) xAxes;
-(SCIAxisCollection*) yAxes;
-(id<SCIAxis2DProtocol>) getXAxis:(NSString*)axisId;
-(id<SCIAxis2DProtocol>) getYAxis:(NSString*)axisId;

-(void) resetInertia;
-(void)draw;
-(void) onAttached;
-(void) onDetached;

@property (nonatomic) BOOL autoPassAreaCheck;

@end

/** @}*/
