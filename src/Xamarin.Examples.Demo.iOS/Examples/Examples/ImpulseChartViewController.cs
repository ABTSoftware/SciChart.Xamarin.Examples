using CoreGraphics;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Impulse Chart", description: "An Impulse or Stem Chart", icon: ExampleIcon.Impulse)]
    public class ImpulseChartViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var ds1Points = DataManager.Instance.GetDampedSinewave(1.0, 0.05, 50, 5);
            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(ds1Points.XData, ds1Points.YData);

            var rSeries = new SCIFastImpulseRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFF0066FF, 2f),
                PointMarker = new SCIEllipsePointMarker
                {
                    Size = new CGSize(7, 7),
                    StrokeStyle = new SCISolidPenStyle(0xFF0066FF, 2f),
                    FillStyle = new SCISolidBrushStyle(0xFF0066FF),
                }
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.ChartModifiers.Add(CreateDefaultModifiers());

                SCIAnimations.WaveSeries(rSeries, 3, new SCICubicEase());
            }
        }
    }
}