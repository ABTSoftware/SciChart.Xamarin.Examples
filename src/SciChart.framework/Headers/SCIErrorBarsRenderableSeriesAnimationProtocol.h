//
//  SCIErrorBarsRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 10/1/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"
#import "SCIHlcPointSeriesAnimatorProtocol.h"

@class SCIFastErrorBarsRenderableSeries;

/**
 Interface of animations for Error Bars Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIFastErrorBarsRenderableSeries.
 */
@protocol SCIErrorBarsRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIHlcPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateErrorBarsRenderableSeries:(nonnull SCIFastErrorBarsRenderableSeries*)renderableSeries;
@end

/** @}*/
