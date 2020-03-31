using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Spline Line Chart", description: "Create a spline Line Chart", icon: ExampleIcon.LineChart)]
    class SplineLineChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1)};
            var yAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.2, 0.2)};

            var dataSeries = new XyDataSeries<int, int>();
            var yValues = new[] { 50, 35, 61, 58, 50, 50, 40, 53, 55, 23, 45, 12, 59, 60 };
            for (int i = 0; i < yValues.Length; i++)
            {
                dataSeries.Append(i, yValues[i]);
            }

            var lineSeries = new FastLineRenderableSeries()
            {
                DataSeries = dataSeries, 
                StrokeStyle = new SolidPenStyle(0xFF4282B4, 2f.ToDip(Activity)),
                PointMarker = new EllipsePointMarker
                {
                    Width = 7.ToDip(Activity),
                    Height = 7.ToDip(Activity),
                    StrokeStyle = new SolidPenStyle(0xFF006400, 1f.ToDip(Activity)),
                    FillStyle = new SolidBrushStyle(0xFFFFFFFF)
                }
            };
            var rSeries = new SplineLineRenderableSeries { DataSeries = dataSeries, StrokeStyle = new SolidPenStyle(0xFF006400, 2f.ToDip(Activity)) };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.RenderableSeries.Add(lineSeries);
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };

                new SweepAnimatorBuilder(rSeries) { Interpolator = new DecelerateInterpolator(), Duration = 3000, StartDelay = 350 }.Start();
                new SweepAnimatorBuilder(lineSeries) { Interpolator = new DecelerateInterpolator(), Duration = 3000, StartDelay = 350 }.Start();
            }
        }
    }
}