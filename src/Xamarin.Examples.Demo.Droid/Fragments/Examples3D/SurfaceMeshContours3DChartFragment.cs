using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Grid;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Data;
using SciChart.Charting3D.Visuals.RenderableSeries.SurfaceMesh;
using Xamarin.Examples.Demo;
using System;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Surface Mesh 3D with Contours", description: "Use the Contour API for SurfaceMesh", icon: ExampleIcon.Surface3D)]
    class SurfaceMeshContours3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            const int w = 64;
            const int h = 64;

            const double ratio = 200.0 / 64.0;

            var dataSeries3D = new UniformGridDataSeries3D<double, double, double>(w, h)
            {
                StepX = 0.01,
                StepZ = 0.01
            };

            for (int x = 0; x < w; x++)
            {
                for (int z = 0; z < h; z++)
                {
                    double v = (1 + Math.Sin(x * 0.04 * ratio)) * 50 + (1 + Math.Sin(z * 0.1)) * 50;
                    double cx = w / 2d;
                    double cy = h / 2d;
                    double r = Math.Sqrt((x - cx) * (x - cx) + (z - cy) * (z - cy)) * ratio;
                    double exp = Math.Max(0, 1 - r * 0.008);
                    double zValue = v * exp;

                    dataSeries3D.UpdateYAt(x, z, zValue);
                }
            }

            var colors = new Color[] { Color.Aqua, Color.Green, Color.ForestGreen, Color.DarkKhaki, Color.BurlyWood, Color.DarkSalmon, Color.GreenYellow, Color.DarkOrange, Color.SaddleBrown, Color.Brown, Color.Brown};
            var stops = new float[] { 0, .1f, .2f, .3f, .4f, .5f, .6f, .7f, .8f, .9f, 1 };

            var renderableSeries3D = new SurfaceMeshRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                DrawMeshAs = DrawMeshAs.SolidWithContours,
                StrokeColor = Color.FromArgb(0x77, 0x22, 0x8B, 0x22),
                StrokeThickness = 2f.ToDip(Activity),
                ContourStrokeThickness = 2f.ToDip(Activity),
                Maximum = 150,
                DrawSkirt = true,
                MeshColorPalette = new GradientColorPalette(colors, stops),
                Opacity = 0.8f
            };

            using (Surface.SuspendUpdates())
            {
                Surface.WorldDimensions.Assign(600, 300, 300);

                Surface.XAxis = new NumericAxis3D();
                Surface.YAxis = new NumericAxis3D();
                Surface.ZAxis = new NumericAxis3D();

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