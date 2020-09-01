using SciChart.Charting3D.Common.Math;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Grid;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Data;
using SciChart.Charting3D.Visuals.RenderableSeries.SurfaceMesh;
using SciChart.Data.Model;
using Xamarin.Examples.Demo;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Surface Mesh 3D Floor Ceiling", description: "Add Contour Meshes to the Floor and Ceiling", icon: ExampleIcon.Surface3D)]
    class SurfaceMeshFloorAndCeiling3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            const int xSize = 11;
            const int zSize = 4;

            var dataSeries3D = new UniformGridDataSeries3D<double, double, double>(xSize, zSize)
            {
                StartX = 0,
                StepX = 0.09,
                StartZ = 0,
                StepZ = 0.75
            };

            var data = new double[,]{
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

            var colors = new Color[] { Color.FromArgb(0x1D, 0x2C, 0x6B), Color.Blue, Color.Cyan, Color.GreenYellow, Color.Yellow, Color.Red, Color.DarkRed };
            var stops = new float[] { 0, .1f, .2f, .4f, .6f, .8f, 1 };

            var rs0 = new SurfaceMeshRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                HeightScaleFactor = 0,
                DrawMeshAs = DrawMeshAs.SolidWireframe,
                StrokeColor = Color.FromArgb(0x22, 0x8B, 0x22),
                StrokeThickness = 1f.ToDip(Activity),
                Maximum = 4,
                MeshColorPalette = new GradientColorPalette(colors, stops),
                Opacity = 0.7f
            };

            var rs1 = new SurfaceMeshRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                DrawMeshAs = DrawMeshAs.SolidWireframe,
                StrokeColor = Color.FromArgb(0x22, 0x8B, 0x22),
                StrokeThickness = 1f.ToDip(Activity),
                Maximum = 4,
                DrawSkirt = false,
                MeshColorPalette = new GradientColorPalette(colors, stops),
                Opacity = 0.9f
            };

            var rs2 = new SurfaceMeshRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                HeightScaleFactor = 0,
                DrawMeshAs = DrawMeshAs.SolidWireframe,
                StrokeColor = Color.FromArgb(0x22, 0x8B, 0x22),
                StrokeThickness = 1f.ToDip(Activity),
                Maximum = 4,
                YOffset = 400,
                MeshColorPalette = new GradientColorPalette(colors, stops),
                Opacity = 0.7f
            };

            using (Surface.SuspendUpdates())
            {
                Surface.WorldDimensions.Assign(1100, 400, 400);

                Surface.XAxis = new NumericAxis3D() { MaxAutoTicks = 7 };
                Surface.YAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(-4, 4) };
                Surface.ZAxis = new NumericAxis3D();

                Surface.Camera = new Camera3D() { Position = new Vector3(-1300, 1300, -1300) };

                Surface.RenderableSeries.Add(rs0);
                Surface.RenderableSeries.Add(rs1);
                Surface.RenderableSeries.Add(rs2);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D() { ResetPosition = new Vector3(-1300, 1300, -1300)}
                };
            }
        }
    }
}