using System;
using System.Drawing;
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
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Simple Uniform Mesh 3D Chart", description: "Create a simple Uniform Mesh 3D Chart", icon: ExampleIcon.Surface3D)]
    class CreateUniformMesh3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            const int xSize = 25;
            const int zSize = 25;

            var dataSeries3D = new UniformGridDataSeries3D<double, double, double>(xSize, zSize);

            for (int x = 0; x < xSize; x++)
            {
                for (int z = 0; z < zSize; z++)
                {
                    var xVal = 25.0 * x / xSize;
                    var zVal = 25.0 * z / zSize;

                    var y = Math.Sin(xVal * .2) / ((zVal + 1) * 2);
                    dataSeries3D.UpdateYAt(x, z, y);
                }
            }

            var renderableSeries3D = new SurfaceMeshRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                DrawMeshAs = DrawMeshAs.SolidWireframe,
                Stroke = 0x77228B22,
                ContourStroke = 0x77228B22,
                StrokeThickness = 2f.ToDip(Activity),
                DrawSkirt = false,
                MeshColorPalette = new GradientColorPalette(
                    new Color[] { Color.FromArgb(0xFF, 0x1D, 0x2C, 0x6B), Color.Blue, Color.Cyan, Color.GreenYellow, Color.Yellow, Color.Red, Color.DarkRed },
                    new float[] { 0, .1f, .3f, .5f, .7f, .9f, 1 })
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.YAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(0, .3) };
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