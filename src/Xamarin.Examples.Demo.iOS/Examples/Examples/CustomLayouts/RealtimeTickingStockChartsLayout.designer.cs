// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    [Register ("RealtimeTickingStockChartsLayout")]
    partial class RealtimeTickingStockChartsLayout
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface MainSurface { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface OverviewSurface { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MainSurface != null) {
                MainSurface.Dispose ();
                MainSurface = null;
            }

            if (OverviewSurface != null) {
                OverviewSurface.Dispose ();
                OverviewSurface = null;
            }
        }
    }
}