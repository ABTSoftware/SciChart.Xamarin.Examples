//
//  SCIBubbleRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 10/1/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"
#import "SCIXyzPointSeriesAnimatorProtocol.h"

@class SCIBubbleRenderableSeries;

/**
 Interface of animations for Bubble Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIBubbleRenderableSeries.
 */
@protocol SCIBubbleRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIXyzPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateBubbleRenderableSeries:(nonnull SCIBubbleRenderableSeries*)renderableSeries;
@end

/** @}*/
