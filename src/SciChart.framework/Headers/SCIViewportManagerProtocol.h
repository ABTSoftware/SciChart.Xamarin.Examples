//
//  SCIViewPortManager.h
//  SciChart
//
//  Created by Admin on 28.07.15.
//  Copyright (c) 2015 SciChart Ltd. All rights reserved.
//

/** \addtogroup Visuals
 *  @{
 */

#import "SCIInvalidatableElement.h"

@protocol SCIAxis2DProtocol;
@protocol SCIRangeProtocol;
@class SCIRenderPassInfo;
@protocol SCIChartSurfaceProtocol;

#pragma mark - SCIViewPortManagee Protocol

/**
 @extends SCIInvalidatableElementProtocol
 */
@protocol SCIViewportManagerProtocol ///
        <NSObject, SCIInvalidatableElementProtocol>
/** @{ @} */

- (BOOL)isAttached;

- (id <SCIRangeProtocol>)calculateNewYAxisRange:(id <SCIAxis2DProtocol>)yAxis WithInfo:(SCIRenderPassInfo *)renderPassInfo;

- (id <SCIRangeProtocol>)calculateNewXAxisRange:(id <SCIAxis2DProtocol>)xAxis;

- (id <SCIRangeProtocol>)calculateAutoRange:(id <SCIAxis2DProtocol>)axis;

- (void)attachSciChartSurface:(id <SCIChartSurfaceProtocol>)scs;

- (void)detachSciChartSurface;

- (void)zoomExtents;

- (void)animateZoomExtents:(float)duration;

- (void)zoomExtentsY;

- (void)animateZoomExtentsY:(float)duration;

- (void)zoomExtentsX;

- (void)animateZoomExtentsX:(float)duration;

- (void)autorangeAxes;

@end