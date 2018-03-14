//
//  SCIRenderableSeriesAnimationProtocol.h
//  SciChart
//
//  Created by Gkol on 9/29/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import "SCIAnimation.h"

@protocol SCIRenderableSeriesProtocol, SCIPointSeriesProtocol, SCICoordinateCalculatorProtocol;

/**
 Base protocol for all animations of renderable series.
 */
@protocol SCIBaseRenderableSeriesAnimationProtocol <SCIAnimationProtocol>

/**
 Parent renderable series is set when add it int renderable series.
 */
@property (nonatomic, nullable, weak) id<SCIRenderableSeriesProtocol> parentRenderableSeries;

@end

/**
 Interface of animator for xy point series.
 */
@protocol SCIPointSeriesAnimatorProtocol <NSObject>

/**
 Method for animating xy point series.

 @param pointSeries Final point series which should be when animation is finished
 @param previousPointSeries last point series before the animation is started
 @return Point series for current progress of animation.
 */
- (nullable id<SCIPointSeriesProtocol>)animatePointSeries:(nullable id<SCIPointSeriesProtocol>)pointSeries withPreviousPointSeries:(nullable id<SCIPointSeriesProtocol>)previousPointSeries;
@end

/**
 Interface of animations for base renderable series. Should be implemented in animation class which can be used with such default renderable series like: SCIFastLineRenderableSeries.
 */
@protocol SCIRenderableSeriesAnimationProtocol <SCIBaseRenderableSeriesAnimationProtocol, SCIPointSeriesAnimatorProtocol>

/**
 Animate renderable series style according current progress.
 */
- (void)animateRenderableSeries:(nonnull id<SCIRenderableSeriesProtocol>)renderableSeries;
@end

/** @}*/
