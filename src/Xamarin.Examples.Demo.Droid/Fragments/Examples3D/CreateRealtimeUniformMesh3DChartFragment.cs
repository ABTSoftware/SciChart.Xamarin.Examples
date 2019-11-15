using SciChart.Charting.Visuals.Axes;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Grid;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Data;
using SciChart.Charting3D.Visuals.RenderableSeries.SurfaceMesh;
using SciChart.Core.Model;
using SciChart.Data.Model;
using Xamarin.Examples.Demo;
using System;
using System.Drawing;
using System.Timers;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Realtime 3D Surface Mesh", description: "Update a Uniform Mesh in real-time", icon: ExampleIcon.RealTime)]
    public class CreateRealtimeUniformMesh3DChartFragment : ExampleBaseFragment
    {
        private const int Width = 30;
        private const int Height = 30;

        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        private const int TimerInterval = 33;
        private volatile bool _isRunning = false;
        private readonly object _syncRoot = new object();
        private Timer _timer;

        private readonly UniformGridDataSeries3D<double, double, double> _dataSeries3D = new UniformGridDataSeries3D<double, double, double>(Width, Height);

        private readonly DoubleValues _buffer = new DoubleValues(Width * Height);

        private int _frames = 0;

        protected override void InitExample()
        {
            var renderableSeries3D = new SurfaceMeshRenderableSeries3D()
            {
                DataSeries = _dataSeries3D,
                Stroke = 0x7FFFFFFF,
                StrokeThickness = 1f.ToDip(Activity),
                DrawSkirt = false,
                Minimum = 0,
                Maximum = 0.5,
                Shininess = 64,
                MeshColorPalette = new GradientColorPalette(
                  new Color[] { Color.FromArgb(0xFF, 0x1D, 0x2C, 0x6B), Color.Blue, Color.Cyan, Color.GreenYellow, Color.Yellow, Color.Red, Color.DarkRed },
                  new float[] { 0, .1f, .3f, .5f, .7f, .9f, 1 })
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { AutoRange = AutoRange.Always };
                Surface.YAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(0, 1) };
                Surface.ZAxis = new NumericAxis3D() { AutoRange = AutoRange.Always };

                Surface.Camera = new Camera3D();

                Surface.RenderableSeries.Add(renderableSeries3D);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D()
                };
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
            lock (_syncRoot)
            {
                if (!_isRunning) return;

                var wc = Width * 0.5;
                var hc = Height * 0.5;
                var freq = Math.Sin(_frames++ * 0.1) * 0.1 + 0.1;

                using (Surface.SuspendUpdates())
                {
                    var calc = _dataSeries3D.IndexCalculator;

                    _buffer.SetSize(Width * Height);

                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            double radius = Math.Sqrt((wc - i) * (wc - i) + (hc - j) * (hc - j));
                            double d = Math.PI * radius * freq;
                            double value = Math.Sin(d) / d;

                            var index = calc.GetIndex(j, i);

                            _buffer.Set(index, double.IsNaN(value) ? 1 : value);
                        }
                    }

                    _dataSeries3D.CopyFrom(_buffer);
                }
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            Pause();
        }

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }
    }
}