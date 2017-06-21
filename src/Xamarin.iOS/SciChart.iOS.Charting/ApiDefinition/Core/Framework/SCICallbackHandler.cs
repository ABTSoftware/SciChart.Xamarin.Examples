using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCICallbackHandler : NSObject <SCICallbackHandlerProtocol>
    [BaseType(typeof(NSObject))]
    interface SCICallbackHandler : SCICallbackHandlerProtocol
    {
    }
}