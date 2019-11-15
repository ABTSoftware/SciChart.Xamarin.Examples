using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Logarithmic Axis 3D", description: "Create Chart with Logarithmic Axis 3D", icon: ExampleIcon.Axis3D)]
    public class LogarithmicAxis3DViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            const int count = 100;
            var dataManager = DataManager.Instance;

            var data = dataManager.GetExponentialCurve(1.8, count);
            var xData = data.XData;
            var yData = data.YData;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new SCIPointMetadataProvider3D();

            for (int i = 0; i < count; i++)
            {
                var x = xData[i];
                var y = yData[i];
                var z = dataManager.GetGaussianRandomNumber(15, 1.5);
                dataSeries3D.Append(x, y, z);

                var metadata = new SCIPointMetadata3D((uint)dataManager.GetRandomColor().ToArgb(), dataManager.GetRandomScale());
                metadataProvider.Metadata.Add(metadata);
            }

            var rSeries3D = new SCIPointLineRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                StrokeThickness = 2f,
                PointMarker = new SCISpherePointMarker3D { FillColor = ColorUtil.Lime, Size = 5f },
                MetadataProvider = metadataProvider,
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCILogarithmicNumericAxis3D
                {
                    GrowBy = new SCIDoubleRange(0.1, 0.1),
                    DrawMajorBands = false,
                    TextFormatting = "#.#e+0",
                    ScientificNotation = SCIScientificNotation.LogarithmicBase
                };
                Surface.YAxis = new SCILogarithmicNumericAxis3D
                {
                    GrowBy = new SCIDoubleRange(0.1, 0.1),
                    DrawMajorBands = false,
                    TextFormatting = "#.0",
                    ScientificNotation = SCIScientificNotation.None
                };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.5, 0.5) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());
            }
        }
    }
}