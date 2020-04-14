using CoreGraphics;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Custom Gesture Modifier Chart", description: "Shows how to create a Custom Gesture Modifier", icon: ExampleIcon.Impulse)]
    public class CustomGestureModifierChartViewController : SingleChartViewController<SCIChartSurface>
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

            var annotation = new SCITextAnnotation
            {
                Text = "Double Tap and pan vertically to Zoom In/Out. \nDouble tap to Zoom Extents.",
                FontStyle = new SCIFontStyle(16, UIColor.White),
                X1Value = 0.5,
                Y1Value = 0,
                CoordinateMode = SCIAnnotationCoordinateMode.Relative,
                VerticalAnchorPoint = SCIVerticalAnchorPoint.Top,
                HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.Annotations.Add(annotation);
                Surface.ChartModifiers = new SCIChartModifierCollection { new CustomGestureModifier(), new SCIZoomExtentsModifier() };

                SCIAnimations.WaveSeries(rSeries, 3, new SCICubicEase());
            }
        }
    }
}