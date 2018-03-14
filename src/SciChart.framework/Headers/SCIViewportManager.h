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
#import "SCIViewportManagerProtocol.h"

@protocol SCIAxis2DProtocol;
@protocol SCIRangeProtocol;
@class SCIRenderPassInfo;

#pragma mark - SCIViewPortManage default implementation

@interface SCIViewportManager : NSObject <SCIViewportManagerProtocol>

- (id <SCIRangeProtocol>)onCalculateNewXRange:(id <SCIAxis2DProtocol>)xAxis;

- (id <SCIRangeProtocol>)onCalculateNewYRange:(id <SCIAxis2DProtocol>)yAxis RenderPassInfo:(SCIRenderPassInfo *)renderPassInfo;

@end

/** @}*/