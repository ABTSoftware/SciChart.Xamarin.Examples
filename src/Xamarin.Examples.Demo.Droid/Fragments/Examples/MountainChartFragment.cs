using System;
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
    [ExampleDefinition("Mountain Chart", description:"Create a simple Mountain / Area Chart", icon: ExampleIcon.MountainChart)]
    public class MountainChartFragment : ExampleBaseFragment
    {
        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new DateAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};

            var priceData = DataManager.Instance.GetPriceDataIndu();
            var dataSeries = new XyDataSeries<DateTime, double>();
            dataSeries.Append(priceData.TimeData, priceData.CloseData);

            var rSeries = new FastMountainRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(0xAAFFC9A8, 2f.ToDip(Activity)),
                AreaStyle = new LinearGradientBrushStyle(0, 0, 1, 1, 0xAAFF8D42, 0x88090E11)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };

                new WaveAnimatorBuilder(rSeries) { Interpolator = new DecelerateInterpolator(), Duration = 3000, StartDelay = 350 }.Start();
            }
        }
    }
}