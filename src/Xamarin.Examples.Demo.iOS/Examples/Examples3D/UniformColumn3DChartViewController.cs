using System;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Uniform Column Series 3D Chart", description: "Create a simple Uniform Column Series 3D Chart", icon: ExampleIcon.ColumnChart)]
    class UniformColumn3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
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

            var rSeries3D = new SCIColumnRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                FillColor = ColorUtil.CornflowerBlue,
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.5) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
            }
        }
    }
}