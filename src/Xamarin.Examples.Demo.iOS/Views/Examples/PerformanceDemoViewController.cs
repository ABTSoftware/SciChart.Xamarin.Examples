using System;
using System.Collections.Generic;
using System.Timers;
using CoreGraphics;
using SciChart.Examples.Demo.Data;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Performance Demo", description: "Draws up to 1 Million points in realtime!", icon: ExampleIcon.RealTime)]
    public class PerformanceDemoViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleRealtimeChartLayout);

        public SCIChartSurface Surface => ((SingleRealtimeChartLayout)View).SciChartSurface;

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

        private readonly object _syncRoot = new object();
        private volatile bool _isRunning = false;
        private Timer _timer;

        private UILabel _countLabel;

        protected override void InitExample()
        {
            ((SingleRealtimeChartLayout)View).Start.TouchUpInside += (sender, args) => Start();
            ((SingleRealtimeChartLayout)View).Pause.TouchUpInside += (sender, args) => Pause();
            ((SingleRealtimeChartLayout)View).Reset.TouchUpInside += (sender, args) => Reset();

            _countLabel = new UILabel(new CGRect(0, 0, 220, 140));
            _countLabel.TextColor = UIColor.White;
            _countLabel.Font = UIFont.FromName("Helvetica", 14f);
            ((SingleRealtimeChartLayout)View).Add(_countLabel);

            var xAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };
            var yAxis = new SCINumericAxis { AutoRange = SCIAutoRange.Always };

            var rs1 = new SCIFastLineRenderableSeries { DataSeries = _mainSeries, StrokeStyle = new SCISolidPenStyle(0xFF4083B7, 2f) };
            var rs2 = new SCIFastLineRenderableSeries { DataSeries = _maLowSeries, StrokeStyle = new SCISolidPenStyle(0xFFFFA500, 2f) };
            var rs3 = new SCIFastLineRenderableSeries { DataSeries = _maHighSeries, StrokeStyle = new SCISolidPenStyle(0xFFE13219, 2f) };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rs1);
                Surface.RenderableSeries.Add(rs2);
                Surface.RenderableSeries.Add(rs3);
            }
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

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }

        private void Reset()
        {
            if (_isRunning)
                Pause();

            using (Surface.SuspendUpdates())
            {
                _mainSeries.Clear();
                _maLowSeries.Clear();
                _maHighSeries.Clear();
            }

            _maLow.Clear();
            _maHigh.Clear();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            lock (_syncRoot)
            {
                if (!_isRunning) return;

                InvokeOnMainThread(() =>
                {
                    if (GetPointsCount() < MaxPointCount)
                    {
                        DoAppendLoop();
                    }
                    else
                    {
                        Pause();
                    }
                });
            }
        }

        private int GetPointsCount()
        {
            return _mainSeries.Count + _maLowSeries.Count + _maHighSeries.Count;
        }

        private void DoAppendLoop()
        {
            using (Surface.SuspendUpdates())
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
                    _firstYValues.Add((float)_yValue);
                    _secondYValues.Add((float)_maLow.Push(_yValue).Current);
                    _thirdYValues.Add((float)_maHigh.Push(_yValue).Current);
                }

                _mainSeries.Append(_xValues, _firstYValues);
                _maLowSeries.Append(_xValues, _secondYValues);
                _maHighSeries.Append(_xValues, _thirdYValues);

                _countLabel.Text = "Amount of Points: " + _mainSeries.Count;
            }
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

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Reset();
        }
    }
}