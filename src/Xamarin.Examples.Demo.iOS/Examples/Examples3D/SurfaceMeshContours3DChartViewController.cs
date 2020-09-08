using System;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Surface Mesh 3D with Contours", description: "Use the Contour API for SurfaceMesh", icon: ExampleIcon.Surface3D)]
    class SurfaceMeshContours3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            const int w = 64;
            const int h = 64;
            const double ratio = 200.0 / 64.0;

            var dataSeries3D = new UniformGridDataSeries3D<double, double, double>(w, h) { StepX = 0.01, StepZ = 0.01 };

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

            var rSeries3D = new SCISurfaceMeshRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                DrawMeshAs = SCIDrawMeshAs.SolidWithContours,
                Stroke = 0x77228B22,
                StrokeThickness = 2f,
                ContourStrokeThickness = 2f,
                Maximum = 150,
                DrawSkirt = true,
                MeshColorPalette = new SCIGradientColorPalette(
                    new[] { ColorUtil.Aqua, ColorUtil.Green, ColorUtil.ForestGreen, ColorUtil.DarkKhaki, ColorUtil.BurlyWood, ColorUtil.DarkSalmon, ColorUtil.GreenYellow, ColorUtil.DarkOrange, ColorUtil.SaddleBrown, ColorUtil.Brown, ColorUtil.Brown },
                    new[] { 0, .1f, .2f, .3f, .4f, .5f, .6f, .7f, .8f, .9f, 1 }),
                Opacity = 0.8f,
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D();
                Surface.YAxis = new SCINumericAxis3D();
                Surface.ZAxis = new SCINumericAxis3D();
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
                Surface.WorldDimensions.AssignX(600, 300, 300);
            }
        }
    }
}