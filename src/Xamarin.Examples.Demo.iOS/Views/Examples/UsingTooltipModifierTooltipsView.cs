using System.Collections.Generic;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using TooltipModifier Tooltips")]
    public class UsingTooltipModifierTooltipsView : ExampleBaseView
    {
        private const uint SteelBlueColor = 4282811060U;
        private const uint IndianRedColor = 4291648604U;

        public SCIChartSurface Surface;

        protected override void InitExample()
        {
            var axisStyle = StyleHelper.GetDefaultAxisStyle();
            var xAxis = new SCINumericAxis {IsXAxis = true, GrowBy = new SCIDoubleRange(0.1, 0.1), AutoRange = SCIAutoRangeMode.Always, Style = axisStyle};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), Style = axisStyle};

            var ds1 = new XyDataSeries<double, double> { SeriesName = "Lissajous Curve", AcceptUnsortedData = true };
            var ds2 = new XyDataSeries<double, double> { SeriesName = "Sinewave", AcceptUnsortedData = true };

            var ds1Points = DataManager.Instance.GetLissajousCurve(0.8, 0.2, 0.43, 500);
            var ds2Points = DataManager.Instance.GetSinewave(1.5, 1.0, 500);

            var scaledXValues = GetScaledValues(ds1Points.XData);

            ds1.Append(scaledXValues, ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);

            Surface = new SCIChartSurface(this);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);

            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries
            {
                DataSeries = ds1,
                Style =
                {
                    LinePen = new SCIPenSolid(SteelBlueColor, 2f),
                    PointMarker = new SCIEllipsePointMarker
                    {
                        Width = 5,
                        Height = 5,
                        BorderPen = new SCIPenSolid(SteelBlueColor, 2f),
                        FillBrush = new SCIBrushSolid(SteelBlueColor)
                    }
                }
            });
            Surface.AttachRenderableSeries(new SCIFastLineRenderableSeries
            {
                DataSeries = ds2,
                Style =
                {
                    LinePen = new SCIPenSolid(IndianRedColor, 2f),
                    PointMarker = new SCIEllipsePointMarker
                    {
                        Width = 5,
                        Height = 5,
                        BorderPen = new SCIPenSolid(IndianRedColor, 2f),
                        FillBrush = new SCIBrushSolid(IndianRedColor)
                    }
                }
            });

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCITooltipModifier
                {
                    Style = {HitTestMode = (int) SCIHitTestMode.Interpolate}
                    //ShowAxisLabels = true,
                    //ShowTooltip = true,
                }
            });

            Surface.InvalidateElement();
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