using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Modify Camera3D Properties", description: "Demonstrates the properties of the Camera3D", icon: ExampleIcon.ZoomPan)]
    class ModifyCamera3DPropertiesViewController : CustomLayoutViewController<ModifyCamera3DPropertiesLayout>
    {
        public SCIChartSurface3D Surface => Layout.SurfaceView;

        protected override void CommonInit()
        {
            Layout.Pitch.ValueChanged += (sender, args) => Surface.Camera.OrbitalPitch = Layout.Pitch.Value;
            Layout.Yaw.ValueChanged += (sender, args) => Surface.Camera.OrbitalYaw= Layout.Yaw.Value;
            Layout.Radius.ValueChanged += (sender, args) => Surface.Camera.Radius = Layout.Radius.Value;
            Layout.FOV.ValueChanged += (sender, args) => Surface.Camera.FieldOfView= Layout.FOV.Value;
            Layout.Height.ValueChanged += (sender, args) => Surface.Camera.OrthoHeight = Layout.Height.Value;
            Layout.Width.ValueChanged += (sender, args) => Surface.Camera.OrthoWidth = Layout.Width.Value;

            Layout.Projection.ValueChanged += (sender, args) =>
            {
                if (Layout.Projection.SelectedSegment == 0)
                {
                    Surface.Camera.ToPerspective();
                }
                else
                {
                    Surface.Camera.ToOrhtogonal();
                }
                Layout.UpdateWithIsPerspective(Layout.Projection.SelectedSegment == 0);
            };
            Layout.Coordinates.ValueChanged += (sender, args) => Surface.Viewport.IsLeftHandedCoordinateSystem = Layout.Coordinates.SelectedSegment == 0;

            Layout.UpdateWithIsPerspective(true);
        }

        protected override void InitExample()
        {
            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D();
                Surface.YAxis = new SCINumericAxis3D();
                Surface.ZAxis = new SCINumericAxis3D();
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
                Surface.Camera.SetCameraUpdateListener(Layout);
            }
        }
    }
}