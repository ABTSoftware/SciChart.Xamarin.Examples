using Android.Graphics;
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
    [ExampleDefinition("Band Chart")]
    public class BandChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var data0 = DataManager.Instance.GetDampedSinewave(1.0, 0.01, 1000);
            var data1 = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 12);

            var dataSeries = new XyyDataSeries<double, double>();
            dataSeries.Append(data0.XData, data0.YData, data1.YData);

            var xAxis = new NumericAxis(Activity)
            {
                VisibleRange = new DoubleRange(1.1, 2.7)
            };
            var yAxis = new NumericAxis(Activity)
            {
                GrowBy = new DoubleRange(0.1, 0.1)
            };

            var rs = new FastBandRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new PenStyle.Builder(Activity).WithColor(Color.Argb(0xFF, 0xFF, 0x19, 0x19)).Build(),
                StrokeY1Style = new PenStyle.Builder(Activity).WithColor(Color.Argb(0xFF, 0x27, 0x9B, 0x27)).Build(),
                FillBrushStyle = new SolidBrushStyle(Color.Argb(0x33, 0x27, 0x9B, 0x27)),
                FillY1BrushStyle = new SolidBrushStyle(Color.Argb(0x33, 0xFF, 0x19, 0x19))
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(rs);

            Surface.ChartModifiers = new ChartModifierCollection()
            {
                new ZoomPanModifier(),
                new PinchZoomModifier(),
                new ZoomExtentsModifier(),
            };
        }
    }
}