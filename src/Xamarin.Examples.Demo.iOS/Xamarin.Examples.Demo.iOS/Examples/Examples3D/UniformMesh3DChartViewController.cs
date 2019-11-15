using System;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Uniform Mesh 3D Chart", description: "Create a simple Uniform Mesh 3D Chart", icon: ExampleIcon.Surface3D)]
    class CreateUniformMesh3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
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

            var rSeries3D = new SCISurfaceMeshRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                DrawMeshAs = SCIDrawMeshAs.SolidWireframe,
                Stroke = 0x77228B22,
                ContourStroke = 0x77228B22,
                StrokeThickness = 2f,
                DrawSkirt = false,
                MeshColorPalette = new SCIGradientColorPalette(
                    new[] { ColorUtil.Sapphire, ColorUtil.Blue, ColorUtil.Cyan, ColorUtil.GreenYellow, ColorUtil.Yellow, ColorUtil.Red, ColorUtil.DarkRed },
                    new[] { 0, .1f, .3f, .5f, .7f, .9f, 1 })
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(0, .3) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
            }
        }
    }
}