using System;
using System.Linq;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Components;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS
{

    [ExampleDefinition("Custom Theme", description: "Showcase how to apply custom theme", icon: ExampleIcon.Themes)]
    public class CustomThemeViewController : ExampleBaseViewController
    {
        string customThemeKey = "SciChart_BerryBlue";

        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(150, 180) };

            var yRightAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0.1, 0.1),
                AxisAlignment = SCIAxisAlignment.Right,
                AutoRange = SCIAutoRange.Always,
                AxisId = "PrimaryAxisId",
                Style =
                {
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                },
                LabelProvider = new ThousandsLabelProvider()
            };

            var yLeftAxis = new SCINumericAxis
            {
                GrowBy = new SCIDoubleRange(0, 3d),
                AxisAlignment = SCIAxisAlignment.Left,
                AutoRange = SCIAutoRange.Always,
                AxisId = "SecondaryAxisId",
                Style =
                {
                    DrawMajorTicks = false,
                    DrawMinorTicks = false,
                },
                LabelProvider = new BillionsLabelProvider()
            };

            var dataManager = DataManager.Instance;
            var priceBars = dataManager.GetPriceDataIndu();

            var mountainDataSeries = new XyDataSeries<double, double> { SeriesName = "Mountain Series" };
            var lineDataSeries = new XyDataSeries<double, double> { SeriesName = "Line Series" };
            var columnDataSeries = new XyDataSeries<double, long> { SeriesName = "Column Series" };
            var candlestickDataSeries = new OhlcDataSeries<double, double> { SeriesName = "Candlestick Series" };

            var xValues = Enumerable.Range(0, priceBars.Count).Select(x => (double)x).ToArray();

            mountainDataSeries.Append(xValues, priceBars.LowData.Select(x => x - 1000d));
            lineDataSeries.Append(xValues, dataManager.ComputeMovingAverage(priceBars.CloseData, 50));
            columnDataSeries.Append(xValues, priceBars.VolumeData);
            candlestickDataSeries.Append(xValues, priceBars.OpenData, priceBars.HighData, priceBars.LowData, priceBars.CloseData);

            var mountainRenderableSeries = new SCIFastMountainRenderableSeries { DataSeries = mountainDataSeries, YAxisId = "PrimaryAxisId" };
            var lineRenderableSeries = new SCIFastLineRenderableSeries { DataSeries = lineDataSeries, YAxisId = "PrimaryAxisId" };
            var columnRenderableSeries = new SCIFastColumnRenderableSeries { DataSeries = columnDataSeries, YAxisId = "SecondaryAxisId" };
            var candlestickRenderableSeries = new SCIFastCandlestickRenderableSeries { DataSeries = candlestickDataSeries, YAxisId = "PrimaryAxisId" };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yRightAxis);
                Surface.YAxes.Add(yLeftAxis);
                Surface.RenderableSeries.Add(mountainRenderableSeries);
                Surface.RenderableSeries.Add(lineRenderableSeries);
                Surface.RenderableSeries.Add(columnRenderableSeries);
                Surface.RenderableSeries.Add(candlestickRenderableSeries);
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCILegendModifier {ShowCheckBoxes = false},
                    new SCICursorModifier(),
                    new SCIZoomExtentsModifier()
                };
            }

            SCIThemeManager.ApplyTheme(Surface, customThemeKey);
        }
    }
}
