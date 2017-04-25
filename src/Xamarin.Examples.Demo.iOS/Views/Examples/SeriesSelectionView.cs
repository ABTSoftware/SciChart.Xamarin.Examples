using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Series Selection", description:"Select series by touch or programmatically")]
    public class SeriesSelectionView : ExampleBaseView
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleViewLayout;

        private const int SeriesPointCount = 50;
        private const int SeriesCount = 80;

        protected override void UpdateFrame()
        {
            _exampleViewLayout.SciChartSurfaceView.Frame = _exampleViewLayout.Frame;
            _exampleViewLayout.SciChartSurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            Surface = new SCIChartSurface(_exampleViewLayout.SciChartSurfaceView);

            var xAxis = new SCINumericAxis {AutoRange = SCIAutoRange.Always};
            var leftAxis = new SCINumericAxis {AxisAlignment = SCIAxisAlignment.Left, AxisId = SCIAxisAlignment.Left.ToString()};
            var rightAxis = new SCINumericAxis {AxisAlignment = SCIAxisAlignment.Right, AxisId = SCIAxisAlignment.Right.ToString()};

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(leftAxis);
            Surface.YAxes.Add(rightAxis);

            var initialColor = UIColor.Blue;
            var selectedStrokeStyle = new SCISolidPenStyle(ColorUtil.White, 4f);
            var selectedPointMarker = new SCIEllipsePointMarker
            {
                Width = 10,
                Height = 10,
                FillStyle = new SCISolidBrushStyle(0xFFFF00DC),
                StrokeStyle = new SCISolidPenStyle(ColorUtil.White, 1f)
            };

            for (var i = 0; i < SeriesCount; i++)
            {
                var alignment = i % 2 == 0 ? SCIAxisAlignment.Left : SCIAxisAlignment.Right;
                var dataSeries = GenerateDataSeries(alignment, i);
                 
                var rs = new SCIFastLineRenderableSeries
                {
                    DataSeries = dataSeries,
                    YAxisId = alignment.ToString(),
                    Style = {LinePen = new SCISolidPenStyle(initialColor, 2f)},
                    SelectedSeriesStyle = new SCILineSeriesStyle
                    {
                        LinePen = selectedStrokeStyle,
                        PointMarker = selectedPointMarker,
                        DrawPointMarkers = true
                    }
                };

                // Colors are incremented for visual purposes only
                var newR = initialColor.R() == 255 ? 255 : initialColor.R() + 5;
                var newB = initialColor.B() == 0 ? 0 : initialColor.B() - 2;
                initialColor = UIColor.FromRGB((byte)newR, initialColor.G(), (byte)newB);

                Surface.RenderableSeries.Add(rs);
            }

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCISeriesSelectionModifier(),
            });

            Surface.InvalidateElement();
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
    }
}