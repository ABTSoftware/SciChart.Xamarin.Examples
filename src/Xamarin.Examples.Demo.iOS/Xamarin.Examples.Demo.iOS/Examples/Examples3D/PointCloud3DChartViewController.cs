using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Point Cloud 3D Chart", description: "Create a simple Point Cloud 3D Chart", icon: ExampleIcon.Scatter3D)]
    class PointCloud3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            var dataManager = DataManager.Instance;
            var dataSeries3D = new XyzDataSeries3D<double, double, double>();

            for (int i = 0; i < 10000; i++)
            {
                double x = dataManager.GetGaussianRandomNumber(5, 1.5);
                double y = dataManager.GetGaussianRandomNumber(5, 1.5);
                double z = dataManager.GetGaussianRandomNumber(5, 1.5);

                dataSeries3D.Append(x, y, z);
            }

            var rSeries3D = new SCIScatterRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                PointMarker = new SCIEllipsePointMarker3D { FillColor = 0x77ADFF2F, Size = 3f },
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D { Position = new SCIVector3(-350, 100, -350), Target = new SCIVector3(0, 50, 0) };
            }
        }
    }
}