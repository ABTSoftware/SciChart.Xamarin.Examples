using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    //[ExampleDefinition("Palette Provider", description:"Per-point coloring with the PaletteProvider API", icon:ExampleIcon.Themes)]
    public class PaletteProviderView : ExampleBaseView<SingleChartViewLayout>
    {
        class ZeroLinePaletteProvider : SCIPaletteProvider
        {
            private readonly SCILineSeriesStyle _style;
            private readonly double _zeroLine;
            ISCICoordinateCalculatorProtocol _yCoordCalc;

            public ZeroLinePaletteProvider()
            {
                _style = new SCILineSeriesStyle
                {
                    StrokeStyle = new SCISolidPenStyle(UIColor.Blue, (float)0.7)
                };
                _zeroLine = 0;
                _yCoordCalc = null;
            }

            public override void UpdateData(ISCIRenderPassDataProtocol data)
            {
                _yCoordCalc = data.YCoordinateCalculator;
            }

            public override ISCIStyleProtocol StyleForPoint(double x, double y, int index)
            {
                double value = _yCoordCalc.GetDataValueFrom(y);
                if (value < _zeroLine)
                {
                    return _style;
                }
                else
                {
                    return null;
                }
            }
        }

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

        protected override void InitExampleInternal()
        {
            var fourierSeries = DataManager.Instance.GetFourierSeries(1.0, 0.1);

            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(fourierSeries.XData, fourierSeries.YData);

            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var renderSeries = new SCIFastLineRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SCISolidPenStyle(0xFF99EE99, 0.7f),
                PaletteProvider = new ZeroLinePaletteProvider()
            };
            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(renderSeries);

            Surface.ChartModifiers = new SCIChartModifierCollection(
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            );
        }
    }
}