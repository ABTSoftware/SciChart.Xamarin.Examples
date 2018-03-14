//
//  SCIAppendRenderableSeriesAnimation.h
//  SciChart
//
//  Created by Gkol on 10/17/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Animations
 *  @{
 */

#import "SCIAnimation.h"
#import "SCIRenderableSeriesAnimationProtocol.h"
#import "SCIMountainRenderableSeriesAnimationProtocol.h"
#import "SCIBandRenderableSeriesAnimationProtocol.h"

/**
 Draw line of renderable series point by point.
 */
@interface SCISweepRenderableSeriesAnimation : SCIAnimation <SCIRenderableSeriesAnimationProtocol, SCIMountainRenderableSeriesAnimationProtocol, SCIBandRenderableSeriesAnimationProtocol>

@end

/** @}*/
