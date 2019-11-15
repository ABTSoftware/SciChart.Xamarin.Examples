using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Xyz;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Columns;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Components;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Simple Sparse Column 3D Chart", description: "Create a simple Sparse Column 3D Chart", icon: ExampleIcon.ColumnChart)]
    class CreateSparseColumn3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        protected override void InitExample()
        {
            const int count = 15;

            var dataManager = DataManager.Instance;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();
            var metadataProvider = new PointMetadataProvider3D();


            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i != j && i % 2 == 0 && j % 2 == 0)
                    {
                        var y = dataManager.GetGaussianRandomNumber(5, 1.5);

                        dataSeries3D.Append(i, y, j);
                        metadataProvider.Metadata.Add(new PointMetadata3D(dataManager.GetRandomColor()));
                    }
                }
            }

            var renderableSeries3D = new ColumnRenderableSeries3D()
            {
                DataSeries = dataSeries3D,
                MetadataProvider = metadataProvider
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
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D()
                };
            }
        }
    }
}