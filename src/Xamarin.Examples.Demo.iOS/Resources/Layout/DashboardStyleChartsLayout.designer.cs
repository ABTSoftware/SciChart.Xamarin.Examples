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
    [Register ("DashboardStyleChartsLayout")]
    partial class DashboardStyleChartsLayout
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface Chart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl ChartSelector { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Chart != null) {
                Chart.Dispose ();
                Chart = null;
            }

            if (ChartSelector != null) {
                ChartSelector.Dispose ();
                ChartSelector = null;
            }
        }
    }
}