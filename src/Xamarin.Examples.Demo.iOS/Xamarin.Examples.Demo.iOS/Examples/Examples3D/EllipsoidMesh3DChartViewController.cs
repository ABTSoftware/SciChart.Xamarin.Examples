using System;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Ellipsoid 3D Chart", description: "Create a simple Ellipsoid 3D Chart", icon: ExampleIcon.Surface3D)]
    class EllipsoidMesh3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            const int uSize = 40, vSize = 20;
            var dataSeries3D = new EllipsoidDataSeries3D<double>(uSize, vSize) { A = 6, B = 6, C = 6 };

            var random = new Random();
            for (int u = 0; u < uSize; u++)
            {
                for (int v = 0; v < vSize; v++)
                {
                    var weightV = 1d - Math.Abs(2d * v / vSize - 1d);
                    var offset = random.NextDouble();

                    dataSeries3D.SetDisplacement(u, v, offset * weightV);
                }
            }

            var rSeries3D = new SCIFreeSurfaceRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                DrawMeshAs = SCIDrawMeshAs.SolidWireframe,
                Stroke = 0x77228B22,
                ContourInterval = 0.1f,
                ContourStroke = 0x77228B22,
                StrokeThickness = 1f,
                MeshColorPalette = new SCIGradientColorPalette(
                    new[] { ColorUtil.Sapphire, ColorUtil.Blue, ColorUtil.Cyan, ColorUtil.GreenYellow, ColorUtil.Yellow, ColorUtil.Red, ColorUtil.DarkRed },
                    new[] { 0, .1f, .3f, .5f, .7f, .9f, 1 }),
                PaletteMinimum = new SCIVector3(0, 6, 0),
                PaletteMaximum = new SCIVector3(0, 7, 0),
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-7, 7) };
                Surface.YAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-7, 7) };
                Surface.ZAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-7, 7) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.WorldDimensions = new SCIVector3(200, 200, 200);
            }
        }
    }
}