using System;
using System.Drawing;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Grid;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Columns;
using SciChart.Data.Model;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Simple Uniform Column Series 3D Chart", description: "Create a simple Uniform Column Series 3D Chart", icon: ExampleIcon.ColumnChart)]
    class CreateUniformColumn3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            const int count = 15;

            var dataSeries3D = new UniformGridDataSeries3D<double, double, double>(count, count);

            for (int x = 0; x < count; x++)
            {
                for (int z = 0; z < count; z++)
                {
                    var y = Math.Sin(x * .2) / ((z + 1) * 2);

                    dataSeries3D.UpdateYAt(x, z, y);
                }
            }

            var renderableSeries3D = new ColumnRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                Fill = Color.DodgerBlue.ToArgb()
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.YAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(0, .5) };
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