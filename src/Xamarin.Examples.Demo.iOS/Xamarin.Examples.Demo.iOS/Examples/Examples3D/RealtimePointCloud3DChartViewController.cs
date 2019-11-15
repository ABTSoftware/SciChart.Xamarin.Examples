using System;
using System.Timers;
using System.Collections.Generic;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Realtime Point Cloud 3D", description: "Create a real-time 3D Point Cloud", icon: ExampleIcon.RealTime)]
    class RealtimePointCloud3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        private const int TimerInterval = 10;
        private volatile bool _isRunning = false;
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

            var rSeries3D = new SCIScatterRenderableSeries3D
            {
                DataSeries = _dataSeries3D,
                PointMarker = new SCIEllipsePointMarker3D { FillColor = 0x77ADFF2F, Size = 3f },
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.YAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
                Surface.ZAxis = new SCINumericAxis3D { GrowBy = new SCIDoubleRange(0.1, 0.1) };
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

                var random = new Random();
                for (int i = 0, size = _dataSeries3D.Count; i < size; i++)
                {
                    _xData[i] += random.NextDouble() - 0.5;
                    _yData[i] += random.NextDouble() - 0.5;
                    _zData[i] += random.NextDouble() - 0.5;
                }

                _dataSeries3D.UpdateRangeXyzAt(0, _xData, _yData, _zData);
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