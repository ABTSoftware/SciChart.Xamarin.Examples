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
    [ExampleDefinition("Impulse Chart")]
    public class ImpulseChartFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var ds1Points = DataManager.Instance.GetDampedSinewave(1.0, 0.05, 50, 5);

            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(ds1Points.XData, ds1Points.YData);

            var xAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1) };
            var yAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1) };

            var renderableSeries = new FastImpulseRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new PenStyle.Builder(Activity).WithColor(Color.Rgb(0x00, 0x66, 0xFF)).WithThickness(1f, ComplexUnitType.Dip).Build(),
                PointMarker = new EllipsePointMarker
                {
                    Width = 10,
                    Height = 10,
                    StrokeStyle = new PenStyle.Builder(Activity).WithColor(Color.Rgb(0x00, 0x66, 0xFF)).WithThickness(0.7f, ComplexUnitType.Dip).Build(),
                    FillStyle = new SolidBrushStyle(Color.Rgb(0x00, 0x66, 0xFF))
                }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(renderableSeries);

                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier()
                };
            }
        }
    }
}