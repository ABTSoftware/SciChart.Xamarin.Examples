using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCITickCoordinates : NSObject
    [BaseType(typeof(NSObject))]
    interface SCITickCoordinates
    {
        // -(BOOL)isEmpty;
        [Export("isEmpty")]
        bool IsEmpty { get; }
    }
}