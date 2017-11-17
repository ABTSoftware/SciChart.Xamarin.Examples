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
    [Register ("SinglePieChartViewLayout")]
    partial class SinglePieChartViewLayout
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIPieChartSurface Surface { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Surface != null) {
                Surface.Dispose ();
                Surface = null;
            }
        }
    }
}