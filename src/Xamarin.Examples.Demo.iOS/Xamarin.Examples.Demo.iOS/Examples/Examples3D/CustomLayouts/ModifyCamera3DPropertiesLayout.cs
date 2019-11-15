using Foundation;
using ObjCRuntime;
using SciChart.iOS.Charting;
using System;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    public partial class ModifyCamera3DPropertiesLayout : UIView, IISCICameraUpdateListener
    {
        public SCIChartSurface3D SurfaceView => Surface;

        public UISegmentedControl Projection => ProjectionMode;
        public UISegmentedControl Coordinates => CoordinatesMode;

        public UISlider Pitch => PitchSlider;
        public UISlider Yaw => YawSlider;
        public UISlider Radius => RadiusSlider;
        public UISlider FOV => FOVSlider;
        public UISlider Height => HeightSlider;
        public UISlider Width => WidthSlider;

        public ModifyCamera3DPropertiesLayout(IntPtr handle) : base(handle) { }

        public static ModifyCamera3DPropertiesLayout Create()
        {
            var pointersArray = NSBundle.MainBundle.LoadNib("ModifyCamera3DPropertiesLayout", null, null);
            var view = Runtime.GetNSObject<ModifyCamera3DPropertiesLayout>(pointersArray.ValueAt(0));

            return view;
        }

        public void OnCameraUpdated(IISCICameraController camera)
        {
            PitchSlider.Value = ConstrainAngle(camera.OrbitalPitch);
            YawSlider.Value = ConstrainAngle(camera.OrbitalYaw);
            RadiusSlider.Value = camera.Radius;
            FOVSlider.Value = camera.FieldOfView;
            HeightSlider.Value = camera.OrthoHeight;
            WidthSlider.Value = camera.OrthoWidth;
            ProjectionMode.SelectedSegment = camera.ProjectionMode == SCICameraProjectionMode.Perspective ? 0 : 1;
            CoordinatesMode.SelectedSegment = SurfaceView.Viewport.IsLeftHandedCoordinateSystem ? 0 : 1;

            PositionLabel.Text = $"Position: [X = {camera.Position.X:F1}; Y = {camera.Position.Y:F1}; Z = {camera.Position.Z:F1}]";
            PitchLabel.Text = $"Pitch: [{PitchSlider.Value:F1}]";
            YawLabel.Text = $"Yaw: [{YawSlider.Value:F1}]";
            RadiusLabel.Text = $"Radius: [{RadiusSlider.Value:F1}]";
            FOVLabel.Text = $"FOV: [{FOVSlider.Value:F1}]";
            HeightLabel.Text = $"Width: [{HeightSlider.Value:F1}]";
            WidthLabel.Text = $"Height: [{WidthSlider.Value:F1}]";
        }

        public void UpdateWithIsPerspective(bool isPerspective)
        {
            RadiusSlider.Hidden = RadiusLabel.Hidden = !isPerspective;
            FOVSlider.Hidden = FOVLabel.Hidden = !isPerspective;

            HeightSlider.Hidden = HeightLabel.Hidden = isPerspective;
            WidthSlider.Hidden = WidthLabel.Hidden = isPerspective;
        }

        private static float ConstrainAngle(float angle)
        {
            if (angle < 0)
            {
                angle += 360;
            }
            else if (angle > 360)
            {
                angle -= 360;
            }

            return angle;
        }
    }
}