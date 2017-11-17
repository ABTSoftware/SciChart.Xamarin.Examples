using System;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Impulse Chart", description: "An Impulse or Stem Chart", icon: ExampleIcon.Impulse)]
    public class ImpulseChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var ds1Points = DataManager.Instance.GetDampedSinewave(1.0, 0.05, 50, 5);
            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(ds1Points.XData, ds1Points.YData);

            var renderableSeries = new SCIFastImpulseRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFF0066FF, 2f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Width = 7,
                    Height = 7,
                    StrokeStyle = new SCISolidPenStyle(0xFF0066FF, 2f),
                    FillStyle = new SCISolidBrushStyle(0xFF0066FF),
                }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(renderableSeries);
                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomPanModifier(),
                    new SCIPinchZoomModifier(),
                    new SCIZoomExtentsModifier()
                };
            }
        }
    }
}