using System;
using System.Collections.Generic;
using System.Timers;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Helpers;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Performance Demo")]
    public class PerformanceDemoView : ExampleBaseView
    {
        private readonly PerformanceDemoViewLayout _exampleViewLayout = PerformanceDemoViewLayout.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleViewLayout;

        private static readonly int MaxPointCount = CalculateMaxPointCountToDisplay();
        private const int TimerInterval = 10;
        private const int BufferSize = 1000;

        private readonly MovingAverage _maLow = new MovingAverage(200);
        private readonly MovingAverage _maHigh = new MovingAverage(1000);

        private int _xValue = 0;
        private double _yValue = 10;

        private readonly List<int> _xValues = new List<int>(BufferSize);
        private readonly List<float> _firstYValues = new List<float>(BufferSize);
        private readonly List<float> _secondYValues = new List<float>(BufferSize);
        private readonly List<float> _thirdYValues = new List<float>(BufferSize);

        private readonly XyDataSeries<int, float> _mainSeries = new XyDataSeries<int, float>();
        private readonly XyDataSeries<int, float> _maLowSeries = new XyDataSeries<int, float>();
        private readonly XyDataSeries<int, float> _maHighSeries = new XyDataSeries<int, float>();

        private readonly Random _random = new Random();

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

            var xAxis = new SCINumericAxis {IsXAxis = true, AutoRange = SCIAutoRangeMode.Always, AxisTitle = "X-Axis"};
            var yAxis = new SCINumericAxis {AutoRange = SCIAutoRangeMode.Always, AxisTitle = "Y-Axis"};

            var rs1 = new SCIFastLineRenderableSeries
            {
                DataSeries = _mainSeries, 
                Style = { LinePen = new SCIPenSolid(UIColor.FromRGB(0x40, 0x83, 0xB7), 2f) }
            };
            var rs2 = new SCIFastLineRenderableSeries
            {
                DataSeries = _maLowSeries, 
                Style = { LinePen = new SCIPenSolid(UIColor.FromRGB(0xFF, 0xA5, 0x00), 2f) }
            };
            var rs3 = new SCIFastLineRenderableSeries
            {
                DataSeries = _maHighSeries, 
                Style = { LinePen = new SCIPenSolid(UIColor.FromRGB(0xE1, 0x32, 0x19), 2f) }
            };

            Surface.AttachAxis(xAxis, true);
            Surface.AttachAxis(yAxis, false);
            Surface.AttachRenderableSeries(rs1);
            Surface.AttachRenderableSeries(rs2);
            Surface.AttachRenderableSeries(rs3);

            Surface.InvalidateElement();
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

            _mainSeries.Clear();
            _maLowSeries.Clear();
            _maHighSeries.Clear();

            _maLow.Clear();
            _maHigh.Clear();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            lock (_timer)
            {
                if (GetPointsCount() < MaxPointCount)
                    DoAppendLoop();
                else
                    Pause();
            }
        }

        private int GetPointsCount()
        {
            return _mainSeries.Count + _maLowSeries.Count + _maHighSeries.Count;
        }

        private void DoAppendLoop()
        {
            _xValues.Clear();
            _firstYValues.Clear();
            _secondYValues.Clear();
            _thirdYValues.Clear();

            for (var i = 0; i < BufferSize; i++)
            {
                _xValue++;
                _yValue += _random.NextDouble() - 0.5;

                _xValues.Add(_xValue);
                _firstYValues.Add((float) _yValue);
                _secondYValues.Add((float) _maLow.Push(_yValue).Current);
                _thirdYValues.Add((float) _maHigh.Push(_yValue).Current);
            }

            _mainSeries.Append(_xValues, _firstYValues);
            _maLowSeries.Append(_xValues, _secondYValues);
            _maHighSeries.Append(_xValues, _thirdYValues);
        }

        private static int CalculateMaxPointCountToDisplay()
        {
            const int oneMlnPointsRequirement = 8 + 16 + 4 + 8;
            var memorySize = GetMaxMemorySize() - 40;
            var maxPointCount = memorySize / oneMlnPointsRequirement * 1000000;

            return (int)Math.Round(maxPointCount / 3);
        }

        private static double GetMaxMemorySize()
        {
            //return Runtime.GetRuntime().MaxMemory() / 1024.0 / 1024.0;
            return 256;
        }

        public override void RemoveFromSuperview()
        {
            base.RemoveFromSuperview();

            Reset();
        }
    }
}