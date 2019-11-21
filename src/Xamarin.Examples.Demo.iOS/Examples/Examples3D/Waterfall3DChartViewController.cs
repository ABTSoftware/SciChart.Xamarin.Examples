using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Waterfall 3D Chart", description: "Create a simple Waterfall 3D Chart", icon: ExampleIcon.Surface3D)]
    class CreateWaterfall3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        protected override void InitExample()
        {
            var data = DataManager.Instance.LoadWaterfallData();

            var sliceCount = data.Count;
            var pointsPerSlice = data[0].Count;

            var dataSeries3D = new WaterfallDataSeries3D<double, double, double>(pointsPerSlice, sliceCount) { StartX = 10d, StepX = 1d, StartZ = 1d };
            for (int i = 0; i < sliceCount; i++)
            {
                dataSeries3D.SetRowAt(i, data[i]);
            }

            var rSeries3D = new SCIWaterfallRenderableSeries3D
            {
                DataSeries = dataSeries3D,
                StrokeThickness = 1f,
                SliceThickness = 0f,
                YColorMapping = new SCIGradientColorPalette(
                    new[] { ColorUtil.Red, ColorUtil.Orange, ColorUtil.Yellow, ColorUtil.GreenYellow, ColorUtil.DarkGreen },
                    new[] { 0, .25f, .5f, .75f, 1 }),
                YStrokeColorMapping = new SCIGradientColorPalette(
                    new[] { ColorUtil.Crimson, ColorUtil.DarkOrange, ColorUtil.LimeGreen, ColorUtil.LimeGreen },
                    new[] { 0, 0.33f, 0.67f, 1 }),
                Opacity = 0.8f,
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D();
                Surface.YAxis = new SCINumericAxis3D();
                Surface.ZAxis = new SCINumericAxis3D();
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());
            }
        }
    }
}