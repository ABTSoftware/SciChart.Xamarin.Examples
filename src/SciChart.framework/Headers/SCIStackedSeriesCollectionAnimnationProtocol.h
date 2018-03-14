//
//  SCIStackedSeriesCollectionAnimnationProtocol.h
//  SciChart
//
//  Created by Gkol on 10/9/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"
#import "SCIXyyPointSeriesAnimatorProtocol.h"

@class SCIStackedMountainRenderableSeries;
@class SCIStackedColumnRenderableSeries;

/**
 Interface of animations for Stacked collection. Should be implemented in animation class which can be used with such default renderable series like: .
 */
@protocol SCIStackedSeriesCollectionAnimnationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIXyyPointSeriesAnimatorProtocol, SCIPointSeriesAnimatorProtocol>

/**
 Animate stacked mountain renderable series style according current progress.
 */
- (void)animateStackedMountainRenderableSeries:(nonnull SCIStackedMountainRenderableSeries*)renderableSeries;

/**
 Animate stacked column renderable series style according current progress.
 */
- (void)animateStackedColumnRenderableSeries:(nonnull SCIStackedColumnRenderableSeries*)renderableSeries;
@end

/** @}*/
