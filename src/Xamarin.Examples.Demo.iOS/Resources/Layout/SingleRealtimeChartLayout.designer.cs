// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Xamarin.Examples.Demo.iOS.Resources.Layout
{
    [Register ("SingleRealtimeChartLayout")]
    partial class SingleRealtimeChartLayout
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PauseButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ResetButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StartButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface Surface { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PauseButton != null) {
                PauseButton.Dispose ();
                PauseButton = null;
            }

            if (ResetButton != null) {
                ResetButton.Dispose ();
                ResetButton = null;
            }

            if (StartButton != null) {
                StartButton.Dispose ();
                StartButton = null;
            }

            if (Surface != null) {
                Surface.Dispose ();
                Surface = null;
            }
        }
    }
}