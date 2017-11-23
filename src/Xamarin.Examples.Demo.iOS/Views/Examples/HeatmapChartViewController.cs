using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Heatmap Chart", description: "A real-time 2D scientific heatmap", icon: ExampleIcon.HeatmapChart)]
    public class HeatmapChartViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

        private const int Width = 300;
        private const int Height = 200;
        private const int SeriesPerPeriod = 30;

        private volatile bool _isRunning = false;
        private readonly object _syncRoot = new object();
        private readonly Timer _timer = new Timer(40) { AutoReset = true };

        private int _timerIndex = 0;
        private readonly UniformHeatmapDataSeries<int, int, double> _dataSeries = new UniformHeatmapDataSeries<int, int, double>(new double[Width, Height], 0, 1, 0, 1);

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

        protected override void InitExample()
        {
            var xAxis = new SCINumericAxis();
            var yAxis = new SCINumericAxis();

            float[] coords = { 0, 0.2f, 0.4f, 0.6f, 0.8f, 1 };
            uint[] colors = { 0xFF0000FF, 0xFF6495ed, 0xFF006400, 0xFF7FFF00, 0xFFFFFF00, 0xFFFF0000 };
            var textureOpenGl = new SCITextureOpenGL(coords, colors, colors.Length);

            var renderSeries = new SCIFastUniformHeatmapRenderableSeries
            {
                DataSeries = _dataSeries,
                Minimum = 0,
                Maximum = 200,
                ColorMap = textureOpenGl
            };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);
            Surface.RenderableSeries.Add(renderSeries);

            Surface.ChartModifiers = new SCIChartModifierCollection
            {
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            };

            Start();
        }

        private void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _timer.Elapsed += OnTick;
            _timer.Start();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            lock (_syncRoot)
            {
                if (!_isRunning) return;

                UpdateDataSeries(_timerIndex);

                _timerIndex++;
            }
        }

        private void UpdateDataSeries(int index)
        {
            var values = _valuesList[_timerIndex % SeriesPerPeriod];
            _dataSeries.UpdateZValues(values);
        }

        private void Stop()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Stop();
        }
    }
}