using System;
using System.Linq;
using Android.Graphics;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Bubble Chart")]
    public class BubbleChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var dataSeries = new XyzDataSeries<DateTime, double, double>();
            var tradeDataSource = DataManager.Instance.GetTradeticks().ToArray();

            dataSeries.Append(
                tradeDataSource.Select(x => x.TradeDate),
                tradeDataSource.Select(x => x.TradePrice),
                tradeDataSource.Select(x => x.TradeSize));

            var xAxis = new DateAxis(Activity) {GrowBy = new DoubleRange(0, 0.1)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0, 0.1)};

            var lineSeries = new FastLineRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(Activity, Color.Rgb(0xFF, 0x33, 0x33))
            };

            var stops = new[] { 0, 0.95f, 1 };
            var colors = new int[] { Color.Transparent, Resources.GetColor(Resource.Color.color_primary), Color.Transparent };
            var gradientFill = new RadialGradientBrushStyle(0.5f, 0.5f, 0.5f, 0.5f, colors, stops);

            var bubbleSeries = new FastBubbleRenderableSeries
            {
                DataSeries = dataSeries,
                BubbleBrushStyle = gradientFill,
                ZScaleFactor = 3,
                AutoZRange = false,
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.RenderableSeries.Add(bubbleSeries);

                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new RubberBandXyZoomModifier(),
                    new ZoomExtentsModifier(),
                };
            }
        }
    }
}