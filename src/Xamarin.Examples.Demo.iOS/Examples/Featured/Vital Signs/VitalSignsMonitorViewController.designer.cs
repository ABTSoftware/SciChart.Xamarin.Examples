// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Xamarin.Examples.Demo.iOS
{
    [Register ("VitalSignsMonitorViewController")]
    partial class VitalSignsMonitorViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Xamarin.Examples.Demo.iOS.StepProgressBar BloodPressureBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BloodPressureValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BloodVolumeValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BpmValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView HeartImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SpoClockLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SpoValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface Surface { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Xamarin.Examples.Demo.iOS.StepProgressBar SvBar1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Xamarin.Examples.Demo.iOS.StepProgressBar SvBar2 { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BloodPressureBar != null) {
                BloodPressureBar.Dispose ();
                BloodPressureBar = null;
            }

            if (BloodPressureValueLabel != null) {
                BloodPressureValueLabel.Dispose ();
                BloodPressureValueLabel = null;
            }

            if (BloodVolumeValueLabel != null) {
                BloodVolumeValueLabel.Dispose ();
                BloodVolumeValueLabel = null;
            }

            if (BpmValueLabel != null) {
                BpmValueLabel.Dispose ();
                BpmValueLabel = null;
            }

            if (HeartImageView != null) {
                HeartImageView.Dispose ();
                HeartImageView = null;
            }

            if (SpoClockLabel != null) {
                SpoClockLabel.Dispose ();
                SpoClockLabel = null;
            }

            if (SpoValueLabel != null) {
                SpoValueLabel.Dispose ();
                SpoValueLabel = null;
            }

            if (Surface != null) {
                Surface.Dispose ();
                Surface = null;
            }

            if (SvBar1 != null) {
                SvBar1.Dispose ();
                SvBar1 = null;
            }

            if (SvBar2 != null) {
                SvBar2.Dispose ();
                SvBar2 = null;
            }
        }
    }
}