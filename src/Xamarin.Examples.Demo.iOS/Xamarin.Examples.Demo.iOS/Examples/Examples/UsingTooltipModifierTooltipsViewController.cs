using CoreGraphics;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;
using System.Linq;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Using TooltipModifier Tooltips", description: "Demonstrates a simple tooltip", icon: ExampleIcon.Annotations)]
    public class UsingTooltipModifierTooltipsViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var ds1 = new XyDataSeries<double, double> { SeriesName = "Lissajous Curve", AcceptsUnsortedData = true };
            var ds2 = new XyDataSeries<double, double> { SeriesName = "Sinewave" };

            var ds1Points = DataManager.Instance.GetLissajousCurve(0.8, 0.2, 0.43, 500);
            var ds2Points = DataManager.Instance.GetSinewave(1.5, 1.0, 500);

            ds1.Append(ds1Points.XData.Select(value => (value + 1) * 5), ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);

            var line1 = new SCIFastLineRenderableSeries
            {
                DataSeries = ds1,
                StrokeStyle = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                PointMarker = new SCIEllipsePointMarker { Size = new CGSize(5, 5), FillStyle = new SCISolidBrushStyle(ColorUtil.SteelBlue) }
            };
            var line2 = new SCIFastLineRenderableSeries
            {
                DataSeries = ds2,
                StrokeStyle = new SCISolidPenStyle(0xFFFF3333, 2f),
                PointMarker = new SCIEllipsePointMarker { Size = new CGSize(5, 5), FillStyle = new SCISolidBrushStyle(0xFFFF3333) }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(line1);
                Surface.RenderableSeries.Add(line2);
                Surface.ChartModifiers.Add(new SCITooltipModifier());

                SCIAnimations.FadeSeries(line1, 3, new SCICubicEase());
                SCIAnimations.FadeSeries(line2, 3, new SCICubicEase());
            }
        }
    }
}