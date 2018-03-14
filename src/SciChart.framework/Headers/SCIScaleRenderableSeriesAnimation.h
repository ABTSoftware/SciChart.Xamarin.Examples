//
//  SCIDataAppearAnimation.h
//  SciChart
//
//  Created by Gkol on 9/6/17.
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
 Animation stretch data from bottom to the top.
 */
@interface SCIScaleRenderableSeriesAnimation : SCIAnimation <SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIColumnRenderableSeriesAnimationProtocol, SCIScatterRenderableSeriesAnimationProtocol, SCIOhlcRenderableSeriesAnimationProtocol, SCICandleStickRenderableSeriesAnimationProtocol, SCIStackedSeriesCollectionAnimnationProtocol, SCIBubbleRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol, SCIErrorBarsRenderableSeriesAnimationProtocol, SCIFixedErrorBarsRenderableSeriesAnimationProtocol>

@end

/** @}*/
