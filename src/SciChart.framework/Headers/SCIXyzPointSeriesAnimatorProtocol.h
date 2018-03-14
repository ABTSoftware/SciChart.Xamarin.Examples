//
//  SCIXyzPointSeriesAnimatorProtocol.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 10/15/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import <Foundation/Foundation.h>

@class SCIXyzPointSeries;
/**
 Interface of animator for xyz point series.
 */
@protocol SCIXyzPointSeriesAnimatorProtocol <NSObject>

/**
 Method for animating xyz point series.
 
 @param pointSeries Final point series which should be when animation is finished
 @param previousPointSeries Last point series before the animation is started
 @return Point series for current progress of animation.
 */
- (nullable SCIXyzPointSeries*)animateXyzPointSeries:(nullable SCIXyzPointSeries*)pointSeries withPreviousPointSeries:(nullable SCIXyzPointSeries*)previousPointSeries;
@end

/** @}*/
