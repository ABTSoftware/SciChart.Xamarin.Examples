using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIAxisVisibleRangeChanged)(id<SCIRangeProtocol>, id<SCIRangeProtocol>, BOOL, id);
    delegate void SCIAxisVisibleRangeChanged(ISCIRangeProtocol arg0, ISCIRangeProtocol arg1, bool arg2, NSObject arg3);

    // @interface SCIRangeChangedCallbackHelper : SCICallbackHelper
    [BaseType(typeof(SCICallbackHelper))]
    interface SCIRangeChangedCallbackHelper
    {
        // -(instancetype)initWithCallback:(SCIAxisVisibleRangeChanged)callback;
        [Export("initWithCallback:")]
        IntPtr Constructor(SCIAxisVisibleRangeChanged callback);

        // @property (copy, nonatomic) SCIAxisVisibleRangeChanged callback;
        [Export("callback", ArgumentSemantic.Copy)]
        SCIAxisVisibleRangeChanged Callback { get; set; }
    }
}