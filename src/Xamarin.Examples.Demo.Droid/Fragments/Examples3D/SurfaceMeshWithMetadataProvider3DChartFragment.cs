using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Grid;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Data;
using SciChart.Charting3D.Visuals.RenderableSeries.MetadataProviders;
using SciChart.Charting3D.Visuals.RenderableSeries.SurfaceMesh;
using SciChart.Core.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using System;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Surface Mesh 3D MetadataProvider", description: "Use the MetadataProvider API to color SurfaceMesh cells individually", icon: ExampleIcon.Surface3D)]
    class SurfaceMeshWithMetadataProvider3DChartFragment : ExampleBaseFragment
    {
        private const int XSize = 49, ZSize = 49;
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        private readonly UniformGridDataSeries3D<double, double, double> meshDataSeries0 = new UniformGridDataSeries3D<double, double, double>(XSize, ZSize);
        private readonly UniformGridDataSeries3D<double, double, double> meshDataSeries1 = new UniformGridDataSeries3D<double, double, double>(XSize, ZSize);

        protected override void InitExample()
        {
            for (int x = 48; x >= 24; x--)
            {
                double y = Math.Pow(x - 23.7, 0.3);
                double y2 = Math.Pow(49.5 - x, 0.3);

                meshDataSeries0.UpdateYAt(x, 24, y);
                meshDataSeries1.UpdateYAt(x, 24, y2 + 1.505);
            }

            for (int x = 24; x >= 0; x--)
            {
                for (int z = 49; z > 25; z--)
                {
                    double y = Math.Pow(z - 23.7, 0.3);
                    double y2 = Math.Pow(50.5 - z, 0.3) + 1.505;

                    meshDataSeries0.UpdateYAt(x + 24, 49 - z, y);
                    meshDataSeries0.UpdateYAt(z - 1, 24 - x, y);

                    meshDataSeries1.UpdateYAt(x + 24, 49 - z, y2);
                    meshDataSeries1.UpdateYAt(z - 1, 24 - x, y2);

                    meshDataSeries0.UpdateYAt(24 - x, 49 - z, y);
                    meshDataSeries0.UpdateYAt(49 - z, 24 - x, y);

                    meshDataSeries1.UpdateYAt(24 - x, 49 - z, y2);
                    meshDataSeries1.UpdateYAt(49 - z, 24 - x, y2);

                    meshDataSeries0.UpdateYAt(x + 24, z - 1, y);
                    meshDataSeries0.UpdateYAt(z - 1, x + 24, y);

                    meshDataSeries1.UpdateYAt(x + 24, z - 1, y2);
                    meshDataSeries1.UpdateYAt(z - 1, x + 24, y2);

                    meshDataSeries0.UpdateYAt(24 - x, z - 1, y);
                    meshDataSeries0.UpdateYAt(49 - z, x + 24, y);

                    meshDataSeries1.UpdateYAt(24 - x, z - 1, y2);
                    meshDataSeries1.UpdateYAt(49 - z, x + 24, y2);
                }
            }

            var colors = new Color[] { Color.DarkBlue, Color.Blue, Color.CadetBlue, Color.Cyan, Color.LimeGreen, Color.GreenYellow, Color.Yellow, Color.Tomato, Color.IndianRed, Color.Red, Color.DarkRed};
            var stops = new float[] { 0, .1f, .2f, .3f, .4f, .5f, .6f, .7f, .8f, .9f, 1 };

            var rs0 = new SurfaceMeshRenderableSeries3D()
            {
                DataSeries = meshDataSeries0,
                DrawMeshAs = DrawMeshAs.SolidMesh,
                DrawSkirt = false,
                MeshColorPalette = new GradientColorPalette(colors, stops),
                MetadataProvider = new SurfaceMeshMetadataProvider3D()
            };

            var rs1 = new SurfaceMeshRenderableSeries3D()
            {
                DataSeries = meshDataSeries1,
                DrawMeshAs = DrawMeshAs.SolidMesh,
                DrawSkirt = false,
                MeshColorPalette = new GradientColorPalette(colors, stops),
                MetadataProvider = new SurfaceMeshMetadataProvider3D()
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D()
                {
                    DrawMajorBands = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false,
                    DrawLabels = false,
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                    PlaneBorderThickness = 0
                };
                Surface.YAxis = new NumericAxis3D()
                {
                    DrawMajorBands = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false,
                    DrawLabels = false,
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                    PlaneBorderThickness = 0
                };
                Surface.ZAxis = new NumericAxis3D()
                {
                    DrawMajorBands = false,
                    DrawMajorGridLines = false,
                    DrawMinorGridLines = false,
                    DrawLabels = false,
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                    PlaneBorderThickness = 0
                };

                Surface.Camera = new Camera3D();

                Surface.RenderableSeries.Add(rs0);
                Surface.RenderableSeries.Add(rs1);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D()
                };
            }
        }
    }

    class SurfaceMeshMetadataProvider3D : MetadataProvider3DBase<SurfaceMeshRenderableSeries3D>, ISurfaceMeshMetadataProvider3D
    {
        public void UpdateMeshColors(IntegerValues cellColors)
        {
            var currentRenderPassData = (SurfaceMeshRenderPassData3D)RenderableSeries.CurrentRenderPassData;

            var dataManager = DataManager.Instance;

            var countX = currentRenderPassData.CountX - 1;
            var countZ = currentRenderPassData.CountZ - 1;

            cellColors.SetSize(currentRenderPassData.PointsCount);

            for (int x = 0; x < countX; x++)
            {
                for (int z = 0; z < countX; z++)
                {
                    int index = x * countZ + z;

                    int color;
                    if ((x >= 20 && x <= 26 && z > 0 && z < 47) || (z >= 20 && z <= 26 && x > 0 && x < 47))
                    {
                        color = Color.Transparent.ToArgb();
                    }
                    else
                    {
                        color = dataManager.GetRandomColor().ToArgb();
                    }

                    cellColors.Set(index, color);
                }
            }
        }
    }
}