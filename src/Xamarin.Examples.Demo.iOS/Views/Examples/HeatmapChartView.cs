using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    //[ExampleDefinition("Heatmap Chart")]
    public class HeatmapChartView : ExampleBaseView
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleViewLayout;

        private const int Width = 300;
        private const int Height = 200;
        private const int SeriesPerPeriod = 30;

        private readonly Timer _timer = new Timer(40) { AutoReset = true };
        private int _timerIndex = 0;
        //private readonly UniformHeatmapDataSeries<int, int, double> _dataSeries = new UniformHeatmapDataSeries<int, int, double>(Width, Height);
        private readonly List<double[]> _valuesList = Enumerable.Range(0, SeriesPerPeriod).Select(CreateValues).ToList();

        private static double[] CreateValues(int index)
        {
            var values = new List<double>(Width * Height);

            var random = new Random();
            var angle = Math.PI * 2 * index / SeriesPerPeriod;
            var cx = 150;
            var cy = 100;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var v = (1 + Math.Sin(x * 0.04 + angle)) * 50 + (1 + Math.Sin(y * 0.1 + angle)) * 50 * (1 + Math.Sin(angle * 2));
                    var r = Math.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
                    var exp = Math.Max(0, 1 - r * 0.008);

                    values.Add(v * exp + random.NextDouble() * 50);
                }
            }

            return values.ToArray();
        }

        protected override void UpdateFrame()
        {
            _exampleViewLayout.SciChartSurfaceView.Frame = _exampleViewLayout.Frame;
            _exampleViewLayout.SciChartSurfaceView.TranslatesAutoresizingMaskIntoConstraints = true;
        }

        protected override void InitExampleInternal()
        {
            Surface = new SCIChartSurface(_exampleViewLayout.SciChartSurfaceView);

            var xAxis = new SCINumericAxis { IsXAxis = true };
            var yAxis = new SCINumericAxis();

            var renderSeries = new SCIHeatMapRenderableSeries
            {
                //DataSeries = _dataSeries,
                Style = { }
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
			Surface.RenderableSeries.Add(renderSeries);

            Surface.ChartModifier = new SCIModifierGroup(new ISCIChartModifierProtocol[]
            {
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            });

            Surface.InvalidateElement();

            _timer.Elapsed += OnTick;
            _timer.Start();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            var values = _valuesList[_timerIndex % SeriesPerPeriod];
            //_dataSeries.UpdateZValues(values);

            _timerIndex++;
        }

        public override void RemoveFromSuperview()
        {
            base.RemoveFromSuperview();

            _timer.Stop();
            _timer.Elapsed -= OnTick;
        }
    }
}