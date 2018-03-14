using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCICallbackHandlerProtocol { }

    // @protocol SCICallbackHandlerProtocol
    [Protocol, Model]
    interface SCICallbackHandlerProtocol
    {
        // @required -(void)addCallback:(id<SCICallbackHelperProtocol>)callback;
        [Abstract]
        [Export("addCallback:")]
        void AddCallback(ISCICallbackHelperProtocol callback);

        // @required -(void)removeCallback:(id<SCICallbackHelperProtocol>)callback;
        [Abstract]
        [Export("removeCallback:")]
        void RemoveCallback(ISCICallbackHelperProtocol callback);

        // @required @property (nonatomic, strong) NSMutableArray * callbacks;
        [Abstract]
        [Export("callbacks", ArgumentSemantic.Strong)]
        NSMutableArray Callbacks { get; set; }
    }
}