using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIChartModifierBase : NSObject <SCIChartModifierProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIChartModifierBase : SCIChartModifierProtocol
    {
        // @property (nonatomic) BOOL autoPassAreaCheck;
        [Export("autoPassAreaCheck")]
        bool AutoPassAreaCheck { get; set; }
    }
}