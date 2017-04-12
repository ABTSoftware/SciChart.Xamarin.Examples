using System;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Using RolloverModifier Tooltips")]
    public class UsingRolloverModifierTooltipsFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity);
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.2, 0.2)};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Sinewave A"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Sinewave B"};
            var ds3 = new XyDataSeries<double, double> {SeriesName = "Sinewave C"};

            const double count = 100;
            const double k = 2*Math.PI/30;
            for (var i = 0; i < count; i++)
            {
                var phi = k*i;
                var sin = Math.Sin(phi);

                ds1.Append(i, (1.0 + i/count) * sin);
                ds2.Append(i, (0.5 + i/count) * sin);
                ds3.Append(i, (i/count) * sin);
            }

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);

                Surface.RenderableSeries = new RenderableSeriesCollection
                {
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds1,
                        StrokeStyle = new SolidPenStyle(ColorUtil.SteelBlue, 2f.ToDip(Activity)),
                        PointMarker = new EllipsePointMarker
                        {
                            Width = 7.ToDip(Activity),
                            Height = 7.ToDip(Activity),
                            FillStyle = new SolidBrushStyle(ColorUtil.Lavender)
                        }
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds2,
                        StrokeStyle = new SolidPenStyle(ColorUtil.DarkGreen, 2f.ToDip(Activity)),
                        PointMarker = new EllipsePointMarker
                        {
                            Width = 7.ToDip(Activity),
                            Height = 7.ToDip(Activity),
                            FillStyle = new SolidBrushStyle(ColorUtil.Lavender)
                        }
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds3,
                        StrokeStyle = new SolidPenStyle(ColorUtil.LightSteelBlue, 2f.ToDip(Activity)),
                    },
                };

                Surface.ChartModifiers.Add(new RolloverModifier
                {
                    ShowTooltip = true,
                    ShowAxisLabels = true,
                    DrawVerticalLine = true
                });
            }
        }
    }
}