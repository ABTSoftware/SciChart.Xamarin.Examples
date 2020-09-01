using Android.Views;
using Android.Widget;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using Xamarin.Examples.Demo;
using System;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Modify Camera3D Properties", description: "Demonstrates the properties of the Camera3D", icon: ExampleIcon.ZoomPan)]
    class ModifyCamera3DPropertiesFragment : ExampleBaseFragment, ICameraUpdateListener
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Chart3D_Camera_Properies_Fragment;

        private TextView Position => View.FindViewById<TextView>(Resource.Id.positionText);

        private SeekBar Yaw => View.FindViewById<SeekBar>(Resource.Id.yawSeekBar);
        private SeekBar Pitch => View.FindViewById<SeekBar>(Resource.Id.pitchSeekBar);
        private SeekBar Radius => View.FindViewById<SeekBar>(Resource.Id.radiusSeekBar);
        private SeekBar Fov => View.FindViewById<SeekBar>(Resource.Id.fovSeekBar);
        private SeekBar OrthoWidth => View.FindViewById<SeekBar>(Resource.Id.orthoWidthSeekBar);
        private SeekBar OrthoHeight => View.FindViewById<SeekBar>(Resource.Id.orthoHeightSeekBar);

        private LinearLayout PerspectiveLayout => View.FindViewById<LinearLayout>(Resource.Id.perspectiveProperties);
        private LinearLayout OrthogonalLayout => View.FindViewById<LinearLayout>(Resource.Id.orthogonalProperties);


        protected override void InitExample()
        {
            SetUpUi();

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D();
                Surface.YAxis = new NumericAxis3D();
                Surface.ZAxis = new NumericAxis3D();

                Surface.Camera = new Camera3D();

                Surface.Camera.SetCameraUpdateListener(this);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D()
                };
            }
        }

        private void SetUpUi()
        {
            Pitch.ProgressChanged += (s, e) =>
            {
                Surface.Camera.OrbitalPitch = e.Progress;
            };

            Yaw.ProgressChanged += (s, e) =>
            {
                Surface.Camera.OrbitalYaw = e.Progress;
            };

            Radius.ProgressChanged += (s, e) =>
            {
                Surface.Camera.Radius = e.Progress;
            };
            
            Fov.ProgressChanged += (s, e) =>
            {
                Surface.Camera.FieldOfView = e.Progress;
            };

            OrthoWidth.ProgressChanged += (s, e) =>
            {
                Surface.Camera.OrthoWidth = e.Progress;
            };

            OrthoHeight.ProgressChanged += (s, e) =>
            {
                Surface.Camera.OrthoHeight = e.Progress;
            };

            View.FindViewById<Button>(Resource.Id.lhsRadioButton).Click += (s, e) =>
            {
                Surface.IsLeftHandedCoordinateSystem = true;
            };

            View.FindViewById<Button>(Resource.Id.rhsRadioButton).Click += (s, e) =>
            {
                Surface.IsLeftHandedCoordinateSystem = false;
            };

            View.FindViewById<Button>(Resource.Id.perspectiveRadioButton).Click += (s, e) =>
            {
                Surface.Camera.ToPerspective();

                PerspectiveLayout.Visibility = ViewStates.Visible;
                OrthogonalLayout.Visibility = ViewStates.Gone;
            };

            View.FindViewById<Button>(Resource.Id.orthogonalRadioButton).Click += (s, e) =>
            {
                Surface.Camera.ToOrthogonal();

                PerspectiveLayout.Visibility = ViewStates.Gone;
                OrthogonalLayout.Visibility = ViewStates.Visible;
            };

            OrthogonalLayout.Visibility = ViewStates.Gone;

            UpdateUIWithValuesFrom(Surface.Camera);
        }

        public void OnCameraUpdated(ICameraController camera)
        {
            Surface.Camera.OrbitalPitch = ConstrainAngle(Surface.Camera.OrbitalPitch);
            Surface.Camera.OrbitalYaw = ConstrainAngle(Surface.Camera.OrbitalYaw);

            Activity.RunOnUiThread(() => {
                UpdateUIWithValuesFrom(camera);
            });
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

        private void UpdateUIWithValuesFrom(ICameraController camera)
        {
            var pos = camera.Position;
            Position.Text = $"Position: X={pos.GetX():0.0}, Y={pos.GetY():0.0}, Z={pos.GetZ():0.0}";
            
            TrySetSeekBarProgress(Pitch, camera.OrbitalPitch);
            TrySetSeekBarProgress(Yaw, camera.OrbitalYaw);
            TrySetSeekBarProgress(Radius, camera.Radius);
            TrySetSeekBarProgress(Fov, camera.FieldOfView);
            TrySetSeekBarProgress(OrthoWidth, camera.OrthoWidth);
            TrySetSeekBarProgress(OrthoHeight, camera.OrthoHeight);
        }

        private void TrySetSeekBarProgress(SeekBar seekBar, float value)
        {
            var progress = (int)Math.Round(value);
            if(seekBar.Progress != progress)
            {
                seekBar.Progress = progress;
            }
        }
    }
}