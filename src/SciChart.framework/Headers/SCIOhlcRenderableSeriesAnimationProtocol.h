//
//  SCIOhlcRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 9/29/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"
#import "SCIOhlcPointSeriesAnimatorProtocol.h"

@class SCIFastOhlcRenderableSeries;

/**
 Interface of animations for Ohlc Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIFastOhlcRenderableSeries.
 */
@protocol SCIOhlcRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIOhlcPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateOhlcRenderableSeries:(nonnull SCIFastOhlcRenderableSeries*)renderableSeries;
@end

/** @}*/
