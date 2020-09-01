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
using SciChart.Core.Utility;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Simple Polar Mesh 3D Chart", description: "Create a simple Polar Mesh 3D Chart", icon: ExampleIcon.Surface3D)]
    class CreatePolarMesh3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            var dataManager = DataManager.Instance;

            const int uSize = 30, vSize = 10;
            var dataSeries3D = new PolarDataSeries3D<double, double>(uSize, vSize, 0d, Math.PI * 1.75)
            {
                A = 1d,
                B = 5d,
            };

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
                    new float[] { 0, .1f, .3f, .5f, .7f, .9f, 1}),
                PaletteMinimum = new Vector3(0, 0, 0),
                PaletteMaximum = new Vector3(0, 0.5f, 0)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.WorldDimensions.Assign(200, 50, 200);

                Surface.XAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(-7, 7) };
                Surface.YAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(0, 3) };
                Surface.ZAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(-7, 7) };

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