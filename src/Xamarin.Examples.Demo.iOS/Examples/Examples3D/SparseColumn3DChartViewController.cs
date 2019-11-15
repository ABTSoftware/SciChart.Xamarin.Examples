using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Sparse Column 3D Chart", description: "Create a simple Sparse Column 3D Chart", icon: ExampleIcon.ColumnChart)]
    class SparseColumn3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            const int count = 15;
            var dataManager = DataManager.Instance;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new SCIPointMetadataProvider3D();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i != j && i % 2 == 0 && j % 2 == 0)
                    {
                        var y = dataManager.GetGaussianRandomNumber(5, 1.5);
                        dataSeries3D.Append(i, y, j);

                        var metadata = new SCIPointMetadata3D((uint)dataManager.GetRandomColor().ToArgb());
                        metadataProvider.Metadata.Add(metadata);
                    }
                }
            }

            var rSeries3D = new SCIColumnRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                MetadataProvider = metadataProvider
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
            }
        }
    }
}