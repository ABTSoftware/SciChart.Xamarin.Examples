//
//  SCIOhlcPointSeriesAnimator.h
//  SciChart
//
//  Created by Gkol on 10/4/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import <Foundation/Foundation.h>

@class SCIOhlcPointSeries;
/**
 Interface of animator for ohlc point series.
 */
@protocol SCIOhlcPointSeriesAnimatorProtocol <NSObject>
/**
 Method for animating ohlc point series.
 
 @param pointSeries Final point series which should be when animation is finished
 @param previousPointSeries Last point series before the animation is started
 @return Point series for current progress of animation.
 */
- (nullable SCIOhlcPointSeries*)animateOhlcPointSeries:(nullable SCIOhlcPointSeries*)pointSeries withPreviousPointSeries:(nullable SCIOhlcPointSeries*)previousPointSeries;
@end

/** @}*/
