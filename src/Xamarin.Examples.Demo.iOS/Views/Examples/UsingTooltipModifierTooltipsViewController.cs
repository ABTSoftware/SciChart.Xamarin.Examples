using System;
using System.Collections.Generic;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using TooltipModifier Tooltips", description: "Demonstrates a simple tooltip", icon: ExampleIcon.Annotations)]
    public class UsingTooltipModifierTooltipsViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), AutoRange = SCIAutoRange.Always };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var ds1 = new XyDataSeries<double, double> { SeriesName = "Lissajous Curve", AcceptUnsortedData = true };
            var ds2 = new XyDataSeries<double, double> { SeriesName = "Sinewave", AcceptUnsortedData = true };

            var ds1Points = DataManager.Instance.GetLissajousCurve(0.8, 0.2, 0.43, 500);
            var ds2Points = DataManager.Instance.GetSinewave(1.5, 1.0, 500);

            var scaledXValues = GetScaledValues(ds1Points.XData);

            ds1.Append(scaledXValues, ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);

                Surface.RenderableSeries = new SCIRenderableSeriesCollection
                {
                    new SCIFastLineRenderableSeries
                    {
                        DataSeries = ds1,
                        StrokeStyle = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                        PointMarker = new SCIEllipsePointMarker
                        {
                            Width = 5,
                            Height = 5,
                            StrokeStyle = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                            FillStyle = new SCISolidBrushStyle(ColorUtil.SteelBlue)
                        }
                    },
                    new SCIFastLineRenderableSeries
                    {
                        DataSeries = ds2,
                        StrokeStyle = new SCISolidPenStyle(0xFFFF3333, 2f),
                        PointMarker = new SCIEllipsePointMarker
                        {
                            Width = 5,
                            Height = 5,
                            StrokeStyle = new SCISolidPenStyle(0xFFFF3333, 2f),
                            FillStyle = new SCISolidBrushStyle(0xFFFF3333)
                        }
                    }
                };
         
                Surface.ChartModifiers.Add(new SCITooltipModifier { Style = { HitTestMode = SCIHitTestMode.Interpolate } });
            }
        }

        private static IList<double> GetScaledValues(IList<double> values)
        {
            var size = values.Count;

            var scaledValues = new List<double>(size);

            for (var i = 0; i < size; i++)
            {
                var value = values[i];
                scaledValues.Add((value + 1) * 5);
            }

            return scaledValues;
        }
    }
}