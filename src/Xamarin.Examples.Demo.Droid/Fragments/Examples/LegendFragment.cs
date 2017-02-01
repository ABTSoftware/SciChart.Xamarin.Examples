using Android.Graphics;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Chart Legends API")]
    public class LegendFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity);
            var yAxis = new NumericAxis(Activity);

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Curve A"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Curve B"};
            var ds3 = new XyDataSeries<double, double> {SeriesName = "Curve C"};
            var ds4 = new XyDataSeries<double, double> {SeriesName = "Curve D"};

            var ds1Points = DataManager.Instance.GetStraightLine(4000, 1.0, 10);
            var ds2Points = DataManager.Instance.GetStraightLine(3000, 1.0, 10);
            var ds3Points = DataManager.Instance.GetStraightLine(2000, 1.0, 10);
            var ds4Points = DataManager.Instance.GetStraightLine(1000, 1.0, 10);

            ds1.Append(ds1Points.XData, ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);
            ds3.Append(ds3Points.XData, ds3Points.YData);
            ds4.Append(ds4Points.XData, ds4Points.YData);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);

                Surface.RenderableSeries = new RenderableSeriesCollection
                {
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds1,
                        StrokeStyle = new SolidPenStyle(Activity, Color.Rgb(0xFF, 0xFF, 0x00), true, 2f),
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds2,
                        StrokeStyle = new SolidPenStyle(Activity, Color.Rgb(0x27, 0x9B, 0x27), true, 2f),
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds3,
                        StrokeStyle = new SolidPenStyle(Activity, Color.Rgb(0xFF, 0x19, 0x19), true, 2f),
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds4,
                        IsVisible = false,
                        StrokeStyle = new SolidPenStyle(Activity, Color.Rgb(0x19, 0x64, 0xFF), true, 2f),
                    }
                };

                var legendModifier = new LegendModifier(Activity);
                legendModifier.SetSourceMode(SourceMode.AllSeries);

                Surface.ChartModifiers.Add(legendModifier);
            }
        }
    }
}