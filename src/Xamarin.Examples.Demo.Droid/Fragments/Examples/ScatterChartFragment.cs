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
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Scatter Chart")]
    public class ScatterChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            using (Surface.SuspendUpdates())
            {
                var dampedSinewave = DataManager.Instance.GetDampedSinewave(1.0, 0.02, 150, 5);

                var dataSeries = new XyDataSeries<double, double>();
                dataSeries.Append(dampedSinewave.XData, dampedSinewave.YData);

                var xAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};
                var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};

                var renderableSeries = new XyScatterRenderableSeries
                {
                    DataSeries = dataSeries,
                    PointMarker = new EllipsePointMarker
                    {
                        StrokeStyle = new PenStyle.Builder(Activity).WithColor(Color.Argb(255, 176, 196, 222)).WithThickness(2, ComplexUnitType.Dip).Build(),
                        FillStyle = new SolidBrushStyle(Color.Argb(255, 70, 130, 180)),
                        Width = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 15, Activity.Resources.DisplayMetrics),
                        Height = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 15, Activity.Resources.DisplayMetrics)
                    }
                };

                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(renderableSeries);

                Surface.ChartModifiers = new ChartModifierCollection()
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };
            }
        }
    }
}