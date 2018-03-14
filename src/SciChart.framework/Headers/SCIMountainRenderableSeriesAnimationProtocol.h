//
//  SCIMountainRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 10/1/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"

@class SCIBaseMountainRenderableSeries;

/**
 Interface of animations for Mountain Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIBaseMountainRenderableSeries, SCIFastMountainRenderableSeries.
 */
@protocol SCIMountainRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateMountainRenderableSeries:(nonnull SCIBaseMountainRenderableSeries*)renderableSeries;
@end

/** @}*/
