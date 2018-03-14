using Foundation;

namespace SciChart.iOS.Charting
{
    interface ISCIUpdateSuspenderProtocol { }

    // @protocol SCIUpdateSuspenderProtocol <SCIDisposableProtocol>
    [Protocol, Model]
    interface SCIUpdateSuspenderProtocol : SCIDisposableProtocol
    {
        // @required -(BOOL)isSuspended;
        [Abstract]
        [Export("isSuspended")]
        bool IsSuspended { get; }

        // @required @property (nonatomic) BOOL resumeTargetOnClose;
        [Abstract]
        [Export("resumeTargetOnClose")]
        bool ResumeTargetOnClose { get; set; }
    }
}