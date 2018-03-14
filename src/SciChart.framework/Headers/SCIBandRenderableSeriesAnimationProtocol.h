//
//  SCIBandRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 10/1/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"
#import "SCIXyyPointSeriesAnimatorProtocol.h"

@class SCIFastBandRenderableSeries;

/**
 Interface of animations for Band Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIFastBandRenderableSeries.
 */
@protocol SCIBandRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIXyyPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateBandRenderableSeries:(nonnull SCIFastBandRenderableSeries*)renderableSeries;
@end

/** @}*/
