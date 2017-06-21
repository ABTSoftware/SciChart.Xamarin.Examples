using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIThemeColorProvider : NSObject<SCIThemeProviderProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIThemeColorProvider : SCIThemeProviderProtocol
    {
        // - (id)initWithThemeKey:(SCIThemeKey)themeKey;
        [Export("initWithThemeKey:")]
        IntPtr Constructor(SCIThemeKey themeKey);
    }
}