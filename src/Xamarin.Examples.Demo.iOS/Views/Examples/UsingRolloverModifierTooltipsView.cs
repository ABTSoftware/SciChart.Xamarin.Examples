using System;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Using RolloverModifier Tooltips")]
    public class UsingRolloverModifierTooltipsView : ExampleBaseView
    {
        private const uint SteelBlueColor = 4282811060U;
        private const uint LavenderColor = 4293322490U;
        private const uint DarkGreenColor = 4278215680U;
        private const uint LightSteelBlueColor = 4289774814U;

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

            var xAxis = new SCINumericAxis {IsXAxis = true};
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
                Style =
                {
                    LinePen = new SCIPenSolid(SteelBlueColor, 2f),
                    PointMarker = new SCIEllipsePointMarker
                    {
                        Width = 7,
                        Height = 7,
                        FillBrush = new SCIBrushSolid(LavenderColor)
                    }
                }
            });
			Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds2,
                Style =
                {
                    LinePen = new SCIPenSolid(DarkGreenColor, 2f),
                    PointMarker = new SCIEllipsePointMarker
                    {
                        Width = 7,
                        Height = 7,
                        FillBrush = new SCIBrushSolid(LavenderColor)
                    }
                }
            });
			Surface.RenderableSeries.Add(new SCIFastLineRenderableSeries
            {
                DataSeries = ds3,
                Style = {LinePen = new SCIPenSolid(LightSteelBlueColor, 2f)}
            });

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIRolloverModifier
                {
                    //ShowTooltip = true,
                    //ShowAxisLabels = true,
                    //DrawVerticalLine = true
                }
            });

            Surface.InvalidateElement();
        }
    }
}