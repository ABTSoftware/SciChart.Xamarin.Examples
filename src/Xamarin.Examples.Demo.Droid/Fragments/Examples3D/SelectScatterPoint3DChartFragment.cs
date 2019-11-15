using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Xyz;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.PointMarkers;
using SciChart.Charting3D.Visuals.RenderableSeries.MetadataProviders;
using SciChart.Charting3D.Visuals.RenderableSeries.Scatter;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using System.Drawing;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Select Scatter Point 3D Chart", description: "Selection of data-points via VertexSelectionModifier3D", icon: ExampleIcon.LineChart)]
    class SelectScatterPoint3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_With_Modifier_Tip_Fragment;

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

            var pointMarker3D = new EllipsePointMarker3D()
            {
                FillColor = Color.LimeGreen,
                Size = 5f
            };

            var renderableSeries3D = new ScatterRenderableSeries3D()
            {
                PointMarker = pointMarker3D,
                DataSeries = dataSeries3D,
                // set ISelectableMetadataProvider3D because we're going to use vertex selection for this series
                MetadataProvider = new DefaultSelectableMetadataProvider3D()
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.YAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.ZAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };

                Surface.Camera = new Camera3D();

                Surface.RenderableSeries.Add(renderableSeries3D);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D() { ReceiveHandledEvents = true, ExecuteOnPointerCount = 2 },
                    new ZoomExtentsModifier3D(),
                    new VertexSelectionModifier3D()
                    {
                        ReceiveHandledEvents = true,
                    }
                };
            }
        }
    }
}