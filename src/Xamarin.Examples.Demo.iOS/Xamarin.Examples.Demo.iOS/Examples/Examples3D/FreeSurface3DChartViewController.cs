using System;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Free Surface 3D Chart", description: "Create a simple Free Surface3D Chart", icon: ExampleIcon.Surface3D)]
    class FreeSurface3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            const int uSize = 40, vSize = 20;
            var dataSeries3D = new CustomSurfaceDataSeries3D<double, double, double>(uSize, vSize,
                (u, v) => 5.0 + Math.Sin(5 * (u + v)),
                (u, v) => u,
                (u, v) => v,
                (r, theta, phi) => r * Math.Sin(theta) * Math.Cos(phi),
                (r, theta, phi) => r * Math.Cos(theta),
                (r, theta, phi) => r * Math.Sin(theta) * Math.Sin(phi));

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
                PaletteMinimum = new SCIVector3(0, 5, 0),
                PaletteMaximum = new SCIVector3(0, 7, 0),
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());
            }
        }
    }
}