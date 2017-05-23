// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    [Register ("UsingThemeManagerLayout")]
    partial class UsingThemeManagerLayout
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface Surface { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ThemeButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Surface != null) {
                Surface.Dispose ();
                Surface = null;
            }

            if (ThemeButton != null) {
                ThemeButton.Dispose ();
                ThemeButton = null;
            }
        }
    }
}