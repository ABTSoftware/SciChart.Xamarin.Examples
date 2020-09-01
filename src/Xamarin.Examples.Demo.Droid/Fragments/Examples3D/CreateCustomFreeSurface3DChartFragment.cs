using System;
using System.Drawing;
using SciChart.Charting3D.Common.Math;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.FreeSurface;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Data;
using SciChart.Charting3D.Visuals.RenderableSeries.FreeSurface;
using SciChart.Data.Model;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Simple Free Surface 3D Chart", description: "Create a simple Free Surface3D Chart", icon: ExampleIcon.Surface3D)]
    class CreateCustomFreeSurface3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

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

            var renderableSeries3D = new FreeSurfaceRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                DrawMeshAs = DrawMeshAs.SolidWireframe,
                StrokeColor = Color.FromArgb(0x77, 0x22, 0x8B, 0x22),
                ContourInterval = 0.1f,
                ContourStrokeColor = Color.FromArgb(0x77, 0x22, 0x8B, 0x22),
                StrokeThickness = 1f.ToDip(Activity),
                MeshColorPalette = new GradientColorPalette(
                    new Color[] { Color.FromArgb(0xFF, 0x1D, 0x2C, 0x6B), Color.Blue, Color.Cyan, Color.GreenYellow, Color.Yellow, Color.Red, Color.DarkRed },
                    new float[] { 0, .1f, .3f, .5f, .7f, .9f, 1 }),
                PaletteMinMaxMode = FreeSurfacePaletteMinMaxMode.Relative,
                PaletteMinimum = new Vector3(0, 5, 0),
                PaletteMaximum = new Vector3(0, 7, 0),
                PaletteRadialFactor = 1f,
                PaletteAxialFactor = new Vector3(0, 0, 0),
                PaletteAzimuthalFactor = 0f,
                PalettePolarFactor = 0f
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.YAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
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