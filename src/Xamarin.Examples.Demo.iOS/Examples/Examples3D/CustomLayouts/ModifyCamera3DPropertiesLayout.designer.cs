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
    [Register ("ModifyCamera3DPropertiesLayout")]
    partial class ModifyCamera3DPropertiesLayout
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl CoordinatesMode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FOVLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider FOVSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HeightLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider HeightSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PitchLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider PitchSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PositionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl ProjectionMode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RadiusLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider RadiusSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SciChart.iOS.Charting.SCIChartSurface3D Surface { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WidthLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider WidthSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel YawLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider YawSlider { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CoordinatesMode != null) {
                CoordinatesMode.Dispose ();
                CoordinatesMode = null;
            }

            if (FOVLabel != null) {
                FOVLabel.Dispose ();
                FOVLabel = null;
            }

            if (FOVSlider != null) {
                FOVSlider.Dispose ();
                FOVSlider = null;
            }

            if (HeightLabel != null) {
                HeightLabel.Dispose ();
                HeightLabel = null;
            }

            if (HeightSlider != null) {
                HeightSlider.Dispose ();
                HeightSlider = null;
            }

            if (PitchLabel != null) {
                PitchLabel.Dispose ();
                PitchLabel = null;
            }

            if (PitchSlider != null) {
                PitchSlider.Dispose ();
                PitchSlider = null;
            }

            if (PositionLabel != null) {
                PositionLabel.Dispose ();
                PositionLabel = null;
            }

            if (ProjectionMode != null) {
                ProjectionMode.Dispose ();
                ProjectionMode = null;
            }

            if (RadiusLabel != null) {
                RadiusLabel.Dispose ();
                RadiusLabel = null;
            }

            if (RadiusSlider != null) {
                RadiusSlider.Dispose ();
                RadiusSlider = null;
            }

            if (Surface != null) {
                Surface.Dispose ();
                Surface = null;
            }

            if (WidthLabel != null) {
                WidthLabel.Dispose ();
                WidthLabel = null;
            }

            if (WidthSlider != null) {
                WidthSlider.Dispose ();
                WidthSlider = null;
            }

            if (YawLabel != null) {
                YawLabel.Dispose ();
                YawLabel = null;
            }

            if (YawSlider != null) {
                YawSlider.Dispose ();
                YawSlider = null;
            }
        }
    }
}