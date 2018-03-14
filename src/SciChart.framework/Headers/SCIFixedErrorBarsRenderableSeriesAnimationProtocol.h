//
//  SCIFixedErrorBarsRenderableSeriesAnimationProtocol.h
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

@class SCIFastFixedErrorBarsRenderableSeries;

/**
 Interface of animations for Fixed Error Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIFastFixedErrorBarsRenderableSeries.
 */
@protocol SCIFixedErrorBarsRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIHlcPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateFixedErrorBarsRenderableSeries:(nonnull SCIFastFixedErrorBarsRenderableSeries*)renderableSeries;
@end

/** @}*/
