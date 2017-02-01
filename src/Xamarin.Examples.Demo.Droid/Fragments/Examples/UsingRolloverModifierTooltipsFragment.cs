using System;
using Android.Graphics;
using Android.Util;
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
using Xamarin.Examples.Demo.Droid.Fragments.Base;

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
                        StrokeStyle = new SolidPenStyle(Activity, Color.SteelBlue, true, 2f),
                        PointMarker = new EllipsePointMarker
                        {
                            Width = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 7, Activity.Resources.DisplayMetrics),
                            Height = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 7, Activity.Resources.DisplayMetrics),
                            FillStyle = new SolidBrushStyle(Color.Lavender)
                        }
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds2,
                        StrokeStyle = new SolidPenStyle(Activity, Color.DarkGreen, true, 2f),
                        PointMarker = new EllipsePointMarker
                        {
                            Width = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 7, Activity.Resources.DisplayMetrics),
                            Height = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 7, Activity.Resources.DisplayMetrics),
                            FillStyle = new SolidBrushStyle(Color.Lavender)
                        }
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = ds3,
                        StrokeStyle = new SolidPenStyle(Activity, Color.LightSteelBlue, true, 2f),
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