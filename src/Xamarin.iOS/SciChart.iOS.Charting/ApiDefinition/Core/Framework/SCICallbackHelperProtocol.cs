using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCICallbackHelperProtocol { }

    // @protocol ISCICallbackHelperProtocol
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCICallbackHelperProtocol
    {
        // @required -(void)setParentHandler:(SCICallbackHandler *)parent;
        [Abstract]
        [Export("setParentHandler:")]
        void SetParentHandler(SCICallbackHandler parent);

        // @required -(void)remove;
        [Abstract]
        [Export("remove")]
        void Remove();
    }
}