﻿using System;
using CoreGraphics;
using SciChart.iOS.Charting;
using UIKit;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Scatter Chart", description: "Demonstrates a simple Scatter chart", icon: ExampleIcon.ScatterChart)]
    public class ScatterChartViewController : SingleChartViewController<SCIChartSurface>
    {
        private readonly Random _random = new Random();

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1) };

            var rSeries1 = GetScatterRenderableSeries(new SCITrianglePointMarker(), 0xFFFFEB01, false);
            var rSeries2 = GetScatterRenderableSeries(new SCIEllipsePointMarker(), 0xFFFFA300, false);
            var rSeries3 = GetScatterRenderableSeries(new SCITrianglePointMarker(), 0xFFFF6501, true);
            var rSeries4 = GetScatterRenderableSeries(new SCIEllipsePointMarker(), 0xFFFFA300, true);

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries1);
                Surface.RenderableSeries.Add(rSeries2);
                Surface.RenderableSeries.Add(rSeries3);
                Surface.RenderableSeries.Add(rSeries4);

                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomExtentsModifier(),
                    new SCIPinchZoomModifier(),
                    new SCICursorModifier(),
                    new SCIXAxisDragModifier(),
                    new SCIYAxisDragModifier { DragMode = SCIAxisDragMode.Pan }
                };
            }
        }

        private SCIXyScatterRenderableSeries GetScatterRenderableSeries(IISCIPointMarker pointMarker, uint color, bool negative)
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

            pointMarker.Size = new CGSize(6, 6); 
            pointMarker.StrokeStyle = new SCISolidPenStyle(UIColor.White, 0.1f);
            pointMarker.FillStyle = new SCISolidBrushStyle(color);

            var rSeries = new SCIXyScatterRenderableSeries { DataSeries = dataSeries, PointMarker = pointMarker };

            SCIAnimations.WaveSeries(rSeries, 3, new SCICubicEase());

            return rSeries;
        }

        private double GetRandom(Random random, double min, double max)
        {
            return min + (max - min) * random.NextDouble();
        }
    }
}