using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Timers;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Heatmap Chart", description:"A real-time 2D scientific heatmap")]
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
        private readonly UniformHeatmapDataSeries<int, int, double> _dataSeries = new UniformHeatmapDataSeries<int, int, double>(new double[Width,Height], 0, 1, 0, 1);
        private readonly List<double[]> _valuesList = Enumerable.Range(0, SeriesPerPeriod).Select(CreateValues).ToList();

        private static double[] CreateValues(int index)
        {
            var values = new List<double>(Width*Height);

            var random = new Random();
            var angle = Math.PI*2*index/SeriesPerPeriod;
            var cx = 150;
            var cy = 100;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var v = (1 + Math.Sin(x*0.04 + angle))*50 + (1 + Math.Sin(y*0.1 + angle))*50*(1 + Math.Sin(angle*2));
                    var r = Math.Sqrt((x - cx)*(x - cx) + (y - cy)*(y - cy));
                    var exp = Math.Max(0, 1 - r*0.008);

                    values.Add(v*exp + random.NextDouble()*50);
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

            var xAxis = new SCINumericAxis();
            var yAxis = new SCINumericAxis();

            float[] coords = {0.0f, 0.16f, 0.33f, 0.5f, 0.67f, 0.83f, 1.0f};
            uint[] colors = {0xFFFF0080, 0xFFFF0000, 0xFFFFFF00, 0xFF00FF00, 0xFF00FFFF, 0xFF0070FF, 0xFF0000FF};
            var textureOpenGl = new SCITextureOpenGL(coords, colors, colors.Length);

            var renderSeries = new SCIFastUniformHeatmapRenderableSeries
            {
                DataSeries = _dataSeries,
                Style =
                {
                    Minimum = 0,
                    Maximum = 200,
                    Palette = textureOpenGl
                }
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
            _dataSeries.UpdateZValues(values);

            _timerIndex++;

            Surface.InvalidateElement();
        }

        public override void RemoveFromSuperview()
        {
            base.RemoveFromSuperview();

            _timer.Stop();
            _timer.Elapsed -= OnTick;
        }
    }
}