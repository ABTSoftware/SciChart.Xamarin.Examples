using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Surface Mesh 3D Floor Ceiling", description: "Add Contour Meshes to the Floor and Ceiling", icon: ExampleIcon.Surface3D)]
    class SurfaceMeshFloorAndCeiling3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            const int xSize = 11;
            const int zSize = 4;

            var dataSeries3D = new UniformGridDataSeries3D<double, double, double>(xSize, zSize) { StartX = 0, StepX = 0.09, StartZ = 0, StepZ = 0.75 };

            var data = new double[,]
            {
                {-1.43, -2.95, -2.97, -1.81, -1.33, -1.53, -2.04, 2.08, 1.94, 1.42, 1.58},
                {1.77, 1.76, -1.1, -0.26, 0.72, 0.64, 3.26, 3.2, 3.1, 1.94, 1.54},
                {0, 0, 0, 0, 0, 3.7, 3.7, 3.7, 3.7, -0.48, -0.48},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            for (int z = 0; z < zSize; z++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    dataSeries3D.UpdateYAt(x, z, data[z, x]);
                }
            }

            var colors = new[] { 0xFF1D2C6B, ColorUtil.Blue, ColorUtil.Cyan, ColorUtil.GreenYellow, ColorUtil.Yellow, ColorUtil.Red, ColorUtil.DarkRed };
            var stops = new[] { 0, .1f, .2f, .4f, .6f, .8f, 1 };

            var rs0 = new SCISurfaceMeshRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                HeightScaleFactor = 0,
                DrawMeshAs = SCIDrawMeshAs.SolidWireframe,
                Stroke = 0xFF228B22,
                StrokeThickness = 1f,
                Maximum = 4,
                MeshColorPalette = new SCIGradientColorPalette(colors, stops),
                Opacity = 0.7f
            };

            var rs1 = new SCISurfaceMeshRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                DrawMeshAs = SCIDrawMeshAs.SolidWireframe,
                Stroke = 0xFF228B22,
                StrokeThickness = 1f,
                Maximum = 4,
                DrawSkirt = false,
                MeshColorPalette = new SCIGradientColorPalette(colors, stops),
                Opacity = 0.9f
            };

            var rs2 = new SCISurfaceMeshRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                HeightScaleFactor = 0,
                DrawMeshAs = SCIDrawMeshAs.SolidWireframe,
                Stroke = 0xFF228B22,
                StrokeThickness = 1f,
                Maximum = 4,
                YOffset = 400,
                MeshColorPalette = new SCIGradientColorPalette(colors, stops),
                Opacity = 0.7f
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { MaxAutoTicks = 7 };
                Surface.YAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-4, 4) };
                Surface.ZAxis = new SCINumericAxis3D();
                Surface.RenderableSeries.Add(rs0);
                Surface.RenderableSeries.Add(rs1);
                Surface.RenderableSeries.Add(rs2);
                Surface.ChartModifiers.Add(new SCIPinchZoomModifier3D());
                Surface.ChartModifiers.Add(new SCIOrbitModifier3D());
                Surface.ChartModifiers.Add(new SCIZoomExtentsModifier3D { ResetPosition = new SCIVector3(-1300, 1300, -1300) });

                Surface.Camera = new SCICamera3D { Position = new SCIVector3(-1300, 1300, -1300) };
                Surface.WorldDimensions.AssignX(1100, 400, 400);
            }
        }
    }
}