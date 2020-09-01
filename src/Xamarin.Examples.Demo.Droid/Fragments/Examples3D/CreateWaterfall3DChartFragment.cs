using System.Drawing;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Waterfall;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Data;
using SciChart.Charting3D.Visuals.RenderableSeries.Waterfall;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Simple Waterfall 3D Chart", description: "Create a simple Waterfall 3D Chart", icon: ExampleIcon.Surface3D)]
    class CreateWaterfall3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            var data = DataManager.Instance.LoadWaterfallData();

            var sliceCount = data.Count;
            var pointsPerSlice = data[0].Count;

            var dataSeries3D = new WaterfallDataSeries3D<double, double, double>(pointsPerSlice, sliceCount)
            {
                StartX = 10d,
                StepX = 1d,
                StartZ = 1d
            };

            for (int i = 0; i < sliceCount; i++)
            {
                dataSeries3D.SetRowAt(i, data[i]);
            }

            var renderableSeries3D = new WaterfallRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                StrokeThickness = 1f.ToDip(Activity),
                SliceThickness = 0f,
                YColorMapping = new GradientColorPalette(
                    new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.GreenYellow, Color.DarkGreen },
                    new float[] { 0, .25f, .5f, .75f, 1 }),
                YStrokeColorMapping = new GradientColorPalette(
                    new Color[] { Color.Crimson, Color.DarkOrange, Color.LimeGreen, Color.LimeGreen },
                    new float[] { 0, 0.33f, 0.67f, 1 }),
                Opacity = 0.8f

            };
            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D();
                Surface.YAxis = new NumericAxis3D();
                Surface.ZAxis = new NumericAxis3D();

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