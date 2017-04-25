using System;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Scatter Chart", description:"Demonstrates a simple Scatter chart")]
    public class ScatterChartView : ExampleBaseView
    {
        private readonly Random _random = new Random();

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

            var xAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1)};

            var rSeries1 = GetScatterRenderableSeries(new SCITrianglePointMarker(), 0xFFFFEB01, false);
            var rSeries2 = GetScatterRenderableSeries(new SCIEllipsePointMarker(), 0xFFFFA300, false);
            var rSeries3 = GetScatterRenderableSeries(new SCITrianglePointMarker(), 0xFFFF6501, true);
            var rSeries4 = GetScatterRenderableSeries(new SCIEllipsePointMarker(), 0xFFFFA300, true);

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(rSeries1);
            Surface.RenderableSeries.Add(rSeries2);
            Surface.RenderableSeries.Add(rSeries3);
            Surface.RenderableSeries.Add(rSeries4);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIZoomExtentsModifier(),
                new SCIPinchZoomModifier(),
                new SCICursorModifier(),
                new SCIXAxisDragModifier(), 
                new SCIYAxisDragModifier {DragMode = SCIAxisDragMode.Pan}, 
            });

            Surface.InvalidateElement();
        }

        private SCIXyScatterRenderableSeries GetScatterRenderableSeries(ISCIPointMarkerProtocol pointMarker, uint color, bool negative)
        {
            var seriesName = pointMarker is SCIEllipsePointMarker ?
                negative ? "Negative Ellipse" : "Positive Ellipse" :
                negative ? "Negative" : "Positive";

            var dataSeries = new XyDataSeries<int, double> { SeriesName = seriesName };

            for (var i = 0; i < 200; i++)
            {
                var time = i < 100 ? GetRandom(_random, 0, i + 10) / 100 : GetRandom(_random, 0, 200 - i + 10) / 100;
                var y = negative ? -time * time * time : time * time * time;

                dataSeries.Append(i, y);
            }

            pointMarker.Height = 6;
            pointMarker.Width = 6;
            pointMarker.StrokeStyle = new SCISolidPenStyle(UIColor.White, 0.1f);
            pointMarker.FillStyle = new SCISolidBrushStyle(color);

            return new SCIXyScatterRenderableSeries
            {
                DataSeries = dataSeries,
                Style = {PointMarker = pointMarker},
            };
        }

        private double GetRandom(Random random, double min, double max)
        {
            return min + (max - min) * random.NextDouble();
        }
    }
}