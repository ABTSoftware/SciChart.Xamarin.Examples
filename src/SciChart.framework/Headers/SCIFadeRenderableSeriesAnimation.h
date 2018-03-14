//
//  SCIFadeRenderableSeriesAnimation.h
//  SciChart
//
//  Created by Gkol on 10/27/17.
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
 Fade animation changes opacity of renderble series from 0 - 1.0.
 */
@interface SCIFadeRenderableSeriesAnimation : SCIAnimation <SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIColumnRenderableSeriesAnimationProtocol, SCIScatterRenderableSeriesAnimationProtocol, SCIOhlcRenderableSeriesAnimationProtocol, SCICandleStickRenderableSeriesAnimationProtocol, SCIStackedSeriesCollectionAnimnationProtocol, SCIBubbleRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol, SCIErrorBarsRenderableSeriesAnimationProtocol, SCIFixedErrorBarsRenderableSeriesAnimationProtocol>

@end

/** @}*/
