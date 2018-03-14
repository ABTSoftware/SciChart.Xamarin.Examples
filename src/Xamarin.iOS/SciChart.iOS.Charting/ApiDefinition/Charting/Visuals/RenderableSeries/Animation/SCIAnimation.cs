using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIAnimationFinishBlock)();
    delegate void SCIAnimationFinishBlock();

    interface ISCIAnimationProtocol {}

    // @protocol SCIAnimationProtocol
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIAnimationProtocol
    {
        // @required -(instancetype _Nonnull)initWithDuration:(float)duration curveAnimation:(SCIAnimationCurve)curveType;

        //[Export("initWithDuration:curveAnimation:")]
        //IntPtr Constructor(float duration, SCIAnimationCurve curveType);

        // @required -(void)start;
        [Abstract]
        [Export("start")]
        void Start();

        // @required -(void)startAfterDelay:(float)delay;
        [Abstract]
        [Export("startAfterDelay:")]
        void StartAfterDelay(float delay);

        // @required -(void)stop;
        [Abstract]
        [Export("stop")]
        void Stop();

        // @required -(BOOL)isFinished;
        [Abstract]
        [Export("isFinished")]
        bool IsFinished();

        // @required -(BOOL)isRunning;
        [Abstract]
        [Export("isRunning")]
        bool IsRunning();

        // @required -(BOOL)isStopped;
        [Abstract]
        [Export("isStopped")]
        bool IsStopped();

        // @required -(void)animateWithDisplayLinkTimeStamp:(float)timeStamp;
        [Abstract]
        [Export("animateWithDisplayLinkTimeStamp:")]
        void AnimateWithDisplayLinkTimeStamp(float timeStamp);

        // @required @property (nonatomic) BOOL repeatable;
        [Abstract]
        [Export("repeatable")]
        bool Repeatable { get; set; }

        // @required @property (readonly, nonatomic) float currentProgress;
        [Abstract]
        [Export("currentProgress")]
        float CurrentProgress { get; }

        // @required @property (readonly, nonatomic) float duration;
        [Abstract]
        [Export("duration")]
        float Duration { get; }

        // @required @property (readonly, nonatomic) float timePassed;
        [Abstract]
        [Export("timePassed")]
        float TimePassed { get; }

        // @required @property (nonatomic) SCIAnimationFinishBlock _Nullable completionHandler;
        [Abstract]
        [NullAllowed, Export("completionHandler", ArgumentSemantic.Assign)]
        SCIAnimationFinishBlock CompletionHandler { get; set; }
    }

    // @interface SCIAnimation <SCIAnimationProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIAnimation : SCIAnimationProtocol
    {
        // @required -(instancetype _Nonnull)initWithDuration:(float)duration curveAnimation:(SCIAnimationCurve)curveType;
        [Export("initWithDuration:curveAnimation:")]
        IntPtr Constructor(float duration, SCIAnimationCurve curveType);
    }
}