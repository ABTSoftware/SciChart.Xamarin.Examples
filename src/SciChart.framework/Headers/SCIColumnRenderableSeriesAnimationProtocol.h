//
//  SCIColumnRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 10/1/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"

@class SCIBaseColumnRenderableSeries;

/**
 Interface of animations for Column Renderable Series. Should be implemented in animation class which can be used with such default renderable series like: SCIBaseColumnRenderableSeries, SCIFastColumnRenderableSeries.
 */
@protocol SCIColumnRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateColumnRenderableSeries:(nonnull SCIBaseColumnRenderableSeries*)renderableSeries;
@end

/** @}*/
