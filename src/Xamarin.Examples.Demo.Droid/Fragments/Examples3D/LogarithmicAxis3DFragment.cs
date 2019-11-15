using SciChart.Charting.Visuals.Axes;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Xyz;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.PointMarkers;
using SciChart.Charting3D.Visuals.RenderableSeries.PointLine;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Logarithmic Axis 3D", description: "Create Chart with Logarithmic Axis 3D", icon: ExampleIcon.Axis3D)]
    class LogarithmicAxis3DFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            const int count = 100;
            var dataManager = DataManager.Instance;

            var data = dataManager.GetExponentialCurve(1.8, count);
            var xData = data.XData;
            var yData = data.YData;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new PointMetadataProvider3D();

            for (int i = 0; i < count; i++)
            {
                var x = xData[i];
                var y = yData[i];
                var z = dataManager.GetGaussianRandomNumber(15, 1.5);

                dataSeries3D.Append(x, y, z);

                var color = dataManager.GetRandomColor();
                var scale = dataManager.GetRandomScale();

                metadataProvider.Metadata.Add(new PointMetadata3D(color, scale));
            }

            var pointMarker3D = new SpherePointMarker3D()
            {
                FillColor = Color.Lime,
                Size = 5f
            };

            var renderableSeries3D = new PointLineRenderableSeries3D()
            {
                PointMarker = pointMarker3D,
                StrokeThickness = 2f.ToDip(Activity),
                DataSeries = dataSeries3D,
                MetadataProvider = metadataProvider
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new LogarithmicNumericAxis3D()
                {
                    GrowBy = new DoubleRange(0.1, 0.1),
                    DrawMajorBands = false,
                    TextFormatting = "#.#e+0",
                    CursorTextFormatting = "0.0",
                    ScientificNotation = ScientificNotation.LogarithmicBase
                };

                Surface.YAxis = new LogarithmicNumericAxis3D()
                {
                    GrowBy = new DoubleRange(0.1, 0.1),
                    DrawMajorBands = false,
                    TextFormatting = "#.000",
                    CursorTextFormatting = "0.0",
                    ScientificNotation = ScientificNotation.None
                };

                Surface.ZAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.5, 0.5) };

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