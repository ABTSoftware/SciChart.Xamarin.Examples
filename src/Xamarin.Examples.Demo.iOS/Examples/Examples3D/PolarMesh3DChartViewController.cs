using System;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Polar Mesh 3D Chart", description: "Create a simple Polar Mesh 3D Chart", icon: ExampleIcon.Surface3D)]
    class PolarMesh3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            const int uSize = 30, vSize = 10;
            var dataSeries3D = new PolarDataSeries3D<double, double>(uSize, vSize, 0d, Math.PI * 1.75) { A = 1, B = 5 };

            var random = new Random();
            for (int u = 0; u < uSize; u++)
            {
                var weightU = 1d - Math.Abs(2d * u / uSize - 1d);
                for (int v = 0; v < vSize; v++)
                {
                    var weightV = 1d - Math.Abs(2d * v / vSize - 1d);
                    var offset = random.NextDouble();

                    dataSeries3D.SetDisplacement(u, v, offset * weightU * weightV);
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
                    new[] { 0, .1f, .3f, .5f, .7f, .9f, 1}),
                PaletteMaximum = new SCIVector3(0, 0.5f, 0),
            };
        
            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-7, 7) };
                Surface.YAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(0, 3) };
                Surface.ZAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-7, 7) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
                Surface.Viewport.WorldDimensions.AssignX(200, 50, 200);
            }
        }
    }
}