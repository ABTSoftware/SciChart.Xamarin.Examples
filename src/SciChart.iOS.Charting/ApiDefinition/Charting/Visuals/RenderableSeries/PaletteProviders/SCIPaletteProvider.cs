using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIPaletteProvider : NSObject <SCIPaletteProviderProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIPaletteProvider : SCIPaletteProviderProtocol
    {
    }
}