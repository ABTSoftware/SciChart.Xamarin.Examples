using System;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Uniform Impulse Series 3D Chart", description: "Create a simple Uniform Impulse Series 3D Chart", icon: ExampleIcon.Impulse)]
    class UniformImpulseSeries3DChartViewController : SingleChartViewController<SCIChartSurface3D>
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

            var rSeries3D = new SCIImpulseRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                Stroke = ColorUtil.CornflowerBlue,
                PointMarker = new SCISpherePointMarker3D { Size = 3f, FillColor = ColorUtil.CornflowerBlue },
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