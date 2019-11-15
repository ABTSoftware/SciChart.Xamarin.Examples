using CoreGraphics;
using UIKit;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Series Selection", description: "Select series by touch or programmatically", icon: ExampleIcon.LineChart)]
    public class SeriesSelectionViewController : SingleChartViewController<SCIChartSurface>
    {
        private const int SeriesPointCount = 50;
        private const int SeriesCount = 80;

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };
            var leftAxis = new SCINumericAxis { AxisAlignment = SCIAxisAlignment.Left, AxisId = SCIAxisAlignment.Left.ToString() };
            var rightAxis = new SCINumericAxis { AxisAlignment = SCIAxisAlignment.Right, AxisId = SCIAxisAlignment.Right.ToString() };

            var seriesSelectionModifier = new SCISeriesSelectionModifier { SelectedSeriesStyle = new SelectedSeriesStyle() };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(leftAxis);
                Surface.YAxes.Add(rightAxis);
                Surface.ChartModifiers.Add(seriesSelectionModifier);

                var initialColor = UIColor.Blue;
                for (var i = 0; i < SeriesCount; i++)
                {
                    var alignment = i % 2 == 0 ? SCIAxisAlignment.Left : SCIAxisAlignment.Right;
                    var dataSeries = GenerateDataSeries(alignment, i);

                    var rs = new SCIFastLineRenderableSeries { DataSeries = dataSeries, YAxisId = alignment.ToString(), StrokeStyle = new SCISolidPenStyle(initialColor, 1f) };
                    Surface.RenderableSeries.Add(rs);

                    // Colors are incremented for visual purposes only
                    var newR = initialColor.R() == 255 ? 255 : initialColor.R() + 5;
                    var newB = initialColor.B() == 0 ? 0 : initialColor.B() - 2;
                    initialColor = UIColor.FromRGB((byte)newR, initialColor.G(), (byte)newB);

                    SCIAnimations.SweepSeries(rs, 3, new SCICubicEase());
                }
            }
        }

        private static IDataSeries GenerateDataSeries(SCIAxisAlignment alignment, int index)
        {
            var dataSeries = new XyDataSeries<double, double> { SeriesName = $"Series {index}" };

            var gradient = alignment == SCIAxisAlignment.Right ? index : -index;
            var start = alignment == SCIAxisAlignment.Right ? 0d : 14000d;

            var straightLine = DataManager.Instance.GetStraightLine(gradient, start, SeriesPointCount);
            dataSeries.Append(straightLine.XData, straightLine.YData);

            return dataSeries;
        }

        private class SelectedSeriesStyle : SCIStyleBase<SCIRenderableSeriesBase>
        {
            private readonly SCIPenStyle _selectedStrokeStyle = new SCISolidPenStyle(UIColor.White, 4f);
            private readonly SCIEllipsePointMarker _selectedPointMarker;

            private const string Stroke = "Stroke";
            private const string PointMarker = "PointMarker";

            public SelectedSeriesStyle()
            {
                _selectedPointMarker = new SCIEllipsePointMarker
                {
                    Size = new CGSize(10, 10),
                    FillStyle = new SCISolidBrushStyle(0xFFFF00DC),
                    StrokeStyle = new SCISolidPenStyle(UIColor.White, 1f)
                };
            }

            protected override void ApplyStyle(SCIRenderableSeriesBase styleableObject)
            {
                PutPropertyValue(styleableObject, Stroke, styleableObject.StrokeStyle);
                PutPropertyValue(styleableObject, PointMarker, styleableObject.PointMarker);

                styleableObject.StrokeStyle = _selectedStrokeStyle;
                styleableObject.PointMarker = _selectedPointMarker;
            }

            protected override void DiscardStyle(SCIRenderableSeriesBase styleableObject)
            {
                styleableObject.StrokeStyle = GetPropertyValue<SCIPenStyle>(styleableObject, Stroke);
                styleableObject.PointMarker = GetPropertyValue<SCIEllipsePointMarker>(styleableObject, PointMarker);
            }
        }
    }
}