using System.Collections.Generic;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using TooltipModifier Tooltips")]
    public class UsingTooltipModifierTooltipsView : ExampleBaseView
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleViewLayout;

        protected override void UpdateFrame()
        {
            _exampleViewLayout.SciChartSurfaceView.Frame = _exampleViewLayout.Frame;
            _exampleViewLayout.SciChartSurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            Surface = new SCIChartSurface(_exampleViewLayout.SciChartSurfaceView);

            var xAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), AutoRange = SCIAutoRange.Always};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};

            var ds1 = new XyDataSeries<double, double> {SeriesName = "Lissajous Curve", AcceptUnsortedData = true};
            var ds2 = new XyDataSeries<double, double> {SeriesName = "Sinewave", AcceptUnsortedData = true};

            var ds1Points = DataManager.Instance.GetLissajousCurve(0.8, 0.2, 0.43, 500);
            var ds2Points = DataManager.Instance.GetSinewave(1.5, 1.0, 500);

            var scaledXValues = GetScaledValues(ds1Points.XData);

            ds1.Append(scaledXValues, ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);

            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds1,
                Style =
                {
                    LinePen = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                    DrawPointMarkers = true,
                    PointMarker = new SCIEllipsePointMarker
                    {
                        Width = 5,
                        Height = 5,
                        BorderPen = new SCISolidPenStyle(ColorUtil.SteelBlue, 2f),
                        FillBrush = new SCISolidBrushStyle(ColorUtil.SteelBlue)
                    }
                }
            });
            Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds2,
                Style =
                {
                    LinePen = new SCISolidPenStyle(0xFFFF3333, 2f),
                    DrawPointMarkers = true,
                    PointMarker = new SCIEllipsePointMarker
                    {
                        Width = 5,
                        Height = 5,
                        BorderPen = new SCISolidPenStyle(0xFFFF3333, 2f),
                        FillBrush = new SCISolidBrushStyle(0xFFFF3333)
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