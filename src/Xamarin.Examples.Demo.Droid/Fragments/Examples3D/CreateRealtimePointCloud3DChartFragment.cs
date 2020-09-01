using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.Xyz;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.PointMarkers;
using SciChart.Charting3D.Visuals.RenderableSeries.Scatter;
using SciChart.Data.Model;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Realtime Point Cloud 3D", description: "Create a real-time 3D Point Cloud", icon: ExampleIcon.RealTime)]
    class CreateRealtimePointCloud3DChartFragment : ExampleBaseFragment
    {
        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        private const int TimerInterval = 10;
        private volatile bool _isRunning = false;
        private readonly object _syncRoot = new object();
        private Timer _timer;

        private readonly XyzDataSeries3D<double, double, double> _dataSeries3D = new XyzDataSeries3D<double, double, double>();

        private readonly List<double> _xData = new List<double>();
        private readonly List<double> _yData = new List<double>();
        private readonly List<double> _zData = new List<double>();

        protected override void InitExample()
        {
            var dataManager = DataManager.Instance;

            for (int i = 0; i < 1000; i++)
            {
                _xData.Add(dataManager.GetGaussianRandomNumber(5, 1.5));
                _yData.Add(dataManager.GetGaussianRandomNumber(5, 1.5));
                _zData.Add(dataManager.GetGaussianRandomNumber(5, 1.5));
            }

            _dataSeries3D.Append(_xData, _yData, _zData);

            var pointMarker3D = new EllipsePointMarker3D()
            {
                FillColor = Color.FromArgb(0x77, 0xAD, 0xFF, 0x2F),
                Size = 3f
            };

            var renderableSeries3D = new ScatterRenderableSeries3D()
            {
                PointMarker = pointMarker3D,
                DataSeries = _dataSeries3D
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.YAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };
                Surface.ZAxis = new NumericAxis3D() { GrowBy = new DoubleRange(0.1, 0.1) };

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

                var random = new Random();
                for (int i = 0, size = _dataSeries3D.Count; i < size; i++)
                {
                    _xData[i] += random.NextDouble() - 0.5;
                    _yData[i] += random.NextDouble() - 0.5;
                    _zData[i] += random.NextDouble() - 0.5;
                }

                _dataSeries3D.UpdateRangeXyzAt(0, _xData, _yData, _zData);
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