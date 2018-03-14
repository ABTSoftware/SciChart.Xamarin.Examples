//
//  SCIAnimation.h
//  SciChart
//
//  Created by Gkol on 9/6/17.
//  Copyright © 2017 SciChart. All rights reserved.
//

/** \addtogroup Animations
 *  @{
 */

#import <UIKit/UIKit.h>


/**
 * @typedef SCIAnimationCurve
 * @abstract Enumeration constants to define the Animation drawing style
 * @discussion Possible values:
 * @discussion - SCIAnimationCurve_EaseInOut An animation is slow at beginning and end
 * @discussion - SCIAnimationCurve_EaseIn An animation is slow at the beginning
 * @discussion - SCIAnimationCurve_EaseOut An animation is slow at the end
 * @discussion - SCIAnimationCurve_Linear An animation is drawn linearly.
 * @discussion - SCIAnimationCurve_EaseInElastic Adds bouncing at the beginning
 * @discussion - SCIAnimationCurve_EaseOutElastic Adds bouncing at the end
 */
typedef NS_ENUM(NSUInteger, SCIAnimationCurve) {
    /** An animation is slow at beginning and end */
    SCIAnimationCurve_EaseInOut,
    /** An animation is slow at the beginning */
    SCIAnimationCurve_EaseIn,
    /** An animation is slow at the end */
    SCIAnimationCurve_EaseOut,
    /** An animation is drawn linearly. */
    SCIAnimationCurve_Linear,
    /** Adds bouncing at the beginning */
    SCIAnimationCurve_EaseInElastic,
    /** Adds bouncing at the end */
    SCIAnimationCurve_EaseOutElastic
};

typedef void(^SCIAnimationFinishBlock)();

/**
 Defined protocol of base animation implementation.
 */
@protocol SCIAnimationProtocol <NSObject>


/**
 Create new animation.

 @param duration Time in seconds.
 @param curveType Type of changing the current progress of the animation.
 @return Instance of an animation.
 */
- (nonnull instancetype)initWithDuration:(float)duration curveAnimation:(SCIAnimationCurve)curveType;


/**
 Immediatly starts executing of animation.
 Resets statused isFinished and isStopped into false. IsRunning into true.
 */
- (void)start;

/**
 Start the animation after delay.
 Resets statused isFinished and isStopped into false. IsRunning into true.
 @param delay Delay in seconds.
 */
- (void)startAfterDelay:(float)delay;

/**
 Stop the animation at current progress. after the animation isStopped but not finished.
 */
- (void)stop;

/**
 True only when animation is passed whole duration.
 @return Bool value
 */
- (BOOL)isFinished;

/**
 Return true when animation has been started but not finshed and not stopped.
 @return Bool value
 */
- (BOOL)isRunning;

/**
 Return true when user manully calls stop function.
 @return Bool value
 */
- (BOOL)isStopped;


/**
 Recalculate current progress of animation with current time stamp.

 @param timeStamp Time stamp in seconds of display link.
 */
- (void)animateWithDisplayLinkTimeStamp:(float)timeStamp;

/**
 Default is false. If repeatable is true then animation automatically starts again.
 */
@property (nonatomic) BOOL repeatable;

/**
 Current progress of the animation. starts from 0 ends 1.0. If animation has elastic effect then the value can cross the limits.
 */
@property (nonatomic, readonly) float currentProgress;

/**
 Whole duration of the animation in seconds.
 */
@property (nonatomic, readonly) float duration;

/**
 Passed time at the moment.
 */
@property (nonatomic, readonly) float timePassed;

/**
 Callback is called on finish.
 */
@property (nullable ,nonatomic) SCIAnimationFinishBlock completionHandler;

@end


/**
 Base implementation of animation. Calculate current progress depends on curve type and duration.
 */
@interface SCIAnimation : NSObject <SCIAnimationProtocol>

@end

/** @}*/
