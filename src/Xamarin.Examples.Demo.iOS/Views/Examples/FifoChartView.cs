using System;
using System.Timers;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("FIFO Chart")]
    public class FifoChartView : ExampleBaseView
    {
        private readonly SingleRealtimeChartLayout _exampleViewLayout = SingleRealtimeChartLayout.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleViewLayout;

        private const int FifoCapacity = 200;
        private const long TimerInterval = 10;
        private const double OneOverTimeInteval = 1.0 / TimerInterval;
        private const double VisibleRangeMax = FifoCapacity * OneOverTimeInteval;
        private const double GrowBy = VisibleRangeMax * 0.1;

        private readonly Random _random = new Random();

        private readonly XyDataSeries<double, double> _ds1 = new XyDataSeries<double, double> { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _ds2 = new XyDataSeries<double, double> { FifoCapacity = FifoCapacity };
        private readonly XyDataSeries<double, double> _ds3 = new XyDataSeries<double, double> { FifoCapacity = FifoCapacity };

        private readonly SCIDoubleRange _xVisibleRange = new SCIDoubleRange(-GrowBy, VisibleRangeMax + GrowBy);

        private double _t = 0;
        private volatile bool _isRunning = false;
        private Timer _timer;

        protected override void UpdateFrame()
        {
        }

        protected override void InitExampleInternal()
        {
            Surface = new SCIChartSurface(_exampleViewLayout.SciChartSurfaceView);
            StyleHelper.SetSurfaceDefaultStyle(Surface);

            _exampleViewLayout.Start.TouchUpInside += (sender, args) => Start();
            _exampleViewLayout.Pause.TouchUpInside += (sender, args) => Pause();
            _exampleViewLayout.Reset.TouchUpInside += (sender, args) => Reset();

            var xAxis = new SCINumericAxis {IsXAxis = true, VisibleRange = _xVisibleRange, AutoRange = SCIAutoRangeMode.Never};
            var yAxis = new SCINumericAxis {GrowBy = new SCIDoubleRange(0.1, 0.1), AutoRange = SCIAutoRangeMode.Always};

            var rs1 = new SCIFastLineRenderableSeries
            {
                DataSeries = _ds1,
                Style = { LinePen = new SCIPenSolid(UIColor.FromRGB(0x40, 0x83, 0xB7), 2f) }
            };
            var rs2 = new SCIFastLineRenderableSeries
            {
                DataSeries = _ds2,
                Style = { LinePen = new SCIPenSolid(UIColor.FromRGB(0xFF, 0xA5, 0x00), 2f) }
            };
            var rs3 = new SCIFastLineRenderableSeries
            {
                DataSeries = _ds3,
                Style = { LinePen = new SCIPenSolid(UIColor.FromRGB(0xE1, 0x32, 0x19), 2f) }
            };

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(rs1);
            Surface.AttachRenderableSeries(rs2);
            Surface.AttachRenderableSeries(rs3);

            Surface.InvalidateElement();

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

            Surface.InvalidateElement();
        }

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;

            Surface.InvalidateElement();
        }

        private void Reset()
        {
            if (_isRunning)
                Pause();

            _ds1.Clear();
            _ds2.Clear();
            _ds3.Clear();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            lock (_timer)
            {
                var y1 = 3.0 * Math.Sin(((2 * Math.PI) * 1.4) * _t) + _random.NextDouble() * 0.5;
                var y2 = 2.0 * Math.Cos(((2 * Math.PI) * 0.8) * _t) + _random.NextDouble() * 0.5;
                var y3 = 1.0 * Math.Sin(((2 * Math.PI) * 2.2) * _t) + _random.NextDouble() * 0.5;

                _ds1.Append(_t, y1);
                _ds2.Append(_t, y2);
                _ds3.Append(_t, y3);

                _t += OneOverTimeInteval;

                if (_t > VisibleRangeMax)
                    _xVisibleRange.SetMinMax(_xVisibleRange.Min + OneOverTimeInteval, _xVisibleRange.Max + OneOverTimeInteval);
            }
        }

        public override void RemoveFromSuperview()
        {
            base.RemoveFromSuperview();

            Reset();
        }
    }
}