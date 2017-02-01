using Android.Graphics;
using Android.Util;
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
    [ExampleDefinition("Using CursorModifier Tooltips")]
    public class UsingCursorModifierTooltipsFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) { AutoRange = AutoRange.Always, VisibleRange = new DoubleRange(3, 6)};
            var yAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0, 0.1)};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Green Series"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Red Series"};
            var ds3 = new XyDataSeries<double, double> {SeriesName = "Gray Series"};
            var ds4 = new XyDataSeries<double, double> {SeriesName = "Gold Series"};

            var data1 = DataManager.Instance.GetNoisySinewave(300, 1, 300, 0.25);
            var data2 = DataManager.Instance.GetSinewave(100, 2, 300);
            var data3 = DataManager.Instance.GetSinewave(200, 1.5, 300);
            var data4 = DataManager.Instance.GetSinewave(50, 0.1, 300);

            ds1.Append(data1.XData, data1.YData);
            ds2.Append(data2.XData, data2.YData);
            ds3.Append(data3.XData, data3.YData);
            ds4.Append(data4.XData, data4.YData);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);

                Surface.RenderableSeries = new RenderableSeriesCollection
                {
                    new FastLineRenderableSeries { DataSeries = ds1, StrokeStyle = new SolidPenStyle(Activity, Color.Green, true, 2) },
                    new FastLineRenderableSeries { DataSeries = ds1, StrokeStyle = new SolidPenStyle(Activity, Color.Green, true, 2) },
                    new FastLineRenderableSeries { DataSeries = ds2, StrokeStyle = new SolidPenStyle(Activity, Color.Red, true, 2) },
                    new FastLineRenderableSeries { DataSeries = ds3, StrokeStyle = new SolidPenStyle(Activity, Color.Gray, true, 2) },
                    new FastLineRenderableSeries { DataSeries = ds4, StrokeStyle = new SolidPenStyle(Activity, Color.Gold, true, 2) },
                };

                Surface.ChartModifiers.Add(new CursorModifier
                {
                    ShowAxisLabels = true,
                    ShowTooltip = true,
                    UseInterpolation = true,
                });
            }

        }
    }
}