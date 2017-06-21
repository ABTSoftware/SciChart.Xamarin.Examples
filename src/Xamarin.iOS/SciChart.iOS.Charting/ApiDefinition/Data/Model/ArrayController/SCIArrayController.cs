using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIArrayController : NSObject <SCIArrayControllerProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIArrayController : ISCIArrayControllerProtocol
    {
    }
}