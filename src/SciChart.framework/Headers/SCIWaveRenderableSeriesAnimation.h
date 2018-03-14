//
//  SCIAppendColumnRenderableSeriesAnimation.h
//  SciChart
//
//  Created by Gkol on 10/25/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Animations
 *  @{
 */

#import "SCIAnimation.h"
#import "SCIRenderableSeriesAnimationProtocol.h"
#import "SCIOhlcRenderableSeriesAnimationProtocol.h"
#import "SCIMountainRenderableSeriesAnimationProtocol.h"
#import "SCIColumnRenderableSeriesAnimationProtocol.h"
#import "SCIScatterRenderableSeriesAnimationProtocol.h"
#import "SCICandleStickRenderableSeriesAnimationProtocol.h"
#import "SCIStackedSeriesCollectionAnimnationProtocol.h"
#import "SCIBubbleRenderableSeriesAnimationProtocol.h"
#import "SCIBandRenderableSeriesAnimationProtocol.h"
#import "SCIErrorBarsRenderableSeriesAnimationProtocol.h"
#import "SCIFixedErrorBarsRenderableSeriesAnimationProtocol.h"

/**
 Make wave effect when data is changed.
 */
@interface SCIWaveRenderableSeriesAnimation : SCIAnimation <SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIColumnRenderableSeriesAnimationProtocol, SCIScatterRenderableSeriesAnimationProtocol, SCIOhlcRenderableSeriesAnimationProtocol, SCICandleStickRenderableSeriesAnimationProtocol, SCIStackedSeriesCollectionAnimnationProtocol, SCIBubbleRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol, SCIErrorBarsRenderableSeriesAnimationProtocol, SCIFixedErrorBarsRenderableSeriesAnimationProtocol>

/**
 Wave duration before next point is started to animate. Default is 0.5.
 Means that when half way of current wave is drawn then next wave is started to draw.
 */
@property (nonatomic) float durationOfStepData;

@end

/** @}*/
