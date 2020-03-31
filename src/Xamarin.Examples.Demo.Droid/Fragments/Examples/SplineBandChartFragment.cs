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
    [ExampleDefinition("Spline Band Chart", description: "Creates a spline Band Series Chart", icon: ExampleIcon.BandChart)]

    class SplineBandChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1)};
            var yAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.2, 0.2)};

            var data = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 13);
            var moreData = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 12);

            var dataSeries = new XyyDataSeries<double, double>();
            for (int i = 0; i < 10; i++)
            {
                var index = i * 100;
                dataSeries.Append(data.XData[index], data.YData[index], moreData.YData[index]);
            }

            var rSeries = new SplineBandRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(0xFFFF1919, 1f.ToDip(Activity)),
                StrokeY1Style = new SolidPenStyle(0xFF279B27, 1f.ToDip(Activity)),
                FillBrushStyle = new SolidBrushStyle(0x33279B27),
                FillY1BrushStyle = new SolidBrushStyle(0x33FF1919),
                PointMarker = new EllipsePointMarker
                {
                    Width = 7.ToDip(Activity),
                    Height = 7.ToDip(Activity),
                    StrokeStyle = new SolidPenStyle(0xFF006400, 1f.ToDip(Activity)),
                    FillStyle = new SolidBrushStyle(0xFFFFFFFF)
                }
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

                new ScaleAnimatorBuilder(rSeries) { Interpolator = new DecelerateInterpolator(), Duration = 3000, StartDelay = 350 }.Start();
            }
        }
    }
}