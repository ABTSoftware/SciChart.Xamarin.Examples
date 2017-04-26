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
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Band Chart", description:"Creates a Band Series Chart", icon: ExampleIcon.BandChart)]
    public class BandChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) {VisibleRange = new DoubleRange(1.1, 2.7)};
            var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1)};

            var data = DataManager.Instance.GetDampedSinewave(1.0, 0.01, 1000);
            var moreData = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 12);

            var dataSeries = new XyyDataSeries<double, double>();
            dataSeries.Append(data.XData, data.YData, moreData.YData);

            var rs = new FastBandRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(0xFFFF1919, 1f.ToDip(Activity)),
                StrokeY1Style = new SolidPenStyle(0xFF279B27, 1f.ToDip(Activity)),
                FillBrushStyle = new SolidBrushStyle(0x33279B27),
                FillY1BrushStyle = new SolidBrushStyle(0x33FF1919)
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(rs);

            Surface.ChartModifiers = new ChartModifierCollection
            {
                new ZoomPanModifier(),
                new PinchZoomModifier(),
                new ZoomExtentsModifier(),
            };
        }
    }
}