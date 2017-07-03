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
    [ExampleDefinition("Series Selection", description: "Select series by touch or programmatically", icon: ExampleIcon.LineChart)]
    public class SeriesSelectionView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        protected override void UpdateFrame()
        {
            Surface.TranslatesAutoresizingMaskIntoConstraints = false;

            NSLayoutConstraint constraintRight = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint constraintLeft = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint constraintTop = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 0);
            NSLayoutConstraint constraintBottom = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0);

            this.AddConstraint(constraintRight);
            this.AddConstraint(constraintLeft);
            this.AddConstraint(constraintTop);
            this.AddConstraint(constraintBottom);
        }

        private const int SeriesPointCount = 50;
        private const int SeriesCount = 80;

        protected override void InitExampleInternal()
        {
            var xAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };
            var leftAxis = new SCINumericAxis { AxisAlignment = SCIAxisAlignment.Left, AxisId = SCIAxisAlignment.Left.ToString() };
            var rightAxis = new SCINumericAxis { AxisAlignment = SCIAxisAlignment.Right, AxisId = SCIAxisAlignment.Right.ToString() };

            var initialColor = UIColor.Blue;
            var selectedStrokeStyle = new SCISolidPenStyle(ColorUtil.White, 4f);
            var selectedPointMarker = new SCIEllipsePointMarker
            {
                Width = 10,
                Height = 10,
                FillStyle = new SCISolidBrushStyle(0xFFFF00DC),
                StrokeStyle = new SCISolidPenStyle(ColorUtil.White, 1f)
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(leftAxis);
                Surface.YAxes.Add(rightAxis);

                for (var i = 0; i < SeriesCount; i++)
                {
                    var alignment = i % 2 == 0 ? SCIAxisAlignment.Left : SCIAxisAlignment.Right;
                    var dataSeries = GenerateDataSeries(alignment, i);

                    var rs = new SCIFastLineRenderableSeries
                    {
                        DataSeries = dataSeries,
                        YAxisId = alignment.ToString(),
                        StrokeStyle = new SCISolidPenStyle(initialColor, 2f),
                        SelectedSeriesStyle = new SCILineSeriesStyle
                        {
                            StrokeStyle = selectedStrokeStyle,
                            PointMarker = selectedPointMarker,
                        }
                    };

                    // Colors are incremented for visual purposes only
                    var newR = initialColor.R() == 255 ? 255 : initialColor.R() + 5;
                    var newB = initialColor.B() == 0 ? 0 : initialColor.B() - 2;
                    initialColor = UIColor.FromRGB((byte)newR, initialColor.G(), (byte)newB);

                    Surface.RenderableSeries.Add(rs);
                }

                Surface.ChartModifiers.Add(new SCISeriesSelectionModifier());
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
    }
}