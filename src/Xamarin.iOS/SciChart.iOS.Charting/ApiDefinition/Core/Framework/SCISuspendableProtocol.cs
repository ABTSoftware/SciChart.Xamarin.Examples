using Foundation;

namespace SciChart.iOS.Charting
{
    interface ISCISuspendableProtocol { }

    // @protocol SCISuspendableProtocol
    [Protocol, Model]
    interface SCISuspendableProtocol
    {
        // @required -(BOOL)isSuspended;
        [Abstract]
        [Export("isSuspended")]
        bool IsSuspended { get; }

        // @required -(id<SCIUpdateSuspenderProtocol> _Nonnull)suspendUpdates;
        [Abstract]
        [Export("suspendUpdates")]
        ISCIUpdateSuspenderProtocol SuspendUpdates();

        // @required -(void)resumeUpdates:(id<SCIUpdateSuspenderProtocol> _Nonnull)suspender;
        [Abstract]
        [Export("resumeUpdates:")]
        void ResumeUpdates(ISCIUpdateSuspenderProtocol suspender);

        // @required -(void)decrementSuspend;
        [Abstract]
        [Export("decrementSuspend")]
        void DecrementSuspend();
    }
}