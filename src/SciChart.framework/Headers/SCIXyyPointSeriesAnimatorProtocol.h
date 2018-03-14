//
//  SCIXyyPointSeriesAnimatorProtocol.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 10/15/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import <Foundation/Foundation.h>

@class SCIXyyPointSeries;
/**
 Interface of animator for xyy point series.
 */
@protocol SCIXyyPointSeriesAnimatorProtocol <NSObject>

/**
 Method for animating xyy point series.
 
 @param pointSeries Final point series which should be when animation is finished
 @param previousPointSeries Last point series before the animation is started
 @return Point series for current progress of animation.
 */
- (nullable SCIXyyPointSeries*)animateXyyPointSeries:(nullable SCIXyyPointSeries*)pointSeries withPreviousPointSeries:(nullable SCIXyyPointSeries*)previousPointSeries;
@end

/** @}*/
