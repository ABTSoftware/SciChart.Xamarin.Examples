using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCITooltipViewSetupBlock)(SCITooltipView *);
    delegate void SCITooltipViewSetupBlock(SCITooltipView arg0);
}