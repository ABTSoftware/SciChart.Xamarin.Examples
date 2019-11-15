using System;
using CoreGraphics;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Using RolloverModifier Tooltips", "Demonstrates Rollover Tooltips", icon: ExampleIcon.Annotations)]
    public class UsingRolloverModifierTooltipsViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis();
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.2, 0.2) };

            var ds1 = new XyDataSeries<double, double> { SeriesName = "Sinewave A" };
            var ds2 = new XyDataSeries<double, double> { SeriesName = "Sinewave B" };
            var ds3 = new XyDataSeries<double, double> { SeriesName = "Sinewave C" };

            const double count = 100;
            const double k = 2 * Math.PI / 30;
            for (var i = 0; i < count; i++)
            {
                var phi = k * i;
                var sin = Math.Sin(phi);

                ds1.Append(i, (1.0 + i / count) * sin);
                ds2.Append(i, (0.5 + i / count) * sin);
                ds3.Append(i, (i / count) * sin);
            }

            var rs1 = new SCIFastLineRenderableSeries
            {
                DataSeries = ds1,
                StrokeStyle = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                PointMarker = new SCIEllipsePointMarker { Size = new CGSize(7, 7), FillStyle = new SCISolidBrushStyle(ColorUtil.Lavender) }
            };
            var rs2 = new SCIFastLineRenderableSeries
            {
                DataSeries = ds2,
                StrokeStyle = new SCISolidPenStyle(ColorUtil.DarkGreen, 2f),
                PointMarker = new SCIEllipsePointMarker { Size = new CGSize(7, 7), FillStyle = new SCISolidBrushStyle(ColorUtil.Lavender) }
            };
            var rs3 = new SCIFastLineRenderableSeries
            {
                DataSeries = ds3,
                StrokeStyle = new SCISolidPenStyle(ColorUtil.LightSteelBlue, 2f)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries = new SCIRenderableSeriesCollection { rs1, rs2, rs3 };
                Surface.ChartModifiers.Add(new SCIRolloverModifier());

                SCIAnimations.SweepSeries(rs1, 3, new SCICubicEase());
                SCIAnimations.SweepSeries(rs2, 3, new SCICubicEase());
                SCIAnimations.SweepSeries(rs3, 3, new SCICubicEase());
            }
        }
    }
}