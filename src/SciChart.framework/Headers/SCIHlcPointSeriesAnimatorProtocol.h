//
//  SCIHlcPointSeriesAnimatorProtocol.h
//  SciChart
//
//  Created by Hrybeniuk Mykola on 10/15/17.
//  Copyright © 2017 SciChart. All rights reserved.
//
/** \addtogroup Animations
 *  @{
 */
#import <Foundation/Foundation.h>

@class SCIHlcPointSeries;
/**
 Interface of animator for hlc point series.
 */
@protocol SCIHlcPointSeriesAnimatorProtocol <NSObject>

/**
 Method for animating hlc point series.
 
 @param pointSeries Final point series which should be when animation is finished
 @param previousPointSeries Last point series before the animation is started
 @return Point series for current progress of animation.
 */
- (nullable SCIHlcPointSeries*)animateHlcPointSeries:(nullable SCIHlcPointSeries*)pointSeries withPreviousPointSeries:(nullable SCIHlcPointSeries*)previousPointSeries;
@end

/** @}*/
