//
//  SCIScatterRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 10/1/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"

@class SCIXyScatterRenderableSeries;

/**
 Interface of animations for Scatter Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIXyScatterRenderableSeries.
 */
@protocol SCIScatterRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateScatterRenderableSeries:(nonnull SCIXyScatterRenderableSeries*)renderableSeries;
@end

/** @}*/
