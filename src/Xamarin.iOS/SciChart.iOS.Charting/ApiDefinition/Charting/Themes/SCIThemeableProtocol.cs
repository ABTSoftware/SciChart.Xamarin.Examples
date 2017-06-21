using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIThemeableProtocol { }

    // @protocol SCIThemeableProtocol<NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIThemeableProtocol
    {
        // - (void)applyThemeProvider:(id<SCIThemeProviderProtocol>)themeProvider;
        [Abstract]
        [Export("applyThemeProvider:")]
        void ApplyThemeProvider(ISCIThemeProviderProtocol themeProvider);
    }
}