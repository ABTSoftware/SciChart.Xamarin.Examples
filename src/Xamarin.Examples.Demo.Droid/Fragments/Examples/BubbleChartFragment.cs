using System;
using System.Linq;
using Android.Views.Animations;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Bubble Chart", description:"Creates a Bubble Series and Line Chart", icon: ExampleIcon.BubbleChart)]
    public class BubbleChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new DateAxis(Activity) {GrowBy = new DoubleRange(0, 0.1)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0, 0.1)};

            var dataSeries = new XyzDataSeries<DateTime, double, double>();
            var tradeDataSource = DataManager.Instance.GetTradeticks().ToArray();

            dataSeries.Append(
                tradeDataSource.Select(x => x.TradeDate),
                tradeDataSource.Select(x => x.TradePrice),
                tradeDataSource.Select(x => x.TradeSize));

            var lineSeries = new FastLineRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(0xFFFF3333, 1.ToDip(Activity))
            };

            var bubbleSeries = new FastBubbleRenderableSeries
            {
                DataSeries = dataSeries,
                BubbleBrushStyle = new SolidBrushStyle(0x77CCCCCC),
                StrokeStyle = new SolidPenStyle(0xFFCCCCCC, 2f.ToDip(Activity)),
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

                new ScaleAnimatorBuilder(lineSeries, 10600d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
                new ScaleAnimatorBuilder(bubbleSeries, 10600d) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600 }.Start();
            }
        }
    }
}