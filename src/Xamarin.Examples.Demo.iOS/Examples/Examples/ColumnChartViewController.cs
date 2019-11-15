using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Column Chart", description: "Creates a simple column chart", icon: ExampleIcon.ColumnChart)]
    public class ColumnChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0, 0.1) };

            var dataSeries = new XyDataSeries<double, double>();
            var yValues = new[] { 50, 35, 61, 58, 50, 50, 40, 53, 55, 23, 45, 12, 59, 60 };
            for (var i = 0; i < yValues.Length; i++)
            {
                dataSeries.Append(i, yValues[i]);
            }

            var rSeries = new SCIFastColumnRenderableSeries { DataSeries = dataSeries, PaletteProvider = new ColumnPaletteProvider() };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers.Add(CreateDefaultModifiers());

                SCIAnimations.WaveSeries(rSeries, 3, new SCICubicEase());
            }
        }

        private class ColumnPaletteProvider : SCIPaletteProviderBase<SCIFastColumnRenderableSeries>, IISCIFillPaletteProvider
        {
            private readonly uint[] _desiredColors = { 0xFFa9d34f, 0xFFfc9930, 0xFFd63b3f };

            public override void Update()
            {
                FillColors.Clear();
                var pointsCount = RenderableSeries.CurrentRenderPassData.PointsCount;
                for (int i = 0; i < pointsCount; i++)
                {
                    FillColors.Add(_desiredColors[i % 3]);
                }
            }

            public SCIUnsignedIntegerValues FillColors { get; } = new SCIUnsignedIntegerValues();
        }
    }
}