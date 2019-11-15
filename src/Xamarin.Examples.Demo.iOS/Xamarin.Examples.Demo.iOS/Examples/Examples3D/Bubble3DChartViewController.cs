using System;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Bubble 3D Chart", description: "Create a simple Bubble3D Chart", icon: ExampleIcon.Scatter3D)]
    class Bubble3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    { 
        protected override void InitExample()
        {
            var dataManager = DataManager.Instance;
            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new SCIPointMetadataProvider3D();

            for (int i = 0; i < 250; i++)
            {
                var x = dataManager.GetGaussianRandomNumber(5, 1.5);
                var y = dataManager.GetGaussianRandomNumber(5, 1.5);
                var z = dataManager.GetGaussianRandomNumber(5, 1.5);
                dataSeries3D.Append(x, y, z);

                var metadata = new SCIPointMetadata3D((uint)dataManager.GetRandomColor().ToArgb(), dataManager.GetRandomScale());
                metadataProvider.Metadata.Add(metadata);
            }

            var rSeries3D = new SCIScatterRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                PointMarker = new SCISpherePointMarker3D { FillColor = ColorUtil.Lime, Size = 5f },
                MetadataProvider = metadataProvider,
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