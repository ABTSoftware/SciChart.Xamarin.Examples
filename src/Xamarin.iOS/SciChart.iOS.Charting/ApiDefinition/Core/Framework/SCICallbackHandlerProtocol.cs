using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCICallbackHandlerProtocol { }

    // @protocol SCICallbackHandlerProtocol
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCICallbackHandlerProtocol
    {
        // @required -(void)addCallback:(id<ISCICallbackHelperProtocol>)callback;
        [Abstract]
        [Export("addCallback:")]
        void AddCallback(ISCICallbackHelperProtocol callback);

        // @required -(void)removeCallback:(id<ISCICallbackHelperProtocol>)callback;
        [Abstract]
        [Export("removeCallback:")]
        void RemoveCallback(ISCICallbackHelperProtocol callback);

        // @required @property (nonatomic, strong) NSMutableArray * callbacks;
        [Abstract]
        [Export("callbacks", ArgumentSemantic.Strong)]
        NSMutableArray Callbacks { get; set; }
    }
}