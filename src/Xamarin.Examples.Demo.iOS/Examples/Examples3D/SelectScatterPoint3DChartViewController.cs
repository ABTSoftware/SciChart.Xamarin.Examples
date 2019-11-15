using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Select Scatter Point 3D Chart", description: "Selection of data-points via VertexSelectionModifier3D", icon: ExampleIcon.LineChart)]
    class SelectScatterPoint3DChartViewController : SingleChartWithModifierTipViewController<SCIChartSurface3D>
    {
        public override string ModifierTip => "To rotate chart use scroll with two fingers";

        protected override void InitExample()
        {
            var dataManager = DataManager.Instance;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            for (int i = 0; i < 250; i++)
            {
                var x = dataManager.GetGaussianRandomNumber(5, 1.5);
                var y = dataManager.GetGaussianRandomNumber(5, 1.5);
                var z = dataManager.GetGaussianRandomNumber(5, 1.5);

                dataSeries3D.Append(x, y, z);
            }

            var rSeries3D = new SCIScatterRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                PointMarker = new SCIEllipsePointMarker3D { FillColor = ColorUtil.LimeGreen, Size = 5f },
                MetadataProvider = new SCIDefaultSelectableMetadataProvider3D()
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers = new SCIChartModifier3DCollection
                {
                    new SCIPinchZoomModifier3D(),
                    new SCIOrbitModifier3D(defaultNumberOfTouches: 2) { ReceiveHandledEvents = true },
                    new SCIZoomExtentsModifier3D(),
                    new SCIVertexSelectionModifier3D()
                };

                Surface.Camera = new SCICamera3D();
            }
        }
    }
}