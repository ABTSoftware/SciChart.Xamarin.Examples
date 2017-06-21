using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCICallbackHelper : NSObject <ISCICallbackHelperProtocol>
    [BaseType(typeof(NSObject))]
    interface SCICallbackHelper : SCICallbackHelperProtocol
    {
    }
}