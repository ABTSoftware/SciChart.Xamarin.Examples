using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIAnimationsControllerProtocol {}

    // @protocol SCIAnimationsController
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIAnimationsControllerProtocol
    {
        // @required -(instancetype)initWithAnimationsCollection:(id)animationsCollection;

        [Export("initWithAnimationsCollection:")]
        IntPtr Constructor(NSObject animationsCollection);

        // @required -(BOOL)isRunningAnimations;
        [Abstract]
        [Export("isRunningAnimations")]
        bool IsRunningAnimations();

        // @required -(bool)isAnimationsReadyToStart;
        [Abstract]
        [Export("isAnimationsReadyToStart")]
        bool IsAnimationsReadyToStart { get; }

        // @required -(void)animateWithDisplayLinkTimeStamp:(float)timeStamp;
        [Abstract]
        [Export("animateWithDisplayLinkTimeStamp:")]
        void AnimateWithDisplayLinkTimeStamp(float timeStamp);

        // @required -(void)startAnimations;
        [Abstract]
        [Export("startAnimations")]
        void StartAnimations();

        // @required -(void)stopAnimations;
        [Abstract]
        [Export("stopAnimations")]
        void StopAnimations();

        [Abstract]
        [Export("animations")]
        SCIObservableCollection Animations { get; set; }
    }

    // @interface SCIAnimationsController <SCIAnimationsControllerProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIAnimationsController : SCIAnimationsControllerProtocol
    {
    }
}
