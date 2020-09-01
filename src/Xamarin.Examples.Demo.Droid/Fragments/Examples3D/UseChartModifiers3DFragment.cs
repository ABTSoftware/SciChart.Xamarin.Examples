using Android.Widget;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Xyz;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.PointMarkers;
using SciChart.Charting3D.Visuals.RenderableSeries.Scatter;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using System;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Use Chart Modifiers 3D", description: "Demonstrates PinchZoomModifier3D, OrbitModifier3D and ZoomExtentsModifier3D", icon: ExampleIcon.ZoomPan)]
    class UseChartModifiers3DFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Chart3D_Modifiers_Fragment;

        protected override void InitExample()
        {
            View.FindViewById<Button>(Resource.Id.rotateHorizontal).Click += (sender, args) =>
            {
                var yaw = Surface.Camera.OrbitalYaw;
                if(yaw < 360)
                {
                    Surface.Camera.OrbitalYaw = yaw + 90;
                }
                else
                {
                    Surface.Camera.OrbitalYaw = 360 - yaw;
                }
            };
            View.FindViewById<Button>(Resource.Id.rotateVertical).Click += (sender, args) =>
            {
                var pitch = Surface.Camera.OrbitalPitch;
                if (pitch < 89)
                {
                    Surface.Camera.OrbitalPitch = pitch + 90;
                }
                else
                {
                    Surface.Camera.OrbitalPitch = -90;
                }
            };

            const int count = 25;
            
            var dataManager = DataManager.Instance;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new PointMetadataProvider3D();
            for (int x = 0; x < count; x++)
            {
                var color = dataManager.GetRandomColor();
                for (int z = 1; z < count; z++)
                {
                    var y = Math.Pow(z, 0.3);

                    dataSeries3D.Append(x, y, z);
                    metadataProvider.Metadata.Add(new PointMetadata3D(color, 2));
                }
            }

            var pointMarker3D = new SpherePointMarker3D()
            {
                FillColor = Color.Lime,
                Size = 5f
            };

            var renderableSeries3D = new ScatterRenderableSeries3D()
            {
                PointMarker = pointMarker3D,
                DataSeries = dataSeries3D,
                MetadataProvider = metadataProvider
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.YAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.ZAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };

                Surface.Camera = new Camera3D();

                Surface.RenderableSeries.Add(renderableSeries3D);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D()
                };
            }
        }
    }
}