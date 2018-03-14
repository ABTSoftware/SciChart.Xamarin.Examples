//
//  SCICandleStickRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 10/1/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"
#import "SCIOhlcPointSeriesAnimatorProtocol.h"

@class SCIFastCandlestickRenderableSeries;

/**
 Interface of animations for Candle Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIFastCandlestickRenderableSeries.
 */
@protocol SCICandleStickRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIOhlcPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateCandleStickRenderableSeries:(nonnull SCIFastCandlestickRenderableSeries*)renderableSeries;
@end

/** @}*/
