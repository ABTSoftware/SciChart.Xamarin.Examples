using System;
using System.Timers;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Realtime 3D Surface Mesh", description: "Update a Uniform Mesh in real-time", icon: ExampleIcon.RealTime)]
    public class RealtimeUniformMesh3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        private const int Width = 30;
        private const int Height = 30;

        private const int TimerInterval = 33;
        private volatile bool _isRunning = false;
        private int _frames = 0;
        private Timer _timer;

        private readonly UniformGridDataSeries3D<double, double, double> _dataSeries3D = new UniformGridDataSeries3D<double, double, double>(Width, Height);

        private readonly SCIDoubleValues _buffer = new SCIDoubleValues(Width * Height);


        protected override void InitExample()
        {
            var rSeries3D = new SCISurfaceMeshRenderableSeries3D
            {
                DataSeries = _dataSeries3D,
                Stroke = 0x7FFFFFFF,
                StrokeThickness = 1f,
                DrawSkirt = false,
                Minimum = 0,
                Maximum = 0.5,
                Shininess = 64,
                MeshColorPalette = new SCIGradientColorPalette(
                    new[] { ColorUtil.Sapphire, ColorUtil.Blue, ColorUtil.Cyan, ColorUtil.GreenYellow, ColorUtil.Yellow, ColorUtil.Red, ColorUtil.DarkRed },
                    new[] { 0, .1f, .3f, .5f, .7f, .9f, 1 })
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { AutoRange = SCIAutoRange.Always };
                Surface.YAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(0, 1) };
                Surface.ZAxis = new SCINumericAxis3D { AutoRange = SCIAutoRange.Always };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
            }

            Start();
        }

        private void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _timer = new Timer(TimerInterval);
            _timer.Elapsed += OnTick;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            InvokeOnMainThread(() =>
            {
                if (!_isRunning) return;

                var wc = Width * 0.5;
                var hc = Height * 0.5;
                var freq = Math.Sin(_frames++ * 0.1) * 0.1 + 0.1;

                using (Surface.SuspendUpdates())
                {
                    var calc = _dataSeries3D.IndexCalculator;

                    _buffer.Count = Width * Height;
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            double radius = Math.Sqrt((wc - i) * (wc - i) + (hc - j) * (hc - j));
                            double d = Math.PI * radius * freq;
                            double value = Math.Sin(d) / d;

                            var index = calc.GetIndexAt(j, i);
                            _buffer.Set(double.IsNaN(value) ? 1 : value, index);
                        }
                    }

                    _dataSeries3D.CopyFrom(_buffer);
                }
            });
        }

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Pause();
        }
    }
}