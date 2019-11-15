using System;
using Android.Views.Animations;
using SciChart.Charting.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Xamarin.Examples.Demo;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("ErrorBars Chart", description: "Create an ErrorBar Chart", icon: ExampleIcon.ErrorBars)]
    public class ErrorBarsChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity);
            var yAxis = new NumericAxis(Activity);

            var fourierSeries = DataManager.Instance.GetFourierSeries(1.0, 0.1, 5.0, 5.15);

            var dataSeries0 = new HlDataSeries<double, double>();
            var dataSeries1 = new HlDataSeries<double, double>();

            FillDataSeries(dataSeries0, fourierSeries, 1.0);
            FillDataSeries(dataSeries1, fourierSeries, 1.3);

            const uint color = 0xFFC6E6FF;

            var strokeStyle = new SolidPenStyle(0xFFC6E6FF, 1f.ToDip(Activity));

            var errorBars0 = new FastErrorBarsRenderableSeries()
            {
                DataSeries = dataSeries0,
                StrokeStyle = strokeStyle,
                ErrorDirection = ErrorDirection.Vertical,
                ErrorType = ErrorType.Absolute
            };
            var lineSeries = new FastLineRenderableSeries
            {
                DataSeries = dataSeries0,
                StrokeStyle = strokeStyle,
                PointMarker = new EllipsePointMarker()
                {
                    FillStyle = new SolidBrushStyle(color),
                    Width = 5.ToDip(Activity),
                    Height = 5.ToDip(Activity)
                }
            };

            var errorBars1 = new FastErrorBarsRenderableSeries()
            {
                DataSeries = dataSeries1,
                StrokeStyle = strokeStyle,
                ErrorDirection = ErrorDirection.Vertical,
                ErrorType = ErrorType.Absolute
            };
            var scatterSeries = new XyScatterRenderableSeries()
            {
                DataSeries = dataSeries1,
                PointMarker = new EllipsePointMarker()
                {
                    FillStyle = new SolidBrushStyle(ColorUtil.Transparent),
                    StrokeStyle = strokeStyle,
                    Width = 7.ToDip(Activity),
                    Height = 7.ToDip(Activity)
                }
            };
            
            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries = new RenderableSeriesCollection
                {
                    errorBars0,
                    lineSeries,
                    errorBars1,
                    scatterSeries
                };
                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };

                new ScaleAnimatorBuilder(errorBars0) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600}.Start();
                new ScaleAnimatorBuilder(lineSeries) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600}.Start();
                new ScaleAnimatorBuilder(errorBars1) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600}.Start();
                new ScaleAnimatorBuilder(scatterSeries) { Interpolator = new OvershootInterpolator(), Duration = 1000, StartDelay = 600}.Start();
            }
        }

        private static void FillDataSeries(HlDataSeries<double, double> dataSeries, DoubleSeries sourceData, double scale)
        {
            var random = new Random(42);

            var xData = sourceData.XData;
            var yData = sourceData.YData;

            for (var i = 0; i < sourceData.Count; i++)
            {
                dataSeries.Append(xData[i], yData[i] + scale, random.NextDouble() * 0.2, random.NextDouble() * 0.2);
            }
        }
    }
}