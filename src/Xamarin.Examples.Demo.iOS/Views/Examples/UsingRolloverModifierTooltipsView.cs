using System;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using RolloverModifier Tooltips", "Demonstrates Rollover Tooltips", icon: ExampleIcon.Annotations)]
    public class UsingRolloverModifierTooltipsView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        protected override void UpdateFrame()
        {
            ExampleViewLayout.SciChartSurface.Frame = ExampleViewLayout.Frame;
            ExampleViewLayout.SciChartSurface.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            var xAxis = new SCINumericAxis();
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.2, 0.2)};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Sinewave A"};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Sinewave B"};
            var ds3 = new XyDataSeries<double, double> {SeriesName = "Sinewave C"};

            const double count = 100;
            const double k = 2*Math.PI/30;
            for (var i = 0; i < count; i++)
            {
                var phi = k*i;
                var sin = Math.Sin(phi);

                ds1.Append(i, (1.0 + i/count)*sin);
                ds2.Append(i, (0.5 + i/count)*sin);
                ds3.Append(i, (i/count)*sin);
            }

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds1,
                StrokeStyle = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Width = 7,
                    Height = 7,
                    FillStyle = new SCISolidBrushStyle(ColorUtil.Lavender)
                }
            });
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds2,
                StrokeStyle = new SCISolidPenStyle(ColorUtil.DarkGreen, 2f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Width = 7,
                    Height = 7,
                    FillStyle = new SCISolidBrushStyle(ColorUtil.Lavender)
                }
            });
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds3,
                StrokeStyle = new SCISolidPenStyle(ColorUtil.LightSteelBlue, 2f)
            });

            Surface.ChartModifiers = new SCIChartModifierCollection(
                new SCIRolloverModifier
                {
                    //ShowTooltip = true,
                    //ShowAxisLabels = true,
                    //DrawVerticalLine = true
                }
            );

            Surface.InvalidateElement();
        }
    }
}